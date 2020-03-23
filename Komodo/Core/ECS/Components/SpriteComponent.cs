using Komodo.Core.Engine.Graphics;
using Komodo.Lib.Math;

using Effect = Microsoft.Xna.Framework.Graphics.Effect;

namespace Komodo.Core.ECS.Components
{
    public class SpriteComponent : Drawable2DComponent
    {
        #region Constructors
        public SpriteComponent(Engine.Graphics.Texture texture, Effect shader) : base(true, null)
        {
            Shader = shader;
            Texture = texture;
            TexturePath = null;
        }
        public SpriteComponent(string texturePath, Effect shader) : base(true, null)
        {
            Shader = shader;
            TexturePath = texturePath;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public override Vector2 Center => Texture != null ? new Vector2(Texture.Width / 2, Texture.Height / 2) : Vector2.Zero;
        public override float Height
        {
            get
            {
                return Texture.Height * Parent.Scale.Y;
            }
        }
        public Engine.Graphics.Texture Texture { get; set; }
        public string TexturePath { get; set; }
        public override float Width
        {
            get
            {
                return Texture.Width * Parent.Scale.X;
            }
        }
        #endregion Public Members

        #region Protected Members
        #endregion Protected Members

        #region Private Members
        #endregion Private Members

        #endregion Members
    }
}