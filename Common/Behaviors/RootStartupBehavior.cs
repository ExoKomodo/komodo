using Komodo.Core;
using Komodo.Core.ECS.Components;
using Microsoft.Xna.Framework;

namespace Common.Behaviors
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
                Parent.AddComponent(new SpriteComponent("player/idle/player_idle_01", Game.DefaultSpriteShader));
                if (PlayerIndex == 0)
                {
                    Parent.AddComponent(new MoveBehavior(PlayerIndex));
                }

                Parent.AddComponent(
                    new TextComponent("fonts/font", Color.Black, Game.DefaultSpriteShader, $"Test {PlayerIndex}")
                    {
                        Position = new KomodoVector3(0f, 20f, 0)
                    }
                );
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