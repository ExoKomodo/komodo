using Komodo.Core.ECS.Components;
using Komodo.Core.Engine.Input;
using Komodo.Core.Physics;
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
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public DynamicBodyComponent Body { get; private set; }
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
            var left = InputManager.GetInput("left", PlayerIndex);
            var right = InputManager.GetInput("right", PlayerIndex);
            var up = InputManager.GetInput("up", PlayerIndex);
            var down = InputManager.GetInput("down", PlayerIndex);
            var sprint = InputManager.GetInput("sprint", PlayerIndex);

            var quit = InputManager.GetInput("quit", PlayerIndex);

            var direction = Vector3.Zero;
            var camera = Parent.Render2DSystem.ActiveCamera;
            if (quit.State == InputState.Down)
            {
                Game.Exit();
            }
            if (left.State == InputState.Down)
            {
                direction += camera.Left;
            }
            if (right.State == InputState.Down)
            {
                direction += camera.Right;
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
            /*var collision = Body.Collisions.Values.FirstOrDefault();
            if (collision.IsColliding)
            {
                Parent.Position += collision.Correction;
            }*/
            //Body.Move(direction * Velocity);
            Body.ApplyForce(direction * Velocity);
        }
        #endregion Public Member Methods

        #endregion Member Methods
    }
}