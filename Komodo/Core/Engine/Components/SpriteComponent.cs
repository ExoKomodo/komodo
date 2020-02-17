using System.Text.Json.Serialization;
using Komodo.Core.Engine.Entities;
using Komodo.Core.Engine.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Komodo.Core.Engine.Components
{
    public class SpriteComponent : Component
    {
        #region Constructors
        public SpriteComponent(KomodoTexture texture, Effect shader = null) : base(true, null)
        {
            Texture = texture;
            TexturePath = null;

            Shader = shader;
        }
        public SpriteComponent(string texturePath, Effect shader = null)
        {
            IsEnabled = true;
            Parent = null;
            var loadedTexture = KomodoGame.Content.Load<Texture2D>(texturePath);
            Texture = new KomodoTexture(loadedTexture);
            TexturePath = texturePath;

            Shader = shader;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public float Height
        {
            get
            {
                return Texture.Height * Parent.Scale.Y;
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
        public KomodoTexture Texture { get; set; }
        public string TexturePath { get; set; }
        public float Width
        {
            get
            {
                return Texture.Width * Parent.Scale.X;
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
            spriteBatch.Draw(
                Texture.MonoGameTexture,
                Parent.Position.XY.MonoGameVector,
                null,
                Color.White,
                Parent.Rotation,
                KomodoVector2.Zero.MonoGameVector,
                Parent.Scale.MonoGameVector,
                SpriteEffects.None,
                Parent.Position.Z
            );
        }

        public override SerializedObject Serialize()
        {
            var serializedObject = new SerializedObject();
            serializedObject.Type = this.GetType().ToString();
            
            // serializedObject.Properties["Texture"] = Texture;

            return serializedObject;
        }

        sealed public override void Update(GameTime gameTime)
        {
        }
        #endregion Public Member Methods

        #region Protected Member Methods
        #endregion Protected Member Methods

        #region Private Member Methods
        #endregion Private Member Methods

        #endregion Member Methods
    }
}