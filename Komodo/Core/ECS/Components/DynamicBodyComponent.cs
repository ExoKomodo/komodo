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
        #endregion Public Member Methods

        #endregion Member Methods
    }
}