using System.Collections.Generic;
using Komodo.Core.Engine.Components;
using Komodo.Core.Engine.Entities;
using Komodo.Core.Engine.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Komodo.Core.Engine.Graphics.Sprites
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

        public void Draw(Scene scene, Matrix transformMatrix)
        {
            scene.Draw(_spriteBatchMonoGame, transformMatrix);
        }
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
            _spriteBatchMonoGame = new SpriteBatch(_graphicsManagerMonoGame.GraphicsDeviceManager.GraphicsDevice);
        }
        #endregion Constructors
    }
}