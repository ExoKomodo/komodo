using Komodo.Core.ECS.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Komodo.Core.Engine.Graphics.Models
{
    internal class ModelManagerMonoGame : IModelManager
    {
        #region Members

        #region Public Members
        #endregion Public Members
        
        #region Protected Members
        #endregion Protected Members
        
        #region Private Members
        private GraphicsManagerMonoGame _graphicsManagerMonoGame;
        #endregion Private Members

        #endregion Members

        #region Member Methods
        
        #region Public Member Methods

        public void DrawScene(Scene scene)
        {
            scene.Draw3DComponents();
        }
        #endregion Public Member Methods
        
        #region Protected Member Methods
        #endregion Protected Member Methods
        
        #region Private Member Methods
        #endregion Private Member Methods
        
        #endregion Member Methods

        #region Constructors
        public ModelManagerMonoGame(GraphicsManagerMonoGame graphicsManagerMonoGame)
        {
            _graphicsManagerMonoGame = graphicsManagerMonoGame;
        }
        #endregion Constructors
    }
}