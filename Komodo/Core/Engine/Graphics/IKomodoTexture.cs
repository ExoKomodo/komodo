using Microsoft.Xna.Framework;

namespace Komodo.Core.Engine.Graphics
{
    public interface IKomodoTexture
    {
        #region Members

        #region Public Members
        int Height { get; }
        int Width { get; }
        #endregion Public Members

        #endregion Members

        #region Member Methods
        
        #region Public Member Methods        
        Color[] GetData();
        #endregion Public Member Methods
        
        #endregion Member Methods
    }
}