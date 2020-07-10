using Komodo.Core.ECS.Components;
using Komodo.Core.Engine.Input;
using Komodo.Lib.Math;

using GameTime = Microsoft.Xna.Framework.GameTime;

namespace Common.Behaviors
{
    public class CameraBehavior : BehaviorComponent
    {
        #region Public

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
        #endregion

        #region Members
        public CameraComponent Camera { get; set; }
        public int PlayerIndex { get; set; }
        public float PanVelocity { get; set; }
        #endregion

        #region Member Methods
        public override void Update(GameTime gameTime)
        {
            var cameraLeft = InputManager.GetAction("camera_left", PlayerIndex);
            var cameraRight = InputManager.GetAction("camera_right", PlayerIndex);
            var cameraUp = InputManager.GetAction("camera_up", PlayerIndex);
            var cameraDown = InputManager.GetAction("camera_down", PlayerIndex);

            var direction = Vector3.Zero;
            if (cameraLeft[0].State == InputState.Down)
            {
                direction += Camera.Left;
            }
            if (cameraRight[0].State == InputState.Down)
            {
                direction += Camera.Right;
            }
            if (cameraUp[0].State == InputState.Down)
            {
                direction += Camera.Forward;
            }
            if (cameraDown[0].State == InputState.Down)
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
        #endregion

        #endregion
    }
}