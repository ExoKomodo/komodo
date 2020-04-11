using System;
using Komodo.Core.Physics;
using Komodo.Lib.Math;

using GameTime = Microsoft.Xna.Framework.GameTime;

namespace Komodo.Core.ECS.Components
{
    /// <summary>
    /// Class defining dynamic bodies.
    /// </summary>
    public class DynamicBodyComponent : RigidBodyComponent
    {
        #region Constructors
        public DynamicBodyComponent(IPhysicsShape shape)
        {
            Shape = shape;
        }
        #endregion Constructors

        #region Member Methods

        #region Public Member Methods
        /// <summary>
        /// Applies a force vector to the body with no regard for the point of application.
        /// </summary>
        public void ApplyForce(Vector3 force)
        {
            Force += force;
        }

        /// <summary>
        /// Applies a force vector to the body with regard for the point of application.
        /// </summary>
        public void ApplyForceAtPoint(Vector3 force, Vector3 pointOfApplication)
        {
            switch (Shape)
            {
                case Box _:
                    ApplyForce(force);
                    Torque += Vector3.Cross(pointOfApplication, force);
                    break;
                case Sphere _:
                    throw new NotImplementedException("Sphere not yet implemented");
                default:
                    throw new Exception("No shape");
            }
        }

        /// <summary>
        /// Clears all current velocities.
        /// </summary>
        public void ClearVelocities()
        {
            AngularVelocity = Vector3.Zero;
            LinearVelocity = Vector3.Zero;
        }

        /// <summary>
        /// Initializes a DynamicBodyComponent.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Updates a DynamicBodyComponent.
        /// </summary>
        /// <param name="gameTime">Time passed since last <see cref="Update"/></param>
        public override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            CalculateAngularVelocity(delta);
            CalculateLinearVelocity(delta);

            Parent.Position += this.LinearVelocity * delta;
            Parent.Rotation += this.AngularVelocity * delta;

            Force = Vector3.Zero;
            Torque = Vector3.Zero;
        }
        #endregion Public Member Methods

        #region Private Member Methods
        /// <summary>
        /// Calculates angular velocity for the current frame.
        /// </summary>
        private void CalculateAngularVelocity(float delta)
        {
            var angularAcceleration = new Vector3(
                Torque.X * (1.0f / Shape.MomentOfInertia.X),
                Torque.Y * (1.0f / Shape.MomentOfInertia.Y),
                Torque.Z * (1.0f / Shape.MomentOfInertia.Z)
            );
            AngularVelocity += angularAcceleration * delta;
        }

        /// <summary>
        /// Calculates linear velocity for the current frame.
        /// </summary>
        private void CalculateLinearVelocity(float delta)
        {
            var linearAcceleration = Force * (1f / Shape.Mass);
            LinearVelocity += linearAcceleration * delta;
        }
        #endregion Private Member Methods

        #endregion Member Methods
    }
}