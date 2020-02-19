using System.Text.Json.Serialization;
using Komodo.Core.Engine.Entities;
using Komodo.Core.Engine.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Komodo.Core.Engine.Components
{
    public class TextComponent : Component
    {
        #region Constructors
        public TextComponent(SpriteFont font, Color color, string text = null, Effect shader = null) : base(true, null)
        {
            Color = color;
            Font = font;
            FontPath = null;
            Text = text;

            Shader = shader;
        }
        public TextComponent(string fontPath, Color color, string text = null, Effect shader = null)
        {
            Color = color;
            Font = KomodoGame.Content.Load<SpriteFont>(fontPath);
            FontPath = fontPath;
            Text = text;

            Shader = shader;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public Color Color { get; set; }
        public bool Fixed { get; set; }
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
        public Effect Shader
        {
            get
            {
                if (_shader == null)
                {
                    return Parent.ParentScene.Game.DefaultShader;
                }
                return _shader;
            }
            set
            {
                _shader = value;
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
        protected Effect _shader { get; set; }
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
                if (Fixed && camera != null)
                {
                    position = KomodoVector3.Add(position, camera.Position);
                }
                spriteBatch.DrawString(
                    Font,
                    Text,
                    position.XY.MonoGameVector,
                    Color,
                    Rotation,
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