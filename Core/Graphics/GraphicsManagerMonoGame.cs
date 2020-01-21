using Microsoft.Xna.Framework;

namespace Komodo.Core.Graphics
{
    internal class GraphicsManagerMonoGame : IGraphicsManager
    {
        #region Members

        #region Public Members
        #endregion Public Members
        
        #region Protected Members
        #endregion Protected Members
        
        #region Private Members
        private GraphicsDeviceManager _graphicsDeviceManager;
        private KomodoMonoGame _komodoMonoGame;
        #endregion Private Members

        #endregion Members

        #region Member Methods
        
        #region Public Member Methods
        public void Clear(Color clearColor)
        {
            _graphicsDeviceManager.GraphicsDevice.Clear(clearColor);
        }
        #endregion Public Member Methods
        
        #region Protected Member Methods
        #endregion Protected Member Methods
        
        #region Private Member Methods
        #endregion Private Member Methods
        
        #endregion Member Methods

        #region Constructors
        public GraphicsManagerMonoGame(KomodoMonoGame komodoMonoGame)
        {
            _komodoMonoGame = komodoMonoGame;
            _graphicsDeviceManager = new GraphicsDeviceManager(_komodoMonoGame);
        }
        #endregion Constructors
    }
}