using System.Collections.Generic;
using Komodo.Core.Engine.Components;
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
            Parent = null;
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
            set
            {
                _components = value;
            }
        }
        public IEntity Parent
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
        public Vector3 Position { get; set; }
        public float Rotation { get; set; }
        public Vector2 Scale { get; set; }
        #endregion Public Members

        #region Protected Members
        protected List<IEntity> _children;
        protected List<IComponent> _components;
        protected IEntity _parent;
        #endregion Protected Members

        #region Private Members
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
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