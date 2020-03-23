using Komodo.Core.ECS.Components;
using Komodo.Core.ECS.Entities;
using Komodo.Core.Engine.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System;

using GameTime = Microsoft.Xna.Framework.GameTime;
using Matrix = Microsoft.Xna.Framework.Matrix;

using BasicEffect = Microsoft.Xna.Framework.Graphics.BasicEffect;
using BlendState = Microsoft.Xna.Framework.Graphics.BlendState;
using DepthStencilState = Microsoft.Xna.Framework.Graphics.DepthStencilState;
using RasterizerState = Microsoft.Xna.Framework.Graphics.RasterizerState;
using SamplerState = Microsoft.Xna.Framework.Graphics.SamplerState;

namespace Komodo.Core.ECS.Systems
{
    public class Render3DSystem
    {
        #region Constructors
        public Render3DSystem(Game game)
        {
            Components = new List<Drawable3DComponent>();
            Entities = new Dictionary<Guid, Entity>();
            Game = game;
            _uninitializedComponents = new Queue<Drawable3DComponent>();
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public CameraComponent ActiveCamera { get; set; }
        public List<Drawable3DComponent> Components { get; private set; }
        public Dictionary<Guid, Entity> Entities { get; set; }
        public Game Game { get; set; }
        public bool IsInitialized { get; private set; }
        #endregion Public Members

        #region Protected Members
        protected Queue<Drawable3DComponent> _uninitializedComponents { get; }
        #endregion Protected Members

        #region Private Members
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        public bool AddComponent(Drawable3DComponent componentToAdd)
        {
            if (!componentToAdd.IsInitialized)
            {
                _uninitializedComponents.Enqueue(componentToAdd);
            }
            return AddDrawable3DComponent(componentToAdd);
        }

        public bool AddEntity([NotNull] Entity entityToAdd)
        {
            if (Entities == null)
            {
                Entities = new Dictionary<Guid, Entity>();
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

        internal void DrawComponents()
        {
            var graphicsManager = Game.GraphicsManager;
            graphicsManager.GraphicsDeviceManager.GraphicsDevice.BlendState = BlendState.Opaque;
            graphicsManager.GraphicsDeviceManager.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            graphicsManager.GraphicsDeviceManager.GraphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;
            graphicsManager.GraphicsDeviceManager.GraphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;
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

        public void Initialize()
        {
            if (!IsInitialized)
            {
                IsInitialized = true;
                InitializeComponents();
            }
        }

        public void PostUpdate(GameTime _)
        {
            InitializeComponents();
        }
        public void PreUpdate(GameTime _)
        {
            InitializeComponents();
        }

        public bool RemoveComponent(Drawable3DComponent componentToRemove)
        {
            return RemoveDrawable3DComponent(componentToRemove);
        }

        public bool RemoveEntity(Guid entityID)
        {
            if (Entities != null && Entities.ContainsKey(entityID))
            {
                var entityToRemove = Entities[entityID];
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
                entityToRemove.Render3DSystem = null;
                return Entities.Remove(entityID);
            }
            return false;
        }
        #endregion Public Member Methods

        #region Private Member Methods
        private bool AddDrawable3DComponent([NotNull] Drawable3DComponent componentToAdd)
        {
            if (Components.Contains(componentToAdd))
            {
                return false;
            }
            Components.Add(componentToAdd);
            return true;
        }

        private void DrawComponent(Drawable3DComponent component)
        {
            var position = component.WorldPosition;
            var rotationQuaternion = component.RotationQuaternion;
            var scale = component.Scale;
            if (ActiveCamera != null)
            {
                rotationQuaternion *= ActiveCamera.RotationQuaternion;
                scale *= ActiveCamera.Zoom;
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

        private void InitializeComponents()
        {
            while (_uninitializedComponents.Count > 0)
            {
                var component = _uninitializedComponents.Dequeue();
                if (!component.IsInitialized)
                {
                    component.IsInitialized = true;
                    var loadedModel = Game.Content.Load<Microsoft.Xna.Framework.Graphics.Model>(component.ModelPath);
                    component.ModelData = new Model(loadedModel);
                }
            }
        }

        private bool RemoveDrawable3DComponent([NotNull] Drawable3DComponent componentToRemove)
        {
            return Components.Remove(componentToRemove);
        }
        #endregion Protected Member Methods

        #region Private Member Methods
        #endregion Private Member Methods

        #endregion Member Methods
    }
}