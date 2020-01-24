using System.Collections.Generic;
using System.Text.Json.Serialization;
using Komodo.Core.Engine.Components;
using Komodo.Core.Engine.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Komodo.Core.Engine.Entities
{
    public interface IEntity
    {
        #region Members

        #region Public Members
        List<IEntity> Children { get; set; }
        List<IComponent> Components { get; }
        [JsonIgnore]
        IEntity ParentEntity { get; set; }
        [JsonIgnore]
        IScene ParentScene { get; set; }
        Vector3 Position { get; set; }
        float Rotation { get; set; }
        Vector2 Scale { get; set; }
        #endregion Public Members

        #endregion Members

        #region Member Methods
        
        #region Public Member Methods
        void AddComponent(IComponent componentToAdd);
        void ClearComponents();
        void Draw(SpriteBatch spriteBatch);
        bool RemoveComponent(IComponent componentToRemove);
        void Update(GameTime gameTime);
        #endregion Public Member Methods
        
        #endregion Member Methods
    }
}
