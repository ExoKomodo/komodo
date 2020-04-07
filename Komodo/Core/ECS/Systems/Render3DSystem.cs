using Komodo.Core.ECS.Components;
using Komodo.Core.ECS.Entities;
using Komodo.Core.Engine.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System;

using ContainmentType = Microsoft.Xna.Framework.ContainmentType;
using GameTime = Microsoft.Xna.Framework.GameTime;
using Matrix = Microsoft.Xna.Framework.Matrix;

using BasicEffect = Microsoft.Xna.Framework.Graphics.BasicEffect;
using BlendState = Microsoft.Xna.Framework.Graphics.BlendState;
using DepthStencilState = Microsoft.Xna.Framework.Graphics.DepthStencilState;
using RasterizerState = Microsoft.Xna.Framework.Graphics.RasterizerState;
using SamplerState = Microsoft.Xna.Framework.Graphics.SamplerState;

namespace Komodo.Core.ECS.Systems
{
    /// <summary>
    /// Manages all <see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/> objects. There can be more than one Render3DSystem per <see cref="Komodo.Core.Game"/>.
    /// </summary>
    public class Render3DSystem : ISystem<Drawable3DComponent>
    {
        #region Constructors
        /// <param name="game">Reference to current <see cref="Komodo.Core.Game"/> instance.</param>
        public Render3DSystem(Game game)
        {
            Components = new List<Drawable3DComponent>();
            Entities = new Dictionary<Guid, Entity>();
            Game = game;
            TextureFilter = SamplerState.PointWrap;

            _uninitializedComponents = new Queue<Drawable3DComponent>();
        }
        #endregion Constructors

        #region Members

        #region Public Members
        /// <summary>
        /// <see cref="Komodo.Core.ECS.Components.CameraComponent"/> to be used for rendering all tracked <see cref="Components"/>.
        /// </summary>
        public CameraComponent ActiveCamera { get; set; }

        /// <summary>
        /// All tracked <see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/> objects.
        /// </summary>
        public List<Drawable3DComponent> Components { get; private set; }

        /// <summary>
        /// All tracked <see cref="Komodo.Core.ECS.Entities.Entity"/> objects.
        /// </summary>
        public Dictionary<Guid, Entity> Entities { get; set; }

        /// <summary>
        /// Reference to current <see cref="Komodo.Core.Game"/> instance.
        /// </summary>
        public Game Game { get; }

        /// <summary>
        /// Whether or not the Drawable3DSystem has called <see cref="Initialize()"/>.
        /// </summary>
        public bool IsInitialized { get; private set; }
        
        /// <summary>
        /// Texture filtering to use for 3D textures.
        /// </summary>
        public SamplerState TextureFilter { get; set; }
        #endregion Public Members

        #region Private Members
        /// <summary>
        /// Tracks all potentially uninitialized <see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/> objects.
        /// All <see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/> objects will be initialized in the <see cref="Initialize"/>, <see cref="PreUpdate(GameTime)"/>, or <see cref="PostUpdate(GameTime)"/> methods.
        /// </summary>
        private Queue<Drawable3DComponent> _uninitializedComponents { get; }
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        /// <summary>
        /// Adds a <see cref="Komodo.Core.ECS.Entities.Entity"/> to the Drawable3DSystem if the <see cref="Komodo.Core.ECS.Entities.Entity"/> is not already present.
        /// </summary>
        /// <param name="entityToAdd"><see cref="Komodo.Core.ECS.Entities.Entity"/> to add.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Entities.Entity"/> was added to this Drawable3DSystem's <see cref="Entites"/>. Returns false if the <see cref="Komodo.Core.ECS.Entities.Entity"/> already existed.</returns>
        public bool AddEntity([NotNull] Entity entityToAdd)
        {
            if (Entities == null)
            {
                Entities = new Dictionary<Guid, Entity>();
            }
            if (Entities.ContainsKey(entityToAdd.ID))
            {
                return false;
            }
            if (entityToAdd.Render3DSystem != null)
            {
                entityToAdd.Render3DSystem.RemoveEntity(entityToAdd.ID);
            }
            Entities[entityToAdd.ID] = entityToAdd;
            foreach (var component in entityToAdd.Components)
            {
                switch (component)
                {
                    case Drawable3DComponent componentToAdd:
                        AddComponent(componentToAdd);
                        break;
                    default:
                        continue;
                }
            }
            return true;
        }

        /// <summary>
        /// Removes all <see cref="Komodo.Core.ECS.Entities.Entity"/> objects from the Drawable3DSystem.
        /// </summary>
        public void ClearEntities()
        {
            if (Entities != null)
            {
                foreach (var entityID in Entities.Keys)
                {
                    RemoveEntity(entityID);
                }
                Entities.Clear();
            }
        }
        
        /// <summary>
        /// Initializes the Drawable3DSystem and all tracked <see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/> objects.
        /// </summary>
        public void Initialize()
        {
            if (!IsInitialized)
            {
                IsInitialized = true;
                InitializeComponents();
            }
        }

        /// <summary>
        /// Runs any operations needed at the end of the <see cref="Komodo.Core.Game.Update(GameTime)"/> loop.
        /// </summary>
        /// <remarks>
        /// Will initialize any new uninitialized <see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/> objects.
        /// </remarks>
        /// <param name="_">Time passed since last <see cref="Komodo.Core.Game.Update(GameTime)"/>.</param>
        public void PostUpdate(GameTime _)
        {
            InitializeComponents();
        }

        /// <summary>
        /// Runs any operations needed at the beginning of the <see cref="Komodo.Core.Game.Update(GameTime)"/> loop.
        /// </summary>
        /// <remarks>
        /// Will initialize any new uninitialized <see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/> objects.
        /// </remarks>
        /// <param name="_">Time passed since last <see cref="Komodo.Core.Game.Update(GameTime)"/>.</param>
        public void PreUpdate(GameTime _)
        {
            InitializeComponents();
        }

        /// <summary>
        /// Removes a <see cref="Komodo.Core.ECS.Entities.Entity"/> from the Drawable3DSystem, including all the <see cref="Komodo.Core.ECS.Entities.Entity"/>'s <see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/> objects.
        /// </summary>
        /// <param name="entityID">Unique identifier for the <see cref="Komodo.Core.ECS.Entities.Entity"/>.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Entities.Entity"/> was removed from this Drawable3DSystem's <see cref="Entities"/>. Will return false if the <see cref="Komodo.Core.ECS.Entities.Entity"/> is not present in <see cref="Entities"/>.</returns>
        public bool RemoveEntity(Guid entityID)
        {
            if (Entities != null && Entities.ContainsKey(entityID))
            {
                return RemoveEntity(Entities[entityID]);
            }
            return false;
        }

        /// <summary>
        /// Removes a <see cref="Komodo.Core.ECS.Entities.Entity"/> from the Drawable3DSystem, including all the <see cref="Komodo.Core.ECS.Entities.Entity"/>'s <see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/> objects.
        /// </summary>
        /// <param name="entityToRemove"><see cref="Komodo.Core.ECS.Entities.Entity"/> to remove.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Entities.Entity"/> was removed from this Drawable3DSystem's <see cref="Entities"/>. Will return false if the <see cref="Komodo.Core.ECS.Entities.Entity"/> is not present in <see cref="Entities"/>.</returns>
        public bool RemoveEntity(Entity entityToRemove)
        {
            if (Entities != null && Entities.ContainsKey(entityToRemove.ID))
            {
                foreach (var component in entityToRemove.Components)
                {
                    switch (component)
                    {
                        case Drawable3DComponent componentToRemove:
                            RemoveComponent(componentToRemove);
                            break;
                        default:
                            continue;
                    }
                }
                return Entities.Remove(entityToRemove.ID);
            }
            return false;
        }
        #endregion Public Member Methods

        #region Internal Member Methods
        /// <summary>
        /// Adds a <see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/> to relevant <see cref="Components"/>. If the <see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/> is not initialized, it will be queued for initialization.
        /// </summary>
        /// <param name="componentToAdd"><see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/> to add.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/> was added to this Drawable3DSystem's <see cref="Components"/>. Returns false if the <see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/> already existed.</returns>
        internal bool AddComponent(Drawable3DComponent componentToAdd)
        {
            if (!componentToAdd.IsInitialized)
            {
                _uninitializedComponents.Enqueue(componentToAdd);
            }
            var parent = componentToAdd.Parent;
            if (!Entities.ContainsKey(parent.ID))
            {
                return AddEntity(parent);
            }
            else
            {
                return AddDrawable3DComponent(componentToAdd);
            }
        }

        /// <summary>
        /// Renders all <see cref="Components"/>.
        /// </summary>
        internal void DrawComponents()
        {
            var graphicsManager = Game.GraphicsManager;
            graphicsManager.GraphicsDeviceManager.GraphicsDevice.BlendState = BlendState.Opaque;
            graphicsManager.GraphicsDeviceManager.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            graphicsManager.GraphicsDeviceManager.GraphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;
            graphicsManager.GraphicsDeviceManager.GraphicsDevice.SamplerStates[0] = TextureFilter;
            try
            {
                var componentsToDraw = Components.ToArray();
                foreach (var component in componentsToDraw)
                {
                    if (component.Parent.IsEnabled && component.IsEnabled)
                    {
                        DrawComponent(component);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Removes an individual <see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/> from this Drawable3DSystem's <see cref="Components"/>.
        /// </summary>
        /// <param name="componentToRemove"><see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/> to remove.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/> was removed from this Drawable3DSystem's <see cref="Components"/>. Will return false if the <see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/> is not present in <see cref="Components"/>.</returns>
        internal bool RemoveComponent(Drawable3DComponent componentToRemove)
        {
            return RemoveDrawable3DComponent(componentToRemove);
        }
        #endregion Internal Member Methods

        #region Private Member Methods
        /// <summary>
        /// Adds a <see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/> to relevant <see cref="Components"/>. If the <see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/> is not initialized, it will be queued for initialization.
        /// </summary>
        /// <param name="componentToAdd"><see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/> to add.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/> was added to this Drawable3DSystem's <see cref="Components"/>. Returns false if the <see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/> already existed.</returns>
        private bool AddDrawable3DComponent([NotNull] Drawable3DComponent componentToAdd)
        {
            if (Components.Contains(componentToAdd))
            {
                return false;
            }
            Components.Add(componentToAdd);
            return true;
        }

        /// <summary>
        /// Renders the given <see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/>.
        /// </summary>
        /// <param name="component"><see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/> to render.</param>
        private void DrawComponent(Drawable3DComponent component)
        {
            var position = component.WorldPosition;
            var rotationQuaternion = component.RotationQuaternion;
            var scale = component.Scale;
            if (ActiveCamera != null)
            {
                var bounds = component.BoundingBox;
                if (ActiveCamera.BoundingFrustum.Contains(bounds) == ContainmentType.Disjoint)
                {
                    return;
                }
            }
            var positionMatrix = Matrix.CreateTranslation(position.MonoGameVector);

            foreach (var mesh in component.ModelData.MonoGameModel.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.Texture = component.Texture?.MonoGameTexture;
                    effect.TextureEnabled = effect.Texture != null;
                    effect.DiffuseColor = component.DiffuseColor.ToVector3();

                    effect.Projection = ActiveCamera != null ? ActiveCamera.Projection : Matrix.Identity;
                    effect.View = ActiveCamera != null ? ActiveCamera.ViewMatrix : Matrix.Identity;
                    effect.World = (
                        Matrix.CreateScale(scale.MonoGameVector)
                        * Matrix.CreateFromQuaternion(rotationQuaternion)
                        * positionMatrix
                    );
                }

                mesh.Draw();
            }
        }

        /// <summary>
        /// Initializes all uninitialized <see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/>.
        /// </summary>
        private void InitializeComponents()
        {
            while (_uninitializedComponents.Count > 0)
            {
                var component = _uninitializedComponents.Dequeue();
                if (!component.IsInitialized)
                {
                    component.IsInitialized = true;
                    if (component.ModelPath != null)
                    {
                        var loadedModel = Game.Content.Load<Microsoft.Xna.Framework.Graphics.Model>(component.ModelPath);
                        component.ModelData = new Model(loadedModel);
                    }
                    if (component.Texture == null && component.TexturePath != null)
                    {
                        var loadedTexture = Game.Content.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(component.TexturePath);
                        component.Texture = new Texture(loadedTexture);
                    }
                }
            }
        }

        /// <summary>
        /// Removes an individual <see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/> from this Drawable3DSystem's <see cref="Components"/>.
        /// </summary>
        /// <param name="componentToRemove"><see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/> to remove.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/> was removed from this Drawable3DSystem's <see cref="Components"/>. Will return false if the <see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/> is not present in <see cref="Components"/>.</returns>
        private bool RemoveDrawable3DComponent([NotNull] Drawable3DComponent componentToRemove)
        {
            return Components.Remove(componentToRemove);
        }
        #endregion Private Member Methods

        #endregion Member Methods
    }
}