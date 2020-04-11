namespace Komodo.Core.Physics
{
    /// <summary>
    /// A box shape to be used in physics simulation.
    /// </summary>
    public class Sphere : IPhysicsShape
    {
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
        public float MomentOfInertia { get; private set; }
        #endregion Public Members

        #region Private Members
        private float _mass { get; set; }
        private float _radius { get; set; }
        #endregion Private Members

        #endregion Members

        /// <summary>
        /// Updates the moment of intertia. Called whenever relevant fields have been updated.
        /// </summary>
        private void UpdateMomentOfInertia()
        {
            MomentOfInertia = Mass * Radius * Radius * 0.4f;
        }
    }
}
