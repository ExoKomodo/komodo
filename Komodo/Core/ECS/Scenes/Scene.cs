using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Komodo.Core.ECS.Entities;
using Komodo.Core.ECS.Components;

namespace Komodo.Core.ECS.Scenes
{
    public class Scene
    {
        #region Constructors
        public Scene(KomodoGame game)
        {
            Children = new List<Scene>();
            Entities = new List<Entity>();
            Game = game;
            _drawable2DComponents = new Dictionary<Effect, List<Drawable2DComponent>>();
            _drawable3DComponents = new List<Component>();
            _physicsComponents = new List<Component>();
            _updatableComponents = new List<Component>();
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public CameraComponent ActiveCamera { get; set; }
        public List<Scene> Children
        {
            get
            {
                return _children;
            }
            set
            {
                _children = value;
            }
        }
        public List<Entity> Entities
        {
            get
            {
                return _entities;
            }
            set
            {
                _entities = value;
            }
        }
        public KomodoGame Game { get; set; }
        #endregion Public Members

        #region Protected Members
        protected List<Scene> _children;
        protected List<Entity> _entities;
        protected Dictionary<Effect, List<Drawable2DComponent>> _drawable2DComponents { get; }
        protected List<Component> _drawable3DComponents { get; }
        protected List<Component> _physicsComponents { get; }
        protected List<Component> _updatableComponents { get; }
        #endregion Protected Members

        #region Private Members
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Internal Member Methods
        public bool AddComponent(Component componentToAdd)
        {
            return componentToAdd switch
            {
                Drawable2DComponent component => AddDrawable2DComponent(component),
                BehaviorComponent component => AddUpdatableComponent(component),
                CameraComponent component => AddUpdatableComponent(component),
                SoundComponent component => AddUpdatableComponent(component),
                _ => false,
            };
        }

        public bool RemoveComponent(Component componentToRemove)
        {
            return componentToRemove switch
            {
                Drawable2DComponent component => RemoveDrawable2DComponent(component),
                BehaviorComponent component => RemoveUpdatableComponent(component),
                CameraComponent component => RemoveUpdatableComponent(component),
                SoundComponent component => RemoveUpdatableComponent(component),
                _ => false,
            };
        }
        #endregion Internal Member Methods

        #region Public Member Methods
        public bool AddEntity(Entity entityToAdd)
        {
            try
            {
                if (Entities == null)
                {
                    Entities = new List<Entity>();
                }
                if (entityToAdd.ParentScene != null)
                {
                    entityToAdd.ParentScene.RemoveEntity(entityToAdd);
                }
                Entities.Add(entityToAdd);
                entityToAdd.ParentScene = this;
                foreach (var component in entityToAdd.Components)
                {
                    AddComponent(component);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void ClearEntities()
        {
            if (Entities != null)
            {
                var entitiesToRemove = Entities.ToArray();
                foreach (var entity in entitiesToRemove)
                {
                    RemoveEntity(entity);
                }
                Entities.Clear();
            }
        }

        public void Deserialize(SerializedObject serializedObject)
        {
            var type = Type.GetType(serializedObject.Type);
            if (type == this.GetType())
            {
                Entities = new List<Entity>();

                if (serializedObject.Properties.ContainsKey("Entities"))
                {
                    var obj = serializedObject.Properties["Entities"];
                    if (obj is List<Entity>)
                    {
                        var entities = obj as List<Entity>;
                        foreach (var entity in entities)
                        {
                            entity.ParentScene = this;
                            this.AddEntity(entity);
                        }
                    }
                }
            }
            else
            {
                // TODO: Add InvalidTypeException to Deserialize
                throw new Exception("Not correct type");
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_drawable2DComponents != null)
            {
                foreach (KeyValuePair<Effect, List<Drawable2DComponent>> pair in _drawable2DComponents)
                {
                    var shader = pair.Key;
                    var components = pair.Value;
                    Draw2DComponents(components, spriteBatch, shader);
                }
            }
            if (Children != null)
            {
                foreach (var child in Children)
                {
                    child.Draw(spriteBatch);
                }
            }
        }

        public void PostUpdate(GameTime gameTime)
        {
            if (Children != null)
            {
                foreach (var child in Children)
                {
                    child.PostUpdate(gameTime);
                }
            }
        }
        public void PreUpdate(GameTime gameTime)
        {
            if (Children != null)
            {
                foreach (var child in Children)
                {
                    child.PreUpdate(gameTime);
                }
            }
        }

        public bool RemoveEntity(Entity entityToRemove)
        {
            if (Entities != null)
            {
                foreach (var component in entityToRemove.Components)
                {
                    RemoveComponent(component);
                }
                entityToRemove.ParentScene = null;
                return Entities.Remove(entityToRemove);
            }
            return false;
        }

        public SerializedObject Serialize()
        {
            var serializedObject = new SerializedObject
            {
                Type = this.GetType().ToString()
            };

            var entities = new List<SerializedObject>();
            foreach (var entity in Entities)
            {
                entities.Add(entity.Serialize());
            }
            serializedObject.Properties["Entities"] = entities;

            return serializedObject;
        }

        public void Update(GameTime gameTime)
        {
            if (_updatableComponents != null)
            {
                int i = 0;
                while (_updatableComponents.Count > i)
                {
                    var component = _updatableComponents[i];
                    if (component.Parent.IsEnabled && component.IsEnabled)
                    {
                        component.Update(gameTime);
                    }
                    i++;
                }
            }
            if (Children != null)
            {
                foreach (var child in Children)
                {
                    child.Update(gameTime);
                }
            }
        }
        #endregion Public Member Methods

        #region Protected Member Methods
        protected bool AddPhysicsComponent(Component componentToAdd)
        {
            try
            {
                _physicsComponents.Add(componentToAdd);
                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
                return false;
            }
        }

        protected bool AddDrawable2DComponent(Drawable2DComponent componentToAdd)
        {
            try
            {
                var shader = componentToAdd.Shader;
                if (!_drawable2DComponents.ContainsKey(shader))
                {
                    _drawable2DComponents[shader] = new List<Drawable2DComponent>();
                }
                _drawable2DComponents[shader].Add(componentToAdd);
                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
                return false;
            }
        }

        protected bool AddDrawable3DComponent(Component componentToAdd)
        {
            try
            {
                _drawable3DComponents.Add(componentToAdd);
                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
                return false;
            }
        }

        protected bool AddUpdatableComponent(Component componentToAdd)
        {
            try
            {
                _updatableComponents.Add(componentToAdd);
                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
                return false;
            }
        }

        protected void Draw2DComponents(
            IEnumerable<Drawable2DComponent> components,
            SpriteBatch spriteBatch,
            Effect shader = null
        )
        {
            var oldViewMatrix = Matrix.Identity;
            var oldWorldMatrix = Matrix.Identity;
            Game.DefaultSpriteShader.Projection = ActiveCamera.Projection;
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
                        if (ActiveCamera.IsPerspective)
                        {
                            effect.World = Matrix.CreateScale(1f, -1f, 1f);
                        }
                        else
                        {
                            effect.World = Matrix.CreateScale(1f, 1f, 1f);
                        }
                        effect.View = Matrix.Identity;
                        effect.Projection = ActiveCamera.Projection;
                        break;
                    case SpriteEffect _:
                    case null:
                    default:
                        break;
                }
                spriteBatch.Begin(
                    SpriteSortMode.FrontToBack,
                    null,
                    null,
                    DepthStencilState.DepthRead,
                    RasterizerState.CullNone,
                    shader
                );
                foreach (var component in components)
                {
                    if (component.Parent.IsEnabled && component.IsEnabled)
                    {
                        component.Draw(spriteBatch);
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

        protected bool RemoveDrawable3DComponent(Component componentToRemove)
        {
            try
            {
                return _drawable3DComponents.Remove(componentToRemove);
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected bool RemovePhysicsComponent(Component componentToRemove)
        {
            try
            {
                return _updatableComponents.Remove(componentToRemove);
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected bool RemoveDrawable2DComponent(Drawable2DComponent componentToRemove)
        {
            try
            {
                var shader = componentToRemove.Shader;
                if (!_drawable2DComponents.ContainsKey(shader))
                {
                    return false;
                }
                return _drawable2DComponents[shader].Remove(componentToRemove);
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected bool RemoveUpdatableComponent(Component componentToRemove)
        {
            try
            {
                return _updatableComponents.Remove(componentToRemove);
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion Protected Member Methods

        #region Private Member Methods
        #endregion Private Member Methods

        #endregion Member Methods
    }
}