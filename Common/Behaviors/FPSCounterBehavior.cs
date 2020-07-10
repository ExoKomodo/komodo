using Komodo.Core.ECS.Components;
using System;

using Color = Microsoft.Xna.Framework.Color;
using GameTime = Microsoft.Xna.Framework.GameTime;

namespace Common.Behaviors
{
    public class FPSCounterBehavior : BehaviorComponent
    {
        #region Public

        #region Members
        public TextComponent CounterText { get; protected set;  }
        #endregion

        #region Member Methods
        public override void Initialize()
        {
            base.Initialize();

            CounterText = new TextComponent("fonts/font", Color.Black, Game.DefaultSpriteShader, "")
            {
                Position = Komodo.Lib.Math.Vector3.Zero
            };
            Parent.AddComponent(CounterText);
        }
        public override void Update(GameTime gameTime)
        {
            CounterText.Text = $"{Math.Round(Game.FramesPerSecond)} FPS";
        }
        #endregion

        #endregion
    }
}