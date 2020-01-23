using System.Collections.Generic;

using Komodo.Core.Engine.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Komodo.Core.Engine.Entities
{
    public interface IEntity
    {
        #region Members

        #region Public Members
        List<IEntity> Children { get; set; }
        List<IComponent> Components { get; set; }
        IEntity Parent { get; set; }
        Vector3 Position { get; set; }
        float Rotation { get; set; }
        Vector2 Scale { get; set; }
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
