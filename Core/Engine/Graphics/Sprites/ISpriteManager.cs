using System.Collections.Generic;
using Komodo.Core.Engine.Entities;
using Microsoft.Xna.Framework.Graphics;

namespace Komodo.Core.Engine.Graphics.Sprites
{
    public interface ISpriteManager
    {
        #region Members

        #region Public Members
        #endregion Public Members

        #endregion Members

        #region Member Methods
        
        #region Public Member Methods
        void BeginDraw();
        void Draw(IEntity entity);
        // void DrawText(Texture2D texture);
        void EndDraw();
        #endregion Public Member Methods
        
        #endregion Member Methods
    }
}
