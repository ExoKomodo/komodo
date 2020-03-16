using Komodo.Core.ECS.Entities;
using Microsoft.Xna.Framework;

namespace Komodo.Core.ECS.Components
{
    public abstract class Drawable3DComponent : Component
    {
        #region Constructors
        public Drawable3DComponent(bool isEnabled = true, Entity parent = null) : base(isEnabled, parent)
        {
        }
        #endregion

        #region Members

        #region Public Members
        #endregion Public Members

        #region Protected Public Members
        #endregion

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        sealed public override void Update(GameTime gameTime)
        {
            
        }
        #endregion Public Member Methods
        
        #endregion Member Methods
    }
}
