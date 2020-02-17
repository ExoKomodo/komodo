using System.Text.Json.Serialization;
using Komodo.Core.Engine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Komodo.Core.Engine.Components
{
    public abstract class AudioComponent : Component, ISerializable<AudioComponent>
    {
        #region Constructors
        public AudioComponent() : base(true, null)
        {
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public KomodoGame Game
        {
            get
            {
                return Parent.ParentScene.Game;
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
        }

        public override SerializedObject Serialize()
        {
            var serializedObject = new SerializedObject();

            return serializedObject;
        }

        public override void Update(GameTime gameTime)
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