using Komodo.Core;
using Komodo.Core.Engine.Components;
using Komodo.Core.Engine.Input;
using Microsoft.Xna.Framework;

namespace Komodo.Behaviors
{
    public class MoveBehavior : BehaviorComponent
    {
        #region Constructors
        public MoveBehavior(int playerIndex) : base()
        {
            if (!InputManager.IsValidPlayerIndex(playerIndex))
            {
                playerIndex = 0;
            }
            PlayerIndex = playerIndex;
            SprintFactor = 2f;
            Velocity = 50f;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public int PlayerIndex { get; set; }
        public float SprintFactor { get; set; }
        public float Velocity { get; set; }
        #endregion Public Members

        #region Protected Members
        #endregion Protected Members

        #region Private Members
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        public override void Update(GameTime gameTime)
        {
            var left = InputManager.GetInput("left", PlayerIndex);
            var right = InputManager.GetInput("right", PlayerIndex);
            var up = InputManager.GetInput("up", PlayerIndex);
            var down = InputManager.GetInput("down", PlayerIndex);
            var sprint = InputManager.GetInput("sprint", PlayerIndex);

            var quit = InputManager.GetInput("quit", PlayerIndex);

            var direction = KomodoVector2.Zero;
            if (quit.State == InputState.Down)
            {
                Game.Exit();
            }
            if (left.State == InputState.Down)
            {
                direction += KomodoVector2.Left;
            }
            if (right.State == InputState.Down)
            {
                direction += KomodoVector2.Right;
            }
            if (up.State == InputState.Down)
            {
                direction += KomodoVector2.Up;
            }
            if (down.State == InputState.Down)
            {
                direction += KomodoVector2.Down;
            }
            if (sprint.State == InputState.Down)
            {
                direction *= SprintFactor;
            }

            Parent.Position = KomodoVector3.Add(
                Parent.Position,
                KomodoVector3.Multiply(
                    new KomodoVector3(direction.X, direction.Y),
                    Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds
                )
            );
        }
        #endregion Public Member Methods

        #region Protected Member Methods
        #endregion Protected Member Methods

        #region Private Member Methods
        #endregion Private Member Methods

        #endregion Member Methods
    }
}