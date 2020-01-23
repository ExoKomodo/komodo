using System.Collections.Generic;

using Komodo.Core.Engine.Components;
using Komodo.Core.Engine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Komodo.Core.Engine.Scenes
{
    public interface IScene
    {
        #region Members

        #region Public Members
        List<IEntity> Entities { get; set; }
        IScene Parent { get; set; }
        #endregion Public Members

        #endregion Members

        #region Member Methods
        
        #region Public Member Methods
        void AddEntity(IEntity entityToAdd);
        void ClearEntities();
        void Draw(SpriteBatch spriteBatch);
        bool RemoveEntity(IEntity entityToRemove);
        void Update(GameTime gameTime);
        #endregion Public Member Methods
        
        #endregion Member Methods
    }
}
