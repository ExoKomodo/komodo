using Komodo.Lib.Math;

using Color = Microsoft.Xna.Framework.Color;

using Effect = Microsoft.Xna.Framework.Graphics.Effect;
using SpriteFont = Microsoft.Xna.Framework.Graphics.SpriteFont;

namespace Komodo.Core.ECS.Components
{
    /// <summary>
    /// Represents any 2D text to be drawn in a <see cref="Komodo.Core.ECS.Systems.Render2DSystem"/>
    /// </summary>
    public class TextComponent : Drawable2DComponent
    {
        #region Constructors
        /// <summary>
        /// Creates a TextComponent with a given <see cref="Microsoft.Xna.Framework.Graphics.SpriteFont"/>.
        /// </summary>
        /// <param name="font">SpriteFont reference containing the raw font data.</param>
        /// <param name="color">Color for each glyph to be drawn with.</param>
        /// <param name="shader">Shader used for rendering in a <see cref="Microsoft.Xna.Framework.Graphics.SpriteBatch"/>.</param>
        /// <param name="text">Text message to be rendered.</param>
        public TextComponent(SpriteFont font, Color color, Effect shader, string text = null) : base(true, null)
        {
            Color = color;
            Font = font;
            FontPath = null;
            Shader = shader;
            Text = text;
        }

        /// <summary>
        /// Creates a TextComponent with a filepath to a compiled <see cref="Microsoft.Xna.Framework.Graphics.SpriteFont"/> content file.
        /// </summary>
        /// <param name="fontPath">File path to a compiled <see cref="Microsoft.Xna.Framework.Graphics.SpriteFont"/> content file.</param>
        /// <param name="color">Color for each glyph to be drawn with.</param>
        /// <param name="shader">Shader used for rendering in a <see cref="Microsoft.Xna.Framework.Graphics.SpriteBatch"/>.</param>
        /// <param name="text">Text message to be rendered.</param>
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
        
        /// <summary>
        /// Raw font data loaded from disk.
        /// </summary>
        public SpriteFont Font { get; set; }
        
        /// <summary>
        /// Path of the <see cref="Microsoft.Xna.Framework.Graphics.SpriteFont"/> if the TextComponent was provided a font filepath via <see cref="TextComponent.TextComponent(string, Color, Effect, string)"/>.
        /// </summary>
        public string FontPath { get; set; }

        /// <summary>
        /// Y dimensional extremity.
        /// </summary>
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

        /// <summary>
        /// Flags whether or not to draw the TextComponent with the center or the top-left side as origin.
        /// </summary>
        public bool IsCentered { get; set; }

        /// <summary>
        /// Text message to be rendered.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// X dimensional extremity.
        /// </summary>
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

        #endregion Members
    }
}