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
        #region Public
        
        #region Constructors
        public RigidBodyComponent()
        {
            Material = PhysicsMaterial.GetPhysicsMaterial("default");
        }
        #endregion

        #region Members
        /// <summary>
        /// Rotational velocity.
        /// </summary>
        public Vector3 AngularVelocity { get; internal set; }

        /// <summary>
        /// Current force applied to the RigidBodyComponent.
        /// </summary>
        public Vector3 Force { get; internal set; }

        /// <summary>
        /// Directional velocity.
        /// </summary>
        public Vector3 LinearVelocity { get; internal set; }

        /// <summary>
        /// Material defining the physical parameters of the RigidBodyComponent.
        /// </summary>
        public PhysicsMaterial Material
        {
            get
            {
                return _material;
            }
            set
            {
                if (value != null)
                {
                    _material = value;
                }
            }
        }

        /// <summary>
        /// Shape of the RigidBodyComponent.
        /// </summary>
        public IPhysicsShape Shape
        {
            get
            {
                return _shape.GetScaledShape(Scale);
            }
            set
            {
                _shape = value;
            }
        }

        /// <summary>
        /// Current torque applied to the RigidBodyComponent.
        /// </summary>
        public Vector3 Torque { get; internal set; }
        #endregion
        
        #region Member Methods
        /// <summary>
        /// Initializes a RigidBodyComponent.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }
        #endregion

        #endregion

        #region Internal

        #region Members
        internal PhysicsMaterial _material { get; set; }
        internal IPhysicsShape _shape { get; set; }
        #endregion

        #endregion
    }
}