using System.Text.Json.Serialization;
using Komodo.Core.Engine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Komodo.Core.Engine.Components
{
    public interface IComponent : ISerializable<IComponent>
    {
        #region Members

        #region Public Members
        [JsonIgnore]
        IEntity Parent { get; set; }
        #endregion Public Members

        #endregion Members

        #region Member Methods
        
        #region Public Member Methods
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
        #endregion Public Member Methods
        
        #endregion Member Methods
    }
}
