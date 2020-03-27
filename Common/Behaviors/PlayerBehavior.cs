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
        public SoundComponent Sound { get; private set; }
        public Guid SoundInstance { get; private set; }
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
            Sound = new SoundComponent("audio/sample");
            Parent.AddComponent(Sound);

            Parent.AddComponent(
                new TextComponent("fonts/font", Color.Black, Game?.DefaultSpriteShader, $"Test {PlayerIndex}")
                {
                    IsBillboard = false,
                    Position = new Komodo.Lib.Math.Vector3(0f, 20f, 0)
                }
            );
        }
        public override void Update(GameTime gameTime)
        {
            if (Sound != null && SoundInstance == Guid.Empty)
            {
                SoundInstance = Sound.Play();
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