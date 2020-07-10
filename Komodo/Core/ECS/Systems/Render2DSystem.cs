using Komodo.Core.ECS.Components;
using Komodo.Core.ECS.Entities;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System;
using Komodo.Lib.Math;

using Color = Microsoft.Xna.Framework.Color;
using GameTime = Microsoft.Xna.Framework.GameTime;
using Matrix = Microsoft.Xna.Framework.Matrix;

using BasicEffect = Microsoft.Xna.Framework.Graphics.BasicEffect;
using DepthStencilState = Microsoft.Xna.Framework.Graphics.DepthStencilState;
using Effect = Microsoft.Xna.Framework.Graphics.Effect;
using RasterizerState = Microsoft.Xna.Framework.Graphics.RasterizerState;
using SamplerState = Microsoft.Xna.Framework.Graphics.SamplerState;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using SpriteEffect = Microsoft.Xna.Framework.Graphics.SpriteEffect;
using SpriteEffects = Microsoft.Xna.Framework.Graphics.SpriteEffects;
using SpriteSortMode = Microsoft.Xna.Framework.Graphics.SpriteSortMode;
using SpriteFont = Microsoft.Xna.Framework.Graphics.SpriteFont;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;

namespace Komodo.Core.ECS.Systems
{
    /// <summary>
    /// Manages all <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> objects. There can be more than one Render2DSystem per <see cref="Komodo.Core.Game"/>.
    /// </summary>
    public class Render2DSystem : ISystem<Drawable2DComponent>
    {
        #region Public

        #region Constructors
        /// <param name="game">Reference to current <see cref="Komodo.Core.Game"/> instance.</param>
        public Render2DSystem(Game game)
        {
            Components = new List<Drawable2DComponent>();
            Entities = new Dictionary<Guid, Entity>();
            Game = game;
            TextureFilter = SamplerState.PointWrap;

            _uninitializedComponents = new Queue<Drawable2DComponent>();
        }
        #endregion

        #region Members
        /// <summary>
        /// <see cref="Komodo.Core.ECS.Components.CameraComponent"/> to be used for rendering all tracked <see cref="Components"/>.
        /// </summary>
        public CameraComponent ActiveCamera { get; set; }
        
        /// <summary>
        /// All tracked <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> objects.
        /// </summary>
        public List<Drawable2DComponent> Components { get; private set; }

        /// <summary>
        /// All tracked <see cref="Komodo.Core.ECS.Entities.Entity"/> objects.
        /// </summary>
        public Dictionary<Guid, Entity> Entities { get; set; }

        /// <summary>
        /// Reference to current <see cref="Komodo.Core.Game"/> instance.
        /// </summary>
        public Game Game { get; }

        /// <summary>
        /// Whether or not the Drawable2DSystem has called <see cref="Initialize()"/>.
        /// </summary>
        public bool IsInitialized { get; private set; }

        /// <summary>
        /// Texture filtering to use for 2D sprites and fonts.
        /// </summary>
        public SamplerState TextureFilter { get; set; }
        #endregion

        #region Member Methods
        /// <summary>
        /// Adds a <see cref="Komodo.Core.ECS.Entities.Entity"/> to the Drawable2DSystem if the <see cref="Komodo.Core.ECS.Entities.Entity"/> is not already present.
        /// </summary>
        /// <param name="entityToAdd"><see cref="Komodo.Core.ECS.Entities.Entity"/> to add.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Entities.Entity"/> was added to this Drawable2DSystem's <see cref="Entites"/>. Returns false if the <see cref="Komodo.Core.ECS.Entities.Entity"/> already existed.</returns>
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
            if (entityToAdd.Render2DSystem != null)
            {
                entityToAdd.Render2DSystem.RemoveEntity(entityToAdd.ID);
            }
            Entities[entityToAdd.ID] = entityToAdd;
            foreach (var component in entityToAdd.Components)
            {
                switch (component)
                {
                    case Drawable2DComponent componentToAdd:
                        AddComponent(componentToAdd);
                        break;
                    default:
                        continue;
                }
            }
            return true;
        }

        /// <summary>
        /// Removes all <see cref="Komodo.Core.ECS.Entities.Entity"/> objects from the Drawable2DSystem.
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
        /// Initializes the Drawable2DSystem and all tracked <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> objects.
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
        /// Will initialize any new uninitialized <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> objects.
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
        /// Will initialize any new uninitialized <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> objects.
        /// </remarks>
        /// <param name="_">Time passed since last <see cref="Komodo.Core.Game.Update(GameTime)"/>.</param>
        public void PreUpdate(GameTime _)
        {
            InitializeComponents();
        }

        /// <summary>
        /// Removes a <see cref="Komodo.Core.ECS.Entities.Entity"/> from the Drawable2DSystem, including all the <see cref="Komodo.Core.ECS.Entities.Entity"/>'s <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> objects.
        /// </summary>
        /// <param name="entityID">Unique identifier for the <see cref="Komodo.Core.ECS.Entities.Entity"/>.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Entities.Entity"/> was removed from this Drawable2DSystem's <see cref="Entities"/>. Will return false if the <see cref="Komodo.Core.ECS.Entities.Entity"/> is not present in <see cref="Entities"/>.</returns>
        public bool RemoveEntity(Guid entityID)
        {
            if (Entities != null && Entities.ContainsKey(entityID))
            {
                return RemoveEntity(Entities[entityID]);
            }
            return false;
        }

        /// <summary>
        /// Removes a <see cref="Komodo.Core.ECS.Entities.Entity"/> from the Drawable2DSystem, including all the <see cref="Komodo.Core.ECS.Entities.Entity"/>'s <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> objects.
        /// </summary>
        /// <param name="entityToRemove"><see cref="Komodo.Core.ECS.Entities.Entity"/> to remove.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Entities.Entity"/> was removed from this Drawable2DSystem's <see cref="Entities"/>. Will return false if the <see cref="Komodo.Core.ECS.Entities.Entity"/> is not present in <see cref="Entities"/>.</returns>
        public bool RemoveEntity(Entity entityToRemove)
        {
            if (Entities != null && Entities.ContainsKey(entityToRemove.ID))
            {
                foreach (var component in entityToRemove.Components)
                {
                    switch (component)
                    {
                        case Drawable2DComponent componentToRemove:
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
        #endregion

        #endregion

        #region Internal

        #region Member Methods
        /// <summary>
        /// Adds a <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> to relevant <see cref="Components"/>. If the <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> is not initialized, it will be queued for initialization.
        /// </summary>
        /// <param name="componentToAdd"><see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> to add.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> was added to this Drawable2DSystem's <see cref="Components"/>. Returns false if the <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> already existed.</returns>
        internal bool AddComponent(Drawable2DComponent componentToAdd)
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
                return AddDrawable2DComponent(componentToAdd);
            }
        }

        /// <summary>
        /// Renders all <see cref="Components"/>. This is done in two passes, first for non-billboarded <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> objects, and a second pass for billboards.
        /// </summary>
        /// <param name="spriteBatch"><see cref="Microsoft.Xna.Framework.Graphics.SpriteBatch"/> to render with.</param>
        internal void DrawComponents(SpriteBatch spriteBatch)
        {
            if (Components != null)
            {
                DrawComponents(Components, spriteBatch, drawBillboards: false, shader: Game.DefaultSpriteShader);
                DrawComponents(Components, spriteBatch, drawBillboards: true, shader: Game.DefaultSpriteShader);
            }
        }

        /// <summary>
        /// Removes an individual <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> from this Drawable2DSystem's <see cref="Components"/>.
        /// </summary>
        /// <param name="componentToRemove"><see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> to remove.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> was removed from this Drawable2DSystem's <see cref="Components"/>. Will return false if the <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> is not present in <see cref="Components"/>.</returns>
        internal bool RemoveComponent(Drawable2DComponent componentToRemove)
        {
            return RemoveDrawable2DComponent(componentToRemove);
        }
        #endregion

        #endregion

        #region Private

        #region Members
        /// <summary>
        /// Tracks all potentially uninitialized <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> objects.
        /// All <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> objects will be initialized in the <see cref="Initialize"/>, <see cref="PreUpdate(GameTime)"/>, or <see cref="PostUpdate(GameTime)"/> methods.
        /// </summary>
        private Queue<Drawable2DComponent> _uninitializedComponents { get; }
        #endregion

        #region Member Methods
        /// <summary>
        /// Adds a <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> to relevant <see cref="Components"/>. If the <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> is not initialized, it will be queued for initialization.
        /// </summary>
        /// <param name="componentToAdd"><see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> to add.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> was added to this Drawable2DSystem's <see cref="Components"/>. Returns false if the <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> already existed.</returns>
        private bool AddDrawable2DComponent([NotNull] Drawable2DComponent componentToAdd)
        {
            if (Components.Contains(componentToAdd))
            {
                return false;
            }
            Components.Add(componentToAdd);
            return true;
        }

        /// <summary>
        /// Renders the given <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> objects.
        /// </summary>
        /// <param name="components"><see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> objects to render.</param>
        /// <param name="spriteBatch"><see cref="Microsoft.Xna.Framework.Graphics.SpriteBatch"/> to render with.</param>
        /// <param name="drawBillboards">Whether or not to billboard the <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/>.</param>
        /// <param name="shader">Shader to render with.</param>
        private void DrawComponents(
            [NotNull] IEnumerable<Drawable2DComponent> components,
            [NotNull] SpriteBatch spriteBatch,
            bool drawBillboards = false,
            Effect shader = null
        )
        {
            var oldViewMatrix = Matrix.Identity;
            var oldWorldMatrix = Matrix.Identity;
            switch (shader)
            {
                case BasicEffect effect:
                    oldViewMatrix = effect.View;
                    oldWorldMatrix = effect.World;
                    break;
                case SpriteEffect _:
                case null:
                default:
                    break;
            }
            try
            {
                switch (shader)
                {
                    case BasicEffect effect:
                        effect.Projection = ActiveCamera != null ? ActiveCamera.Projection : Matrix.Identity;
                        
                        if (drawBillboards)
                        {
                            effect.View = Matrix.Identity;
                        }
                        else
                        {
                            effect.View = ActiveCamera != null ? ActiveCamera.ViewMatrix : Matrix.Identity;
                        }
                        if (ActiveCamera != null && ActiveCamera.IsPerspective)
                        {
                            effect.World = Matrix.CreateScale(1f, -1f, 1f);
                        }
                        else
                        {
                            effect.World = Matrix.CreateScale(1f, 1f, 1f);
                        }
                        break;
                    case SpriteEffect _:
                    case null:
                    default:
                        break;
                }
                spriteBatch.Begin(
                    SpriteSortMode.FrontToBack,
                    null,
                    TextureFilter,
                    DepthStencilState.DepthRead,
                    RasterizerState.CullNone,
                    shader
                );
                foreach (var component in components)
                {
                    if (component.IsEnabled && component.Parent != null && component.Parent.IsEnabled && component.IsBillboard == drawBillboards)
                    {
                        DrawComponent(component, spriteBatch);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
            }
            finally
            {
                spriteBatch.End();
                switch (shader)
                {
                    case BasicEffect effect:
                        effect.View = oldViewMatrix;
                        effect.World = oldWorldMatrix;
                        break;
                    case SpriteEffect _:
                    case null:
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Draws the individual <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/>.
        /// </summary>
        /// <param name="component"><see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> to render.</param>
        /// <param name="spriteBatch"><see cref="Microsoft.Xna.Framework.Graphics.SpriteBatch"/> to render with.</param>
        private void DrawComponent(Drawable2DComponent component, SpriteBatch spriteBatch)
        {
            var position = component.WorldPosition;
            var rotation = component.Rotation;
            var scale = component.Scale;
            if (ActiveCamera != null)
            {
                if (component.IsBillboard)
                {
                    position = Vector3.Transform(
                        position,
                        ActiveCamera.ViewMatrix * Matrix.CreateScale(1f, -1f, 1f)
                    );
                }
                else
                {
                    position = Vector3.Transform(
                        position,
                        Matrix.CreateScale(1f, -1f, 1f)
                    );
                }
            }
            
            switch (component)
            {
                case SpriteComponent spriteComponent:
                    spriteBatch.Draw(
                        spriteComponent.Texture.MonoGameTexture,
                        position.XY.MonoGameVector,
                        null,
                        Color.White,
                        -rotation.Z,
                        spriteComponent.Center.MonoGameVector,
                        scale.XY.MonoGameVector,
                        SpriteEffects.None,
                        position.Z
                    );
                    break;
                case TextComponent textComponent:
                    spriteBatch.DrawString(
                        textComponent.Font,
                        textComponent.Text,
                        position.XY.MonoGameVector,
                        textComponent.Color,
                        -rotation.Z,
                        textComponent.IsCentered ? textComponent.Center.MonoGameVector : Vector2.Zero.MonoGameVector,
                        scale.XY.MonoGameVector,
                        SpriteEffects.None,
                        position.Z
                    );
                    break;
            }
        }

        /// <summary>
        /// Initializes all uninitialized <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/>.
        /// </summary>
        private void InitializeComponents()
        {
            while (_uninitializedComponents.Count > 0)
            {
                var component = _uninitializedComponents.Dequeue();
                if (!component.IsInitialized)
                {
                    component.IsInitialized = true;
                    switch (component)
                    {
                        case SpriteComponent spriteComponent:
                            if (spriteComponent.TexturePath != null)
                            {
                                var loadedTexture = Game.Content.Load<Texture2D>(spriteComponent.TexturePath);
                                spriteComponent.Texture = new Engine.Graphics.Texture(loadedTexture);
                            }
                            break;
                        case TextComponent textComponent:
                            if (textComponent.FontPath != null)
                            {
                                var loadedFont = Game.Content.Load<SpriteFont>(textComponent.FontPath);
                                textComponent.Font = loadedFont;
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Removes an individual <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> from this Drawable2DSystem's <see cref="Components"/>.
        /// </summary>
        /// <param name="componentToRemove"><see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> to remove.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> was removed from this Drawable2DSystem's <see cref="Components"/>. Will return false if the <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> is not present in <see cref="Components"/>.</returns>
        private bool RemoveDrawable2DComponent([NotNull] Drawable2DComponent componentToRemove)
        {
            return Components.Remove(componentToRemove);
        }
        #endregion

        #endregion
    }
}