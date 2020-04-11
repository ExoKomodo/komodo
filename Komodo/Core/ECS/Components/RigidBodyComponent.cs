using Komodo.Lib.Math;
using Komodo.Core.Physics;

using GameTime = Microsoft.Xna.Framework.GameTime;

namespace Komodo.Core.ECS.Components
{
    /// <summary>
    /// Abstract class defining all rigid bodies.
    /// </summary>
    public abstract class RigidBodyComponent : PhysicsComponent
    {
        #region Constructors
        protected RigidBodyComponent()
        {
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public Vector3 AngularVelocity { get; protected set; }
        public Vector3 Force { get; protected set; }
        public float Friction
        {
            get
            {
                return _friction;
            }
            set
            {
                if (value >= 0)
                {
                    _friction = value;
                }
            }
        }
        public Vector3 LinearVelocity { get; protected set; }
        public float Restitution
        {
            get
            {
                return _restitution;
            }
            set
            {
                if (value >= 0)
                {
                    _restitution = value;
                }
            }
        }
        public IPhysicsShape Shape { get; set; }
        public Vector3 Torque { get; protected set; }
        #endregion Public Members

        #region Private Members
        private float _friction { get; set; }
        private float _restitution { get; set; }
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        /// <summary>
        /// Initializes a RigidBodyComponent.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }
        #endregion Public Member Methods

        #endregion Member Methods
    }
}