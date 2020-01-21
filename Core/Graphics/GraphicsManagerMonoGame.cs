using Komodo.Core.Sprites;

using Microsoft.Xna.Framework;

namespace Komodo.Core.Graphics
{
    internal class GraphicsManagerMonoGame : IGraphicsManager
    {
        #region Members

        #region Public Members
        public bool IsMouseVisible {
            get
            {
                return _komodoMonoGame == null ? false : _komodoMonoGame.IsMouseVisible;
            }
            set
            {
                if (_komodoMonoGame != null)
                {
                    _komodoMonoGame.IsMouseVisible = value;
                }
            }
        }
        public GraphicsDeviceManager _graphicsDeviceManager;
        public SpriteManagerMonoGame _spriteManagerMonoGame;
        #endregion Public Members
        
        #region Protected Members
        #endregion Protected Members
        
        #region Private Members
        private KomodoMonoGame _komodoMonoGame;
        #endregion Private Members

        #endregion Members

        #region Member Methods
        
        #region Public Member Methods
        public void Clear(Color clearColor)
        {
            _graphicsDeviceManager.GraphicsDevice.Clear(clearColor);
        }

        // Initialize is called after all framework resources have been initialized and allocated
        public void Initialize()
        {
            // Sprite manager requires framework graphics resources to be initialized
            _spriteManagerMonoGame = new SpriteManagerMonoGame(this);   
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