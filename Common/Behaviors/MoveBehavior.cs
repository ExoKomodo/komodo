using Komodo.Core.ECS.Components;
using Komodo.Core.Engine.Input;
using Komodo.Lib.Math;

using GameTime = Microsoft.Xna.Framework.GameTime;

namespace Common.Behaviors
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

            //var client = new Client("127.0.0.1", 5000);
            // var b = client.SendAsync(
            //     new
            //     {
            //         a = 1
            //     },
            //     "a"
            // );
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

            var direction = Vector3.Zero;
            float rotation = 0f;
            float rotationSpeed = 1f;
            var camera = Parent.Render2DSystem.ActiveCamera;
            if (quit.State == InputState.Down)
            {
                Game.Exit();
            }
            if (left.State == InputState.Down)
            {
                rotation += rotationSpeed;
            }
            if (right.State == InputState.Down)
            {
                rotation -= rotationSpeed;
            }
            if (up.State == InputState.Down)
            {
                direction += camera.Forward;
            }
            if (down.State == InputState.Down)
            {
                direction += camera.Backward;
            }
            if (sprint.State == InputState.Down)
            {
                direction *= SprintFactor;
            }

            float timeScale = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Parent.Position += (
                direction
                * Velocity
                * timeScale
            );
            Parent.Rotation += new Vector3(0f, rotation * timeScale, 0f);
        }
        #endregion Public Member Methods

        #endregion Member Methods
    }
}