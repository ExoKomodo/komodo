﻿using Komodo.Core.Graphics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Komodo.Core
{
    internal class KomodoMonoGame : Microsoft.Xna.Framework.Game
    {
        #region Members

        #region Public Members
        #endregion Public Members

        #region Protected Members
        #endregion Protected Members

        #region Private Members
        private IKomodoGame _komodoGame;
        #endregion Private Members

        #endregion Members

        #region Member Methods
        
        #region Public Member Methods
        #endregion Public Member Methods
        
        #region Protected Member Methods
        protected override void Draw(GameTime gameTime)
        {
            _komodoGame.Draw(gameTime, Color.Red);

            base.Draw(gameTime);
        }

        protected override void Initialize()
        {
            // Framework should initialize all resources before wrapping classes can initialize
            base.Initialize();

            _komodoGame.Initialize();
        }

        protected override void LoadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            _komodoGame.Update(gameTime);

            base.Update(gameTime);
        }
        #endregion Protected Member Methods
        
        #region Private Member Methods
        #endregion Private Member Methods

        #endregion Member Methods

        #region Constructors
        public KomodoMonoGame(IKomodoGame komodoGame)
        {
            _komodoGame = komodoGame;
            Content.RootDirectory = "Content/MonoGame";
            IsMouseVisible = true;
        }
        #endregion Constructors
    }
}