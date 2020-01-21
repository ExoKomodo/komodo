// TODO: Remove dependency on MonoGame: GraphicsManager
using Microsoft.Xna.Framework;

namespace Komodo.Core.Graphics
{
    public interface IGraphicsManager
    {
        #region Members

        #region Public Members
        bool IsMouseVisible { get; set; }
        #endregion Public Members
        
        #region Protected Members
        #endregion Protected Members
        
        #region Private Members
        #endregion Private Members

        #endregion Members

        #region Member Methods
        
        #region Public Member Methods
        void Clear(Color clearColor);
        void Initialize();
        #endregion Public Member Methods
        
        #endregion Member Methods
    }
}
