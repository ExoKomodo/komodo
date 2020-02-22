using Komodo.Core.ECS.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Komodo.Core.ECS.Components
{
    public abstract class Drawable2DComponent : Component
    {
        #region Constructors
        public Drawable2DComponent(bool isEnabled = true, Entity parent = null, Effect shader = null) : base(isEnabled, parent)
        {
            Shader = shader;
        }
        #endregion

        #region Members

        #region Public Members
        public Effect Shader
        {
            get
            {
                return _shader;
            }
            set
            {
                _shader = value;
            }
        }
        #endregion Public Members

        #region Protected Public Members
        protected Effect _shader { get; set; }
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
