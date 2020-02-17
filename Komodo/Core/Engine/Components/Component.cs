using System.Text.Json.Serialization;
using Komodo.Core.Engine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Komodo.Core.Engine.Components
{
    public abstract class Component : ISerializable<Component>
    {
        #region Constructors
        public Component(bool isEnabled = true, Entity parent = null)
        {
            IsEnabled = isEnabled;
            Parent = parent;
        }
        #endregion

        #region Members

        #region Public Members
        public bool IsEnabled { get; set; }
        [JsonIgnore]
        public Entity Parent { get; set; }
        #endregion Public Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        public abstract void Deserialize(SerializedObject serializedObject);
        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
        public abstract SerializedObject Serialize();
        public virtual void Update(GameTime gameTime)
        {
            
        }
        #endregion Public Member Methods
        
        #endregion Member Methods
    }
}
