using Color = Microsoft.Xna.Framework.Color;
using GameTime = Microsoft.Xna.Framework.GameTime;

namespace Komodo.Core
{
    public class MonoGame : Microsoft.Xna.Framework.Game
    {
        #region Members

        #region Public Members
        #endregion Public Members

        #region Protected Members
        #endregion Protected Members

        #region Private Members
        private readonly Game _game;
        #endregion Private Members

        #endregion Members

        #region Member Methods
        
        #region Public Member Methods
        #endregion Public Member Methods
        
        #region Protected Member Methods
        protected override void Draw(GameTime gameTime)
        {
            _game.Draw(gameTime, Color.Green);

            base.Draw(gameTime);
        }

        protected override void Initialize()
        {
            // Framework should initialize all resources before wrapping classes can initialize
            base.Initialize();

            _game.Initialize();
        }

        protected override void LoadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            _game.Update(gameTime);

            base.Update(gameTime);
        }
        #endregion Protected Member Methods
        
        #region Private Member Methods
        #endregion Private Member Methods

        #endregion Member Methods

        #region Constructors
        public MonoGame(Game game)
        {
            _game = game;
            Content.RootDirectory = "Content/MonoGame";
        }
        #endregion Constructors
    }
}
