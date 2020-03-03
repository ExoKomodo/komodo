using Komodo.Core;
using Komodo.Core.ECS.Components;
using Microsoft.Xna.Framework;
using System;

namespace Common.Behaviors
{
    public class FPSCounterBehavior : BehaviorComponent
    {
        #region Constructors
        public FPSCounterBehavior(TextComponent textComponent) : base()
        {
            _counterText = textComponent;
            _counterText.Position = KomodoVector3.Zero;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        #endregion Public Members

        #region Protected Members
        public TextComponent _counterText { get; }
        #endregion Protected Members

        #region Private Members
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        public override void Update(GameTime gameTime)
        {
            _counterText.Text = $"{Math.Round(Game.FramesPerSecond)} FPS";
        }
        #endregion Public Member Methods

        #region Protected Member Methods
        #endregion Protected Member Methods

        #region Private Member Methods
        #endregion Private Member Methods

        #endregion Member Methods
    }
}