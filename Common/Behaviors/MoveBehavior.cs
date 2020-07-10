using Komodo.Core.ECS.Components;
using Komodo.Core.Engine.Input;
using Komodo.Core.Physics;
using Komodo.Lib.Math;

using GameTime = Microsoft.Xna.Framework.GameTime;

namespace Common.Behaviors
{
    public class MoveBehavior : BehaviorComponent
    {
        #region Public

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
        #endregion

        #region Members
        public DynamicBodyComponent Body { get; private set; }
        public int PlayerIndex { get; set; }
        public float SprintFactor { get; set; }
        public float Velocity { get; set; }
        #endregion

        #region Member Methods
        public override void Initialize()
        {
            base.Initialize();

            var material = new PhysicsMaterial("player")
            {
                Restitution = 1f,
                LinearDamping = 1f,
                LinearDampingLimit = 0.1f,
            };
            Body = new DynamicBodyComponent(
                new Box(2f, 2f, 2f, 1f)
            )
            {
                Position = new Vector3(0, 0f, 0f),
                Material = material,
            };
            Parent.AddComponent(Body);
        }

        public override void Update(GameTime gameTime)
        {
            var left = InputManager.GetAction("left", PlayerIndex);
            var right = InputManager.GetAction("right", PlayerIndex);
            var up = InputManager.GetAction("up", PlayerIndex);
            var down = InputManager.GetAction("down", PlayerIndex);
            var sprint = InputManager.GetAction("sprint", PlayerIndex);

            var quit = InputManager.GetAction("quit", PlayerIndex);

            var direction = Vector3.Zero;
            var camera = Parent.Render2DSystem.ActiveCamera;
            if (quit[0].State == InputState.Down)
            {
                Game.Exit();
            }
            if (left[0].State == InputState.Down)
            {
                direction += camera.Left;
            }
            if (right[0].State == InputState.Down)
            {
                direction += camera.Right;
            }
            if (up[0].State == InputState.Down)
            {
                direction += camera.Forward;
            }
            if (down[0].State == InputState.Down)
            {
                direction += camera.Backward;
            }
            if (sprint[0].State == InputState.Down)
            {
                direction *= SprintFactor;
            }
            /*var collision = Body.Collisions.Values.FirstOrDefault();
            if (collision.IsColliding)
            {
                Parent.Position += collision.Correction;
            }*/
            //Body.Move(direction * Velocity);
            Body.ApplyForce(direction * Velocity);
        }
        #endregion

        #endregion
    }
}