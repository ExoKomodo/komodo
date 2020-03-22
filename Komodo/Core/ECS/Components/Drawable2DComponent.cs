using Komodo.Core.ECS.Entities;
using Komodo.Core.Engine.Graphics;
using Microsoft.Xna.Framework.Graphics;

namespace Komodo.Core.ECS.Components
{
    public abstract class Drawable2DComponent : Component
    {
        #region Constructors
        public Drawable2DComponent(bool isEnabled = true, Entity parent = null) : base(isEnabled, parent)
        {
        }
        #endregion

        #region Members

        #region Public Members
        public abstract KomodoVector2 Center { get; }
        public abstract float Height { get; }
        public bool IsBillboard { get; set; }
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
        public abstract float Width { get; }
        #endregion Public Members

        #region Private Members
        private Effect _shader { get; set; }
        #endregion Private members

        #endregion Members
    }
}
