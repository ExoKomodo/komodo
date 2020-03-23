using Komodo.Lib.Math;

using Color = Microsoft.Xna.Framework.Color;

using Effect = Microsoft.Xna.Framework.Graphics.Effect;
using SpriteFont = Microsoft.Xna.Framework.Graphics.SpriteFont;

namespace Komodo.Core.ECS.Components
{
    public class TextComponent : Drawable2DComponent
    {
        #region Constructors
        public TextComponent(SpriteFont font, Color color, Effect shader, string text = null) : base(true, null)
        {
            Color = color;
            Font = font;
            FontPath = null;
            Shader = shader;
            Text = text;
        }
        public TextComponent(string fontPath, Color color, Effect shader, string text = null) : base(true, null)
        {
            Color = color;
            FontPath = fontPath;
            Shader = shader;
            Text = text;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public override Vector2 Center => new Vector2(Width / 2, Height / 2);
        public Color Color { get; set; }
        public SpriteFont Font { get; set; }
        public string FontPath { get; set; }
        public override float Height
        {
            get
            {
                if (Font == null)
                {
                    return 0f;
                }
                var size = new Vector2(Font.MeasureString(Text));
                return size.Y * Scale.Y;
            }
        }
        public bool IsCentered { get; set; }
        public string Text { get; set; }
        public override float Width
        {
            get
            {
                if (Font == null)
                {
                    return 0f;
                }
                var size = new Vector2(Font.MeasureString(Text));
                return size.X * Scale.X;
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