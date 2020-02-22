using Komodo.Core.ECS.Scenes;
using Microsoft.Xna.Framework;

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
        void Draw(Scene scene, Matrix transformMatrix);
        #endregion Public Member Methods
        
        #endregion Member Methods
    }
}
