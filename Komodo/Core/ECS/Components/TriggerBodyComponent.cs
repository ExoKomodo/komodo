using GameTime = Microsoft.Xna.Framework.GameTime;

namespace Komodo.Core.ECS.Components
{
    /// <summary>
    /// Class defining trigger bodies.
    /// </summary>
    public class TriggerBodyComponent : RigidBodyComponent
    {
        #region Constructors
        public TriggerBodyComponent()
        {
        }
        #endregion Constructors

        #region Member Methods

        #region Public Member Methods
        /// <summary>
        /// Initializes a TriggerBodyComponent.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }
        #endregion Public Member Methods

        #endregion Member Methods
    }
}