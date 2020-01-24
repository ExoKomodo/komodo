using System.Text.Json.Serialization;
using Komodo.Core.Engine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Komodo.Core.Engine.Components
{
    public abstract class BehaviorComponent : IComponent
    {
        #region Constructors
        public BehaviorComponent()
        {
            Parent = null;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        [JsonIgnore]
        public IEntity Parent {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
            }
        }
        #endregion Public Members

        #region Protected Members
        protected IEntity _parent { get; set; }
        #endregion Protected Members

        #region Private Members
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        public void Draw(SpriteBatch spriteBatch)
        {
        }
        public abstract void Update(GameTime gameTime);
        #endregion Public Member Methods

        #region Protected Member Methods
        #endregion Protected Member Methods

        #region Private Member Methods
        #endregion Private Member Methods

        #endregion Member Methods
    }
}