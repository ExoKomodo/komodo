using Komodo.Core.Engine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Komodo.Core.Engine.Components
{
    public class SpriteComponent : IComponent
    {
        #region Constructors
        public SpriteComponent(Entity parentEntity, Texture2D texture)
        {
            ParentEntity = parentEntity;
            Texture = texture;
            
            Scale = Vector2.One;
            Tint = Color.White;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public Vector2 Scale { get; set; }
        public Color Tint { get; set; }
        public Entity ParentEntity { get; set; }
        public Texture2D Texture { get; set; }
        #endregion Public Members

        #region Protected Members
        #endregion Protected Members

        #region Private Members
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                Texture,
                new Vector2(ParentEntity.Position.X, ParentEntity.Position.Y),
                null,
                Tint,
                ParentEntity.Rotation,
                Vector2.Zero,
                Scale,
                SpriteEffects.None,
                ParentEntity.Position.Z
            );
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