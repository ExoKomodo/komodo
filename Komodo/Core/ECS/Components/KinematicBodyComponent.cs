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
        /// <param name="movement">Direction and magnitude of the movement.</param>
        public void Move(Vector3 movement)
        {
            Parent.Position += movement;
        }

        /// <summary>
        /// Moves the body in the direction of the movement by its magnitude. Scales by <see cref="gameTime"/> delta.
        /// </summary>
        /// <param name="movement">Direction and magnitude of the movement.</param>
        /// <param name="gameTime">Time to scale the movement by.</param>
        public void Move(Vector3 movement, GameTime gameTime) => Move(movement * (float)gameTime.ElapsedGameTime.TotalSeconds);

        /// <summary>
        /// Updates a KinematicBodyComponent.
        /// </summary>
        /// <param name="gameTime">Time passed since last <see cref="Update"/></param>
        public override void Update(GameTime gameTime)
        {
        }
        #endregion Public Member Methods

        #region Private Member Methods
        #endregion Private Member Methods

        #endregion Member Methods
    }
}