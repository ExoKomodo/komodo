using System.Collections.Generic;
using System.Text.Json.Serialization;
using Komodo.Core.Engine.Components;
using Komodo.Core.Engine.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Komodo.Core.Engine.Entities
{
    public class Entity : IEntity
    {
        #region Constructors
        public Entity()
        {
            Children = new List<IEntity>();
            Components = new List<IComponent>();
            ParentEntity = null;
            ParentScene = null;
            Position = Vector3.Zero;
            Rotation = 0.0f;
            Scale = Vector2.One;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public List<IEntity> Children
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
        public List<IComponent> Components
        {
            get
            {
                return _components;
            }
            protected set
            {
                _components = value;
            }
        }
        [JsonIgnore]
        public IEntity ParentEntity
        {
            get
            {
                return _parentEntity;
            }
            set
            {
                _parentEntity = value;
            }
        }
        [JsonIgnore]
        public IScene ParentScene
        {
            get
            {
                return _parentScene;
            }
            set
            {
                _parentScene = value;
            }
        }
        public Vector3 Position { get; set; }
        public float Rotation { get; set; }
        public Vector2 Scale { get; set; }
        #endregion Public Members

        #region Protected Members
        protected List<IEntity> _children;
        protected List<IComponent> _components;
        protected IEntity _parentEntity;
        protected IScene _parentScene;
        #endregion Protected Members

        #region Private Members
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        public void AddComponent(IComponent componentToAdd)
        {
            if (Components == null)
            {
                Components = new List<IComponent>();
            }
            if (componentToAdd.Parent != null)
            {
                componentToAdd.Parent.RemoveComponent(componentToAdd);
            }
            Components.Add(componentToAdd);
            componentToAdd.Parent = this;
        }
        public void ClearComponents()
        {
            foreach (var component in Components)
            {
                component.Parent = null;
            }
            Components.Clear();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (Children != null)
            {
                foreach (var child in Children)
                {
                    child.Draw(spriteBatch);
                }
            }

            if (Components != null)
            {
                foreach (var component in Components)
                {
                    component.Draw(spriteBatch);
                }
            }
        }
        public bool RemoveComponent(IComponent componentToRemove)
        {
            if (Components != null)
            {
                componentToRemove.Parent = null;
                return Components.Remove(componentToRemove);
            }
            return false;
        }
        public void Update(GameTime gameTime)
        {
            if (Components != null)
            {
                foreach (var component in Components)
                {
                    component.Update(gameTime);
                }
            }
        }
        #endregion Public Member Methods

        #region Protected Member Methods
        #endregion Protected Member Methods

        #region Private Member Methods
        #endregion Private Member Methods

        #endregion Member Methods
    }
}