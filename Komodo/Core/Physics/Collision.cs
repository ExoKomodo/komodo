using Komodo.Lib.Math;

using ContainmentType = Microsoft.Xna.Framework.ContainmentType;

namespace Komodo.Core.Physics
{
    /// <summary>
    /// Information about a collision event.
    /// </summary>
    public class Collision
    {
        #region Constructors
        public Collision(bool isColliding, Vector3 normal, float penetrationDepth)
        {
            IsColliding = isColliding;
            Normal = normal;
            PenetrationDepth = penetrationDepth;
            _isResolved = false;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        /// <summary>
        /// Correction vector for the collision. Adding this to the affected object's position will separate the collision.
        /// </summary>
        public Vector3 Correction => Normal * PenetrationDepth;
        
        /// <summary>
        /// Whether or not there was a collision.
        /// </summary>
        public readonly bool IsColliding;

        /// <summary>
        /// Collision normal.
        /// </summary>
        public readonly Vector3 Normal;

        /// <summary>
        /// Depth of penetration of the collision.
        /// </summary>
        public readonly float PenetrationDepth;
        #endregion Public Members

        #region Internal Members
        internal bool _isResolved { get; set; }
        #endregion Internal Members

        #endregion Members
    }
}
