using System.Text.Json.Serialization;
using Komodo.Core.Engine.Entities;
using Komodo.Core.Engine.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Komodo.Core.Engine.Components
{
    public class SpriteComponent : IComponent
    {
        #region Constructors
        public SpriteComponent(KomodoTexture texture, Effect shader = null)
        {
            IsEnabled = true;
            Parent = null;
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
        public bool IsEnabled { get; set; }
        [JsonIgnore]
        public Entity Parent {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
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
        protected Entity _parent { get; set; }
        protected Effect _shader { get; set; }
        #endregion Protected Members

        #region Private Members
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        public void Deserialize(SerializedObject serializedObject)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
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

        public SerializedObject Serialize()
        {
            var serializedObject = new SerializedObject();
            serializedObject.Type = this.GetType().ToString();
            
            // serializedObject.Properties["Texture"] = Texture;

            return serializedObject;
        }

        public void Update(GameTime gameTime)
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