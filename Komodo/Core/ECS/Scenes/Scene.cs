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
        public Scene()
        {
            Entities = new List<Entity>();
            _drawable2DComponents = new Dictionary<Effect, List<Drawable2DComponent>>();
            _drawable3DComponents = new List<Component>();
            _physicsComponents = new List<Component>();
            _updatableComponents = new List<Component>();
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public CameraComponent ActiveCamera { get; set; }
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
            switch (componentToAdd)
            {
                case Drawable2DComponent component:
                    return AddDrawable2DComponent(component);
                case BehaviorComponent component:
                    return AddUpdatableComponent(component);
                case CameraComponent component:
                    return AddUpdatableComponent(component);
                case SoundComponent component:
                    return AddUpdatableComponent(component);
                case null:
                default:
                    return false;
            }
        }

        public bool RemoveComponent(Component componentToRemove)
        {
            switch (componentToRemove)
            {
                case Drawable2DComponent component:
                    return RemoveDrawable2DComponent(component);
                case BehaviorComponent component:
                    return RemoveUpdatableComponent(component);
                case CameraComponent component:
                    return RemoveUpdatableComponent(component);
                case SoundComponent component:
                    return RemoveUpdatableComponent(component);
                case null:
                default:
                    return false;
            }
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

        public void Draw(SpriteBatch spriteBatch, Matrix transformMatrix)
        {
            if (_drawable2DComponents != null)
            {
                foreach (KeyValuePair<Effect, List<Drawable2DComponent>> pair in _drawable2DComponents)
                {
                    var shader = pair.Key;
                    if (shader == Game.DefaultShader)
                    {
                        shader = null;
                    }
                    var components = pair.Value;
                    var fixedComponents = components.FindAll(x => x.Fixed);
                    var nonFixedComponents = components.FindAll(x => !x.Fixed);

                    Draw2DComponents(fixedComponents, spriteBatch, shader);
                    Draw2DComponents(nonFixedComponents, spriteBatch, shader, transformMatrix);
                }
            }
        }

        public void PostUpdate(GameTime gameTime)
        {
        }
        public void PreUpdate(GameTime gameTime)
        {
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
            var serializedObject = new SerializedObject();
            serializedObject.Type = this.GetType().ToString();

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
            catch (Exception)
            {
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
            catch (Exception)
            {
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
            catch (Exception)
            {
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
            catch (Exception)
            {
                return false;
            }
        }

        protected void Draw2DComponents(IEnumerable<Drawable2DComponent> components, SpriteBatch spriteBatch, Effect shader = null, Matrix? transformMatrix = null)
        {
            try
            {
                spriteBatch.Begin(transformMatrix: transformMatrix, effect: shader);
                foreach (var component in components)
                {
                    if (component.Parent.IsEnabled && component.IsEnabled)
                    {
                        component.Draw(spriteBatch);
                    }
                }
            }
            catch
            {

            }
            finally
            {
                spriteBatch.End();   
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