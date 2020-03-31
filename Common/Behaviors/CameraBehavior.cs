using Komodo.Core.ECS.Components;
using Komodo.Core.Engine.Input;
using Komodo.Lib.Math;

using GameTime = Microsoft.Xna.Framework.GameTime;

namespace Common.Behaviors
{
    public class CameraBehavior : BehaviorComponent
    {
        #region Constructors
        public CameraBehavior(CameraComponent camera, int playerIndex) : base()
        {
            if (!InputManager.IsValidPlayerIndex(playerIndex))
            {
                playerIndex = 0;
            }
            PlayerIndex = playerIndex;
            Camera = camera;
            PanVelocity = 50f;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public CameraComponent Camera { get; set; }
        public int PlayerIndex { get; set; }
        public float PanVelocity { get; set; }
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
            var cameraLeft = InputManager.GetInput("camera_left", PlayerIndex);
            var cameraRight = InputManager.GetInput("camera_right", PlayerIndex);
            var cameraUp = InputManager.GetInput("camera_up", PlayerIndex);
            var cameraDown = InputManager.GetInput("camera_down", PlayerIndex);

            var direction = Vector3.Zero;
            if (cameraLeft.State == InputState.Down)
            {
                direction += Camera.Left;
            }
            if (cameraRight.State == InputState.Down)
            {
                direction += Camera.Right;
            }
            if (cameraUp.State == InputState.Down)
            {
                direction += Camera.Forward;
            }
            if (cameraDown.State == InputState.Down)
            {
                direction += Camera.Backward;
            }

            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            var cameraMove = (
                direction
                * PanVelocity
                * delta
            );
            Camera.Move(cameraMove);
        }
        #endregion Public Member Methods

        #endregion Member Methods
    }
}