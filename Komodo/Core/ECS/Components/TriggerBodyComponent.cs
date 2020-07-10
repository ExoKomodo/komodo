using Komodo.Core.Physics;

namespace Komodo.Core.ECS.Components
{
    /// <summary>
    /// Class defining trigger bodies.
    /// </summary>
    /// <remarks>
    /// Has yet to define enter and exit triggers
    /// </remarks>
    public class TriggerBodyComponent : RigidBodyComponent
    {
        #region Public

        #region Constructors
        public TriggerBodyComponent(IPhysicsShape shape)
        {
            Shape = shape;
        }
        #endregion

        #region Member Methods
        /// <summary>
        /// Initializes a TriggerBodyComponent.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }
        #endregion

        #endregion
    }
}