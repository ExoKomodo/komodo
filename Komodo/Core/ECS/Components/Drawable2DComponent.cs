using Komodo.Core.ECS.Entities;
using Komodo.Lib.Math;

using Effect = Microsoft.Xna.Framework.Graphics.Effect;

namespace Komodo.Core.ECS.Components
{
    public abstract class Drawable2DComponent : Component
    {
        #region Constructors
        protected Drawable2DComponent(bool isEnabled = true, Entity parent = null) : base(isEnabled, parent)
        {
        }
        #endregion

        #region Members

        #region Public Members
        public abstract Vector2 Center { get; }
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
