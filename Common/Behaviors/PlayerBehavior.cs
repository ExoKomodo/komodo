using Komodo.Core.ECS.Components;
using Komodo.Lib.Math;
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

            Parent.AddComponent(new Drawable3DComponent("models/cube"));
            if (PlayerIndex == 0)
            {
                Parent.AddComponent(new MoveBehavior(PlayerIndex));
            }
            Scale = Vector3.One * 10f;
        }
        public override void Update(GameTime gameTime)
        {
        }
        #endregion Public Member Methods

        #endregion Member Methods
    }
}