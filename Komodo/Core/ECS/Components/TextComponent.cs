using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Komodo.Core.ECS.Components
{
    public class TextComponent : Drawable2DComponent
    {
        #region Constructors
        public TextComponent(SpriteFont font, Color color, string text = null, Effect shader = null) : base(true, null, shader)
        {
            Color = color;
            Font = font;
            FontPath = null;
            Text = text;
        }
        public TextComponent(string fontPath, Color color, string text = null, Effect shader = null) : base(true, null, shader)
        {
            Color = color;
            Font = KomodoGame.Content.Load<SpriteFont>(fontPath);
            FontPath = fontPath;
            Text = text;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public Color Color { get; set; }
        public SpriteFont Font { get; set; }
        public string FontPath { get; set; }
        public float Height
        {
            get
            {
                if (Font == null)
                {
                    return 0f;
                }
                var size = new KomodoVector2(Font.MeasureString(Text));
                return size.Y * Scale.Y;
            }
        }
        public string Text { get; set; }
        public float Width
        {
            get
            {
                if (Font == null)
                {
                    return 0f;
                }
                var size = new KomodoVector2(Font.MeasureString(Text));
                return size.X * Scale.X;
            }
        }
        #endregion Public Members

        #region Protected Members
        #endregion Protected Members

        #region Private Members
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        public override void Deserialize(SerializedObject serializedObject)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Font != null && Text != null)
            {
                var position = WorldPosition;
                var camera = Parent.ParentScene.ActiveCamera;
                spriteBatch.DrawString(
                    Font,
                    Text,
                    position.XY.MonoGameVector,
                    Color,
                    Rotation.Z,
                    KomodoVector2.Zero.MonoGameVector,
                    Scale.XY.MonoGameVector,
                    SpriteEffects.None,
                    Position.Z
                );
            }
        }

        public override SerializedObject Serialize()
        {
            var serializedObject = new SerializedObject();
            serializedObject.Type = this.GetType().ToString();

            return serializedObject;
        }
        #endregion Public Member Methods

        #region Protected Member Methods
        #endregion Protected Member Methods

        #region Private Member Methods
        #endregion Private Member Methods

        #endregion Member Methods
    }
}