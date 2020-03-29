using Komodo.Core.ECS.Components;
using System;

using Color = Microsoft.Xna.Framework.Color;
using GameTime = Microsoft.Xna.Framework.GameTime;

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

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        public override void Initialize()
        {
            base.Initialize();

            Parent.AddComponent(
                new SpriteComponent("player/idle/player_idle_01", Game?.DefaultSpriteShader)
                {
                    IsBillboard = false
                }
            );
            if (PlayerIndex == 0)
            {
                Parent.AddComponent(new MoveBehavior(PlayerIndex));
            }

            Parent.AddComponent(
                new TextComponent("fonts/font", Color.Black, Game?.DefaultSpriteShader, $"Test {PlayerIndex}")
                {
                    IsBillboard = true,
                    Position = new Komodo.Lib.Math.Vector3(0f, 20f, 0)
                }
            );
        }
        public override void Update(GameTime gameTime)
        {
        }
        #endregion Public Member Methods

        #endregion Member Methods
    }
}