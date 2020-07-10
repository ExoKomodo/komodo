using Komodo.Core.Engine.Graphics;
using Komodo.Lib.Math;

using Effect = Microsoft.Xna.Framework.Graphics.Effect;

namespace Komodo.Core.ECS.Components
{
    /// <summary>
    /// Represents any 2D texture to be drawn in a <see cref="Komodo.Core.ECS.Systems.Render2DSystem"/>
    /// </summary>
    public class SpriteComponent : Drawable2DComponent
    {
        #region Public

        #region Constructors
        /// <summary>
        /// Creates a SpriteComponent with a given <see cref="Komodo.Core.Engine.Graphics.Texture"/>.
        /// </summary>
        /// <param name="texture">Texture reference containing the raw texture data.</param>
        /// <param name="shader">Shader used for rendering in a <see cref="Microsoft.Xna.Framework.Graphics.SpriteBatch"/>.</param>
        public SpriteComponent(Engine.Graphics.Texture texture, Effect shader) : base(true, null)
        {
            Shader = shader;
            Texture = texture;
            TexturePath = null;
        }

        /// <summary>
        /// Creates a SpriteComponent with a filepath to a compiled <see cref="Microsoft.Xna.Framework.Graphics.Texture2D"/> content file.
        /// </summary>
        /// <remarks>
        /// The <see cref="Microsoft.Xna.Framework.Graphics.Texture2D"/> will be loaded from disk once the relevant <see cref="Komodo.Core.ECS.Systems.Render2DSystem.Initialize"/>, <see cref="Komodo.Core.ECS.Systems.Render2DSystem.PreUpdate"/>, or <see cref="Komodo.Core.ECS.Systems.Render2DSystem.PostUpdate"/> is called.
        /// </remarks>
        /// <param name="texturePath">File path to a compiled <see cref="Microsoft.Xna.Framework.Graphics.Model"/> content file.</param>
        /// <param name="shader">Shader used for rendering in a <see cref="Microsoft.Xna.Framework.Graphics.SpriteBatch"/>.</param>
        public SpriteComponent(string texturePath, Effect shader) : base(true, null)
        {
            Shader = shader;
            TexturePath = texturePath;
        }
        #endregion

        #region Members
        public override Vector2 Center => Texture != null ? new Vector2(Texture.Width / 2, Texture.Height / 2) : Vector2.Zero;

        /// <summary>
        /// Y dimensional extremity.
        /// </summary>
        public override float Height
        {
            get
            {
                return Texture.Height * Parent.Scale.Y;
            }
        }

        /// <summary>
        /// Raw texture data loaded from disk.
        /// </summary>
        public Texture Texture { get; set; }

        /// <summary>
        /// Path of the <see cref="Komodo.Core.Engine.Graphics.Texture"/> if the SpriteComponent was provided a texture filepath via <see cref="SpriteComponent.SpriteComponent(string, Effect)"/>.
        /// </summary>
        public string TexturePath { get; set; }

        /// <summary>
        /// X dimensional extremity.
        /// </summary>
        public override float Width
        {
            get
            {
                return Texture.Width * Parent.Scale.X;
            }
        }
        #endregion

        #endregion
    }
}