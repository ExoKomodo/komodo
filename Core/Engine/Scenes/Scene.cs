using System.Collections.Generic;
using Komodo.Core.Engine.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Komodo.Core.Engine.Entities;

namespace Komodo.Core.Engine.Scenes
{
    public class Scene : IScene
    {
        #region Constructors
        public Scene()
        {
            Entities = new List<IEntity>();
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public List<IEntity> Entities
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
        public IScene Parent
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
        #endregion Public Members

        #region Protected Members
        protected List<IEntity> _entities;
        protected IScene _parent;
        #endregion Protected Members

        #region Private Members
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        public void Draw(SpriteBatch spriteBatch)
        {
            if (Entities != null)
            {
                foreach (var entity in Entities)
                {
                    entity.Draw(spriteBatch);
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            if (Entities != null)
            {
                foreach (var entity in Entities)
                {
                    entity.Update(gameTime);
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