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

        /// <summary>
        /// Updates a TriggerBodyComponent.
        /// </summary>
        /// <param name="gameTime">Time passed since last <see cref="Update"/></param>
        public override void Update(GameTime gameTime)
        {

        }
        #endregion Public Member Methods

        #endregion Member Methods
    }
}