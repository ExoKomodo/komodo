using Komodo.Core;
using Komodo.Core.Engine.Components;
using Komodo.Core.Engine.Input;
using Microsoft.Xna.Framework;

namespace Komodo.Behaviors
{
    public class RootStartupBehavior : BehaviorComponent
    {
        #region Constructors
        public RootStartupBehavior(int playerIndex) : base()
        {
            PlayerIndex = playerIndex;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public bool IsInitialized
        {
            get
            {
                return this._isInitialized;
            }
        }
        public int PlayerIndex { get; }
        #endregion Public Members

        #region Protected Members
        private bool _isInitialized { get; set; }
        #endregion Protected Members

        #region Private Members
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        public override void Update(GameTime gameTime)
        {
            if (!_isInitialized)
            {
                _isInitialized = true;
                IsEnabled = false;
                this.Parent.AddComponent(new SpriteComponent("player/idle/player_idle_01"));
                this.Parent.AddComponent(new MoveBehavior(PlayerIndex));
            }
        }
        #endregion Public Member Methods

        #region Protected Member Methods
        #endregion Protected Member Methods

        #region Private Member Methods
        #endregion Private Member Methods

        #endregion Member Methods
    }
}