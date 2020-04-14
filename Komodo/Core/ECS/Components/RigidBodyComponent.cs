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
        public Vector3 AngularVelocity { get; internal set; }
        public Vector3 Force { get; internal set; }
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
        public Lib.Math.Vector3 LinearVelocity { get; internal set; }
        public float Restitution
        {
            get
            {
                return Friction;
            }
            set
            {
                if (value >= 0)
                {
                    Restitution = value;
                }
            }
        }
        public IPhysicsShape Shape { get; set; }
        public Vector3 Torque { get; internal set; }
        #endregion Public Members

        #region Internal Members
        internal float _friction { get; set; }
        internal float _restitution { get; set; }
        #endregion Internal Members

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