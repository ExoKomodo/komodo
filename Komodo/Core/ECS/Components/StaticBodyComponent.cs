using GameTime = Microsoft.Xna.Framework.GameTime;

namespace Komodo.Core.ECS.Components
{
    /// <summary>
    /// Class defining static bodies.
    /// </summary>
    public class StaticBodyComponent : RigidBodyComponent
    {
        #region Constructors
        public StaticBodyComponent()
        {
        }
        #endregion Constructors

        #region Member Methods

        #region Public Member Methods
        /// <summary>
        /// Initializes a StaticBodyComponent.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }
        #endregion Public Member Methods

        #endregion Member Methods
    }
}