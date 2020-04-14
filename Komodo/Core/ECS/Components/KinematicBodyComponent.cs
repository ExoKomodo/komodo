using System;
using Komodo.Core.Physics;
using Komodo.Lib.Math;

using GameTime = Microsoft.Xna.Framework.GameTime;

namespace Komodo.Core.ECS.Components
{
    /// <summary>
    /// Class defining kinematic bodies.
    /// </summary>
    public class KinematicBodyComponent : RigidBodyComponent
    {
        #region Constructors
        public KinematicBodyComponent(IPhysicsShape shape)
        {
            Shape = shape;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public Vector3 PositionDelta { get; internal set; }
        #endregion Public Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        /// <summary>
        /// Initializes a KinematicBodyComponent.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Moves the body in the direction of the movement by its magnitude.
        /// </summary>
        /// <remarks>
        /// Movement will later be scaled by <see cref="Microsoft.Xna.Framework.GameTime"/>.
        /// </remarks>
        /// <param name="movement">Direction and magnitude of the movement.</param>
        public void Move(Vector3 movement)
        {
            if (PhysicsSystem == null)
            {
                throw new Exception("Cannot move a KinematicBodyComponent without a registered PhysicsSystem");
            }
            PositionDelta += movement;
        }
        #endregion Public Member Methods

        #endregion Member Methods
    }
}