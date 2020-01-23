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
            Components = new List<IComponent>();
            Position = Vector3.Zero;
            Rotation = 0.0f;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public List<IComponent> Components {
            get
            {
                return _components;
            }
            protected set
            {
                _components = value;
            }
        }
        public Entity(Vector3 position, float rotation) 
        {
            this.Position = position;
                this.Rotation = rotation;
               
        }
                public Vector3 Position { get; set; }
        public float Rotation { get; set; }
        #endregion Public Members

        #region Protected Members
        protected List<IComponent> _components;
        #endregion Protected Members

        #region Private Members
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var component in Components)
            {
                component.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var component in Components)
            {
                component.Update(gameTime);
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