using Komodo.Core;
using Komodo.Core.ECS.Components;
using Microsoft.Xna.Framework;

namespace Common.Behaviors
{
    public class PlayerBehavior : BehaviorComponent
    {
        #region Constructors
        public PlayerBehavior(int playerIndex) : base()
        {
            PlayerIndex = playerIndex;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public int PlayerIndex { get; }
        #endregion Public Members

        #region Protected Members
        #endregion Protected Members

        #region Private Members
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        public override void Initialize()
        {
            base.Initialize();

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
        public override void Update(GameTime gameTime)
        {
        }
        #endregion Public Member Methods

        #region Protected Member Methods
        #endregion Protected Member Methods

        #region Private Member Methods
        #endregion Private Member Methods

        #endregion Member Methods
    }
}