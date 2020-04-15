using Komodo.Lib.Math;

namespace Komodo.Core.Physics
{
    /// <summary>
    /// A sphere shape to be used in physics simulation.
    /// </summary>
    public class Sphere : IPhysicsShape
    {
        #region Constructors
        public Sphere(float radius, float mass)
        {
            Radius = radius;
            Mass = mass;
        }

        #endregion Constructors
        #region Members

        #region Public Members
        /// <summary>
        /// Radius of the Sphere.
        /// </summary>
        public float Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
                UpdateMomentOfInertia();
            }
        }

        /// <summary>
        /// Mass of the Sphere.
        /// </summary>
        /// <remarks>
        /// Updates MomentOfInertia when changed.
        /// </remarks>
        public float Mass
        {
            get
            {
                return _mass;
            }
            set
            {
                _mass = value;
                UpdateMomentOfInertia();
            }
        }

        /// <summary>
        /// Moment of inertia for the Sphere
        /// </summary>
        public Vector3 MomentOfInertia { get; private set; }
        #endregion Public Members

        #region Private Members
        private float _mass { get; set; }
        private float _radius { get; set; }
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        public IPhysicsShape GetScaledShape(Vector3 scale)
        {
            return new Sphere(Radius * scale.X, Mass);
        }
        #endregion Public Member Methods

        #region Private Member Methods
        /// <summary>
        /// Updates the moment of intertia. Called whenever relevant fields have been updated.
        /// </summary>
        private void UpdateMomentOfInertia()
        {
            float moment = Mass * Radius * Radius * 0.4f;
            MomentOfInertia = new Vector3(moment, moment, moment);
        }
        #endregion Private Member Methods

        #endregion Member Methods
    }
}
