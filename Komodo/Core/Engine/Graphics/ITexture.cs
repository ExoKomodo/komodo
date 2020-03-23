using Color = Microsoft.Xna.Framework.Color;

namespace Komodo.Core.Engine.Graphics
{
    public interface ITexture
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