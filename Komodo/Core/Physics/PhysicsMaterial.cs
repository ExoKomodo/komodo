using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Komodo.Core.Physics
{
    /// <summary>
    /// Set of parameters for a material in a physics system.
    /// </summary>
    public class PhysicsMaterial
    {
        #region Constructors
        /// <summary>
        /// Creates a new physics material. Physics material names are unique identifiers.
        /// </summary>
        /// <param name="name">The unique name for a physics material. If an existing name is provided, a <see cref="System.ArgumentException"/> is thrown.</param>
        public PhysicsMaterial([NotNull] string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("'name' cannot be null");
            }
            if (_materials.ContainsKey(name))
            {
                throw new ArgumentException("'name' was not unique");
            }
            Name = name;
            _materials[Name] = this;
        }

        /// <summary>
        /// Initializes the PhysicsMaterial database. Also creates a blank PhysicsMaterial with the name "default".
        /// </summary>
        static PhysicsMaterial()
        {
            _materials = new Dictionary<string, PhysicsMaterial>();
            _ = new PhysicsMaterial("default");
        }
        #endregion Constructors

        #region Members

        #region Public Members
        /// <summary>
        /// <see cref="AngularDamping"/> defines how an object's angular veloctity is reduced over time with no interaction from other physics objects.
        /// </summary>
        /// <remarks>
        /// The higher the <see cref="AngularDamping"/>, the quicker angular velocity will drop over time. A value of 0 will provide no reduction in angular velocity over time.
        /// </remarks>
        public float AngularDamping
        {
            get
            {
                return _angularDamping;
            }
            set
            {
                if (value >= 0f)
                {
                    _angularDamping = value;
                }
            }
        }

        /// <summary>
        /// <see cref="AngularDampingLimit"/> defines the threshold at which the angular velocity of an object will be clamped to 0 in all dimensions.
        /// </summary>
        /// <remarks>
        /// The threshold is measured by the length of the angular velocity vector.
        /// </remarks>
        public float AngularDampingLimit
        {
            get
            {
                return _angularDampingLimit;
            }
            set
            {
                if (value >= 0f)
                {
                    _angularDampingLimit = value;
                }
            }
        }

        /// <summary>
        /// <see cref="LinearDampingLimit"/> defines the threshold at which the linear velocity of an object will be clamped to 0 in all dimensions.
        /// </summary>
        /// <remarks>
        /// The threshold is measured by the length of the anglinearular velocity vector.
        /// </remarks>
        public float LinearDampingLimit
        {
            get
            {
                return _linearDampingLimit;
            }
            set
            {
                if (value >= 0f)
                {
                    _linearDampingLimit = value;
                }
            }
        }

        /// <summary>
        /// Defines the frictional coefficient for objects that interact with this PhysicsMaterial.
        /// </summary>
        public float Friction
        {
            get
            {
                return _friction;
            }
            set
            {
                if (value >= 0f && value <= 1f)
                {
                    _friction = value;
                }
            }
        }

        /// <summary>
        /// <see cref="LinearDamping"/> defines how an object's linear veloctity is reduced over time with no interaction from other physics objects.
        /// </summary>
        /// <remarks>
        /// The higher the <see cref="LinearDamping"/>, the quicker linear velocity will drop over time. A value of 0 will provide no reduction in linear velocity over time.
        /// </remarks>
        public float LinearDamping
        {
            get
            {
                return _linearDamping;
            }
            set
            {
                if (value >= 0f)
                {
                    _linearDamping = value;
                }
            }
        }

        /// <summary>
        /// Unique identifier for the PhysicsMaterial.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Bounciness of the physics object.
        /// </summary>
        /// <remarks>
        /// A value of 0 simulates a completely inelastic collision. A value of 1 simulates a perfectly elastic collision. Values greater than 1 simulate collisions that are more elastic than perfect elasticity. A value of 2 will mean that the object bounces with a velocity twice that of when it collided.
        /// </remarks>
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
        #endregion Public Members

        #region Internal Members
        internal float _angularDamping { get; set; }
        internal float _angularDampingLimit { get; set; }
        internal float _friction { get; set; }
        internal float _linearDamping { get; set; }
        internal float _linearDampingLimit { get; set; }
        internal float _restitution { get; set; }
        #endregion Internal Members

        #endregion Members

        #region Static Members

        #region Private Static Members
        private static Dictionary<string, PhysicsMaterial> _materials { get; set; }
        #endregion Private Static Members

        #endregion Static Members

        #region Static Member Methods

        #region Public Static Member Methods
        /// <summary>
        /// Provides the PhysicsMaterial instance for the given name.
        /// </summary>
        /// <param name="name">Identifying name of the PhysicsMaterial.</param>
        /// <returns>PhysicsMaterial identified by the name. Returns null if named material does not exist.</returns>
        public static PhysicsMaterial GetPhysicsMaterial(string name)
        {
            PhysicsMaterial material = null;
            if (name == null)
            {
                return material;
            }
            _materials.TryGetValue(name, out material);

            return material;
        }
        #endregion Public Static Member Methods

        #endregion Static Member Methods
    }
}
