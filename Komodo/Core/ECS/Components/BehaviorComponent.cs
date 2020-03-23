using GameTime = Microsoft.Xna.Framework.GameTime;

namespace Komodo.Core.ECS.Components
{
    public abstract class BehaviorComponent : Component
    {
        #region Constructors
        protected BehaviorComponent() : base(true, null)
        {
        }
        #endregion Constructors

        #region Members

        #region Public Members
        #endregion Public Members

        #region Protected Members
        #endregion Protected Members

        #region Private Members
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        public virtual void Initialize()
        {
            if (!IsInitialized)
            {
                IsInitialized = true;
            }
        }
        
        public virtual void Update(GameTime gameTime)
        {
            
        }
        #endregion Public Member Methods

        #region Protected Member Methods
        #endregion Protected Member Methods

        #region Private Member Methods
        #endregion Private Member Methods

        #endregion Member Methods
    }
}