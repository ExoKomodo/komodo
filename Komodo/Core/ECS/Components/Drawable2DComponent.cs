using Komodo.Core.ECS.Entities;
using Komodo.Lib.Math;

using Effect = Microsoft.Xna.Framework.Graphics.Effect;

namespace Komodo.Core.ECS.Components
{
    /// <summary>
    /// Abstract class defining all 2D drawable Components.
    /// A class derived from Drawable2DComponent will render in a SpriteBatch in a <see cref="Komodo.Core.ECS.Systems.Render2DSystem"/>.
    /// </summary>4
    public abstract class Drawable2DComponent : Component
    {
        #region Public

        #region Constructors
        public Drawable2DComponent(bool isEnabled = true, Entity parent = null) : base(isEnabled, parent)
        {
        }
        #endregion
        
        #region Members
        /// <summary>
        /// Center point of the rendered Component.
        /// </summary>
        public abstract Vector2 Center { get; }

        /// <summary>
        /// Height of the rendered Component.
        /// </summary>
        public abstract float Height { get; }

        /// <summary>
        /// Flags whether or not to draw the Drawable2DComponent as a billboard in 3D space, always facing the relevant <see cref="Komodo.Core.ECS.Components.CameraComponent"/>.
        /// </summary>
        public bool IsBillboard { get; set; }

        /// <summary>
        /// Shader to use when rendering the Component. If Shader is null, the <see cref="Komodo.Core.Game.DefaultSpriteShader"/> will be used.
        /// </summary>
        public Effect Shader { get; set; }

        /// <summary>
        /// Width of the rendered Component.
        /// </summary>
        public abstract float Width { get; }
        #endregion

        #endregion
    }
}
