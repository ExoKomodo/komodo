using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Komodo.Core.Engine.Entities;
using System.Text.Json.Serialization;
using Komodo.Core.Engine.Components;
using System.Collections;

namespace Komodo.Core.Engine.Scenes
{
    public class Scene
    {
        #region Constructors
        public Scene()
        {
            Entities = new List<Entity>();
            _drawable2DComponents = new Dictionary<Effect, List<IComponent>>();
            _drawable3DComponents = new List<IComponent>();
            _physicsComponents = new List<IComponent>();
            _updatableComponents = new List<IComponent>();
        }
        #endregion Constructors

        #region Members

        #region Public Members
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
        [JsonIgnore]
        public Scene Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
            }
        }
        public KomodoGame Game { get; set; }
        #endregion Public Members

        #region Protected Members
        protected List<Entity> _entities;
        protected Scene _parent;
        protected Dictionary<Effect, List<IComponent>> _drawable2DComponents { get; }
        protected List<IComponent> _drawable3DComponents { get; }
        protected List<IComponent> _physicsComponents { get; }
        protected List<IComponent> _updatableComponents { get; }
        #endregion Protected Members

        #region Private Members
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Internal Member Methods
        public bool AddComponent(IComponent componentToAdd)
        {
            switch (componentToAdd)
            {
                case SpriteComponent component:
                    return AddSpriteComponent(component);
                case CameraComponent component:
                    return AddUpdatableComponent(component);
                case BehaviorComponent component:
                    return AddUpdatableComponent(component);
                case null:
                default:
                    return false;
            }
        }

        public bool RemoveComponent(IComponent componentToRemove)
        {
            switch (componentToRemove)
            {
                case SpriteComponent component:
                    return RemoveSpriteComponent(component);
                case CameraComponent component:
                    return RemoveUpdatableComponent(component);
                case BehaviorComponent component:
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
                Parent = null;

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
                if (serializedObject.Properties.ContainsKey("Parent"))
                {
                    Parent = serializedObject.Properties["Parent"] as Scene;
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
                foreach (KeyValuePair<Effect, List<IComponent>> pair in _drawable2DComponents)
                {
                    var shader = pair.Key;
                    if (shader == Game.DefaultShader)
                    {
                        shader = null;
                    }
                    spriteBatch.Begin(transformMatrix: transformMatrix, effect: shader);
                    try
                    {
                        var components = pair.Value;
                        int i = 0;
                        while (components.Count > i)
                        {
                            var component = components[i];
                            if (component.Parent.IsEnabled && component.IsEnabled)
                            {
                                component.Draw(spriteBatch);
                            }
                            i++;
                        }
                    }
                    catch (Exception)
                    {
                    
                    }
                    finally
                    {
                        spriteBatch.End();
                    }
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
            var serializedObject = new SerializedObject();
            serializedObject.Type = this.GetType().ToString();
            
            if (Parent != null)
            {
                serializedObject.Properties["Parent"] = Parent.Serialize();
            }
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
        protected bool AddSpriteComponent(SpriteComponent componentToAdd)
        {
            try
            {
                var shader = componentToAdd.Shader;
                if (!_drawable2DComponents.ContainsKey(shader))
                {
                    _drawable2DComponents[shader] = new List<IComponent>();
                }
                _drawable2DComponents[shader].Add(componentToAdd);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected bool AddDrawable3DComponent(IComponent componentToAdd)
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

        protected bool AddUpdatableComponent(IComponent componentToAdd)
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

        protected bool AddPhysicsComponent(IComponent componentToAdd)
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

        protected bool RemoveSpriteComponent(SpriteComponent componentToRemove)
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

        protected bool RemoveDrawable3DComponent(IComponent componentToRemove)
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

        protected bool RemoveUpdatableComponent(IComponent componentToRemove)
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

        protected bool RemovePhysicsComponent(IComponent componentToRemove)
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