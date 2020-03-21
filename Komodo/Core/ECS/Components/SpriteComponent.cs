using Komodo.Core.Engine.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Komodo.Core.ECS.Components
{
    public class SpriteComponent : Drawable2DComponent
    {
        #region Constructors
        public SpriteComponent(KomodoTexture texture, Effect shader) : base(true, null, shader)
        {
            Texture = texture;
            TexturePath = null;
        }
        public SpriteComponent(string texturePath, Effect shader) : base(true, null, shader)
        {
            var loadedTexture = KomodoGame.Content.Load<Texture2D>(texturePath);
            Texture = new KomodoTexture(loadedTexture);
            TexturePath = texturePath;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public KomodoVector2 Center => Texture != null ? new KomodoVector2(Texture.Width / 2, Texture.Height / 2) : KomodoVector2.Zero;
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
            var position = WorldPosition;
            var rotation = Rotation;
            var scale = Scale;
            var camera = Parent.ParentScene.ActiveCamera;
            if (camera != null)
            {
                if (IsBillboard)
                {
                    position = KomodoVector3.Transform(
                        position,
                        camera.ViewMatrix * Matrix.CreateScale(1f, -1f, 1f)
                    );  
                }
                else
                {
                    position = KomodoVector3.Transform(
                        position,
                        Matrix.CreateScale(1f, -1f, 1f)
                    );
                }
                rotation += camera.Rotation;
                scale *= camera.Zoom;
            }
            
            spriteBatch.Draw(
                Texture.MonoGameTexture,
                position.XY.MonoGameVector,
                null,
                Color.White,
                -rotation.Z,
                Center.MonoGameVector,
                scale.XY.MonoGameVector,
                SpriteEffects.None,
                position.Z
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