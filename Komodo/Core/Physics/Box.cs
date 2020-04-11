namespace Komodo.Core.Physics
{
    /// <summary>
    /// A box shape to be used in physics simulation.
    /// </summary>
    public class Box : IPhysicsShape
    {
        #region Members

        #region Public Members
        /// <summary>
        /// Height of the Box.
        /// </summary>
        /// <remarks>
        /// Updates MomentOfInertia when changed.
        /// </remarks>
        public float Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                UpdateMomentOfInertia();
            }
        }

        /// <summary>
        /// Mass of the Box.
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
        /// Moment of inertia for the Box.
        /// </summary>
        public float MomentOfInertia { get; private set; }

        /// <summary>
        /// Width of the Box.
        /// </summary>
        /// <remarks>
        /// Updates MomentOfInertia when changed.
        /// </remarks>
        public float Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                UpdateMomentOfInertia();
            }
        }
        #endregion Public Members

        #region Private Members
        private float _height { get; set; }
        private float _mass { get; set; }
        private float _width { get; set; }
        #endregion Private Members

        #endregion Members

        /// <summary>
        /// Updates the moment of intertia. Called whenever relevant fields have been updated.
        /// </summary>
        private void UpdateMomentOfInertia()
        {
            MomentOfInertia = Mass * (Width * Width + Height * Height) / 12f;
        }
    }
}
