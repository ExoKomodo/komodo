using Komodo.Core.Engine.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Komodo.Core.ECS.Components
{
    public class SpriteComponent : Drawable2DComponent
    {
        #region Constructors
        public SpriteComponent(KomodoTexture texture, Effect shader = null) : base(true, null, shader)
        {
            Texture = texture;
            TexturePath = null;
        }
        public SpriteComponent(string texturePath, Effect shader = null) : base(true, null, shader)
        {
            var loadedTexture = KomodoGame.Content.Load<Texture2D>(texturePath);
            Texture = new KomodoTexture(loadedTexture);
            TexturePath = texturePath;
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
                WorldPosition.XY.MonoGameVector,
                null,
                Color.White,
                Rotation.Z,
                KomodoVector2.Zero.MonoGameVector,
                Scale.XY.MonoGameVector,
                SpriteEffects.None,
                WorldPosition.Z
            );
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