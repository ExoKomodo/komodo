using Komodo.Core.ECS.Components;
using Komodo.Core.ECS.Entities;
using Komodo.Core.Engine.Graphics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System;
using System.Linq;

namespace Komodo.Core.ECS.Systems
{
    public class Render2DSystem
    {
        #region Constructors
        public Render2DSystem(KomodoGame game)
        {
            Components = new List<Drawable2DComponent>();
            Entities = new Dictionary<Guid, Entity>();
            Game = game;
            _uninitializedComponents = new Queue<Drawable2DComponent>();
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public CameraComponent ActiveCamera { get; set; }
        public List<Drawable2DComponent> Components { get; private set; }
        public Dictionary<Guid, Entity> Entities { get; set; }
        public KomodoGame Game { get; set; }
        public bool IsInitialized { get; private set; }
        #endregion Public Members

        #region Protected Members
        protected Queue<Drawable2DComponent> _uninitializedComponents { get; }
        #endregion Protected Members

        #region Private Members
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        public bool AddComponent(Drawable2DComponent componentToAdd)
        {
            if (!componentToAdd.IsInitialized)
            {
                _uninitializedComponents.Enqueue(componentToAdd);
            }
            return AddDrawable2DComponent(componentToAdd);
        }

        public bool AddEntity([NotNull] Entity entityToAdd)
        {
            if (Entities == null)
            {
                Entities = new Dictionary<Guid, Entity>();
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

        internal void DrawComponents(SpriteBatch spriteBatch)
        {
            if (Components != null)
            {
                DrawComponents(Components, spriteBatch, drawBillboards: false, shader: Game.DefaultSpriteShader);
                DrawComponents(Components, spriteBatch, drawBillboards: true, shader: Game.DefaultSpriteShader);
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

        public void PostUpdate(GameTime gameTime)
        {
            InitializeComponents();
        }
        public void PreUpdate(GameTime gameTime)
        {
            InitializeComponents();
        }

        public bool RemoveComponent(Drawable2DComponent componentToRemove)
        {
            return RemoveDrawable2DComponent(componentToRemove);
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
                        case Drawable2DComponent componentToRemove:
                            RemoveComponent(componentToRemove);
                            break;
                        default:
                            continue;
                    }
                }
                entityToRemove.Render2DSystem = null;
                return Entities.Remove(entityID);
            }
            return false;
        }
        #endregion Public Member Methods

        #region Private Member Methods
        private bool AddDrawable2DComponent([NotNull] Drawable2DComponent componentToAdd)
        {
            if (Components.Contains(componentToAdd))
            {
                return false;
            }
            Components.Add(componentToAdd);
            return true;
        }

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
                    SpriteSortMode.BackToFront,
                    null,
                    null,
                    DepthStencilState.DepthRead,
                    RasterizerState.CullNone,
                    shader
                );
                var componentsToDraw = components.ToArray();
                Array.ForEach(componentsToDraw, component => {
                    if (component.Parent.IsEnabled && component.IsEnabled && component.IsBillboard == drawBillboards)
                    {
                        DrawComponent(component, spriteBatch);
                    }
                });
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

        protected void DrawComponent(Drawable2DComponent component, SpriteBatch spriteBatch)
        {
            var position = component.WorldPosition;
            var rotation = component.Rotation;
            var scale = component.Scale;
            if (ActiveCamera != null)
            {
                if (component.IsBillboard)
                {
                    position = KomodoVector3.Transform(
                        position,
                        ActiveCamera.ViewMatrix * Matrix.CreateScale(1f, -1f, 1f)
                    );
                }
                else
                {
                    position = KomodoVector3.Transform(
                        position,
                        Matrix.CreateScale(1f, -1f, 1f)
                    );
                }
                rotation += ActiveCamera.Rotation;
                scale *= ActiveCamera.Zoom;
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
                        textComponent.IsCentered ? textComponent.Center.MonoGameVector : KomodoVector2.Zero.MonoGameVector,
                        scale.XY.MonoGameVector,
                        SpriteEffects.None,
                        position.Z
                    );
                    break;
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
                    switch (component)
                    {
                        case SpriteComponent spriteComponent:
                            var loadedTexture = KomodoGame.Content.Load<Texture2D>(spriteComponent.TexturePath);
                            spriteComponent.Texture = new KomodoTexture(loadedTexture);
                            break;
                        case TextComponent textComponent:
                            var loadedFont = KomodoGame.Content.Load<SpriteFont>(textComponent.FontPath);
                            textComponent.Font = loadedFont;
                            break;
                    }
                }
            }
        }

        protected bool RemoveDrawable2DComponent([NotNull] Drawable2DComponent componentToRemove)
        {
            return Components.Remove(componentToRemove);
        }
        #endregion Protected Member Methods

        #region Private Member Methods
        #endregion Private Member Methods

        #endregion Member Methods
    }
}