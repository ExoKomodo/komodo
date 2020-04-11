using GameTime = Microsoft.Xna.Framework.GameTime;

namespace Komodo.Core.ECS.Components
{
    /// <summary>
    /// Abstract class defining all physics components.
    /// </summary>
    public abstract class PhysicsComponent : Component
    {
        #region Constructors
        protected PhysicsComponent() : base(true, null)
        {
        }
        #endregion Constructors

        #region Member Methods

        #region Public Member Methods
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

        /// <summary>
        /// Abstract method for updating a PhysicsComponent.
        /// </summary>
        /// <param name="gameTime">Time passed since last <see cref="Update"/></param>
        public abstract void Update(GameTime gameTime);
        #endregion Public Member Methods

        #endregion Member Methods
    }
}