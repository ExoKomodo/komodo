using Komodo.Core;
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
        public SpriteComponent(KomodoTexture texture)
        {
            IsEnabled = true;
            Parent = null;
            Texture = texture;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public bool IsEnabled { get; set; }
        [JsonIgnore]
        public IEntity Parent {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
            }
        }
        public KomodoTexture Texture { get; set; }
        #endregion Public Members

        #region Protected Members
        protected IEntity _parent { get; set; }
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