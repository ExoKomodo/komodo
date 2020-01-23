using Komodo.Core.Graphics;

using Microsoft.Xna.Framework.Graphics;

namespace Komodo.Core.Graphics.Sprites
{
    internal class SpriteManagerMonoGame : ISpriteManager
    {
        #region Members

        #region Public Members
        #endregion Public Members
        
        #region Protected Members
        #endregion Protected Members
        
        #region Private Members
        private GraphicsManagerMonoGame _graphicsManagerMonoGame;
        private SpriteBatch _spriteBatchMonoGame;
        #endregion Private Members

        #endregion Members

        #region Member Methods
        
        #region Public Member Methods
        #endregion Public Member Methods
        
        #region Protected Member Methods
        #endregion Protected Member Methods
        
        #region Private Member Methods
        #endregion Private Member Methods
        
        #endregion Member Methods

        #region Constructors
        public SpriteManagerMonoGame(GraphicsManagerMonoGame graphicsManagerMonoGame)
        {
            _graphicsManagerMonoGame = graphicsManagerMonoGame;
            _spriteBatchMonoGame = new SpriteBatch(_graphicsManagerMonoGame._graphicsDeviceManager.GraphicsDevice);
        }
        #endregion Constructors
    }
}