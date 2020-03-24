using GameTime = Microsoft.Xna.Framework.GameTime;

namespace Komodo.Core
{
    /// <summary>
    /// Underlying implementation of the MonoGame <see cref="Microsoft.Xna.Framework.Game"/>.
    /// </summary>
    internal class MonoGame : Microsoft.Xna.Framework.Game
    {
        #region Constructors
        /// <summary>
        /// Defines the root directory of content files.
        /// </summary>
        /// /// <param name="game">Reference to current <see cref="Komodo.Core.Game"/> instance.</param>
        public MonoGame(Game game)
        {
            _game = game;
            Content.RootDirectory = "Content/MonoGame";
        }
        #endregion Constructors

        #region Members

        #region Private Members
        /// <summary>
        /// Reference to current <see cref="Komodo.Core.Game"/> instance.
        /// </summary>
        private Game _game { get; }
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Protected Member Methods
        /// <summary>
        /// Passthrough function to <see cref="Komodo.Core.Game.Draw(GameTime)"/>.
        /// </summary>
        /// <param name="gameTime">Time passed since last <see cref="Draw(GameTime)."/>.</param>
        protected override void Draw(GameTime gameTime)
        {
            _game.Draw(gameTime);

            base.Draw(gameTime);
        }

        /// <summary>
        /// Initializes all low-level resources so <see cref="Komodo.Core.Game"/> can be initialized.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            _game.Initialize();
        }

        /// <summary>
        /// Used to load content files before beginning game loop. [Unused]
        /// </summary>
        protected override void LoadContent()
        {
        }

        /// <summary>
        /// Passthrough function to <see cref="Komodo.Core.Game.Update(GameTime)"/>.
        /// </summary>
        /// <param name="gameTime">Time passed since last <see cref="Update(GameTime)."/>.</param>
        protected override void Update(GameTime gameTime)
        {
            _game.Update(gameTime);

            base.Update(gameTime);
        }
        #endregion Protected Member Methods

        #endregion Member Methods
    }
}
