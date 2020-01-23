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
        List<IComponent> Components { get; }
        Vector3 Position { get; set; }
        float Rotation { get; set; }
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
