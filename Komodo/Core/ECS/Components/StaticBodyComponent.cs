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

        /// <summary>
        /// Updates a StaticBodyComponent.
        /// </summary>
        /// <param name="gameTime">Time passed since last <see cref="Update"/></param>
        public override void Update(GameTime gameTime)
        {

        }
        #endregion Public Member Methods

        #endregion Member Methods
    }
}