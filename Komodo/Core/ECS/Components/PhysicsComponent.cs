using Komodo.Core.ECS.Systems;
using Komodo.Core.Physics;
using System;
using System.Collections.Generic;

namespace Komodo.Core.ECS.Components
{
    /// <summary>
    /// Abstract class defining all physics components.
    /// </summary>
    public abstract class PhysicsComponent : Component
    {
        #region Public

        #region Constructors
        public PhysicsComponent() : base(true, null)
        {
            Collisions = new Dictionary<Guid, Collision>();
        }
        #endregion

        #region Members
        public Dictionary<Guid, Collision> Collisions { get; }
        public PhysicsSystem PhysicsSystem => Parent?.PhysicsSystem;
        #endregion

        #region Member Methods
        /// <summary>
        /// Virtual method initializing a PhysicsComponent.
        /// </summary>
        public virtual void Initialize()
        {
            if (!IsInitialized)
            {
                IsInitialized = true;
            }
        }
        #endregion

        #endregion
    }
}