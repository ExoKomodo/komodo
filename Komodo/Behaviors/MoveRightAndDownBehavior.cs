using Komodo.Core;
using Komodo.Core.Engine.Components;
using Komodo.Core.Engine.Entities;
using Microsoft.Xna.Framework;

namespace Komodo.Behaviors
{
    public class MoveRightAndDownBehavior : BehaviorComponent
    {
        #region Constructors
        #endregion Constructors

        #region Members

        #region Public Members
        #endregion Public Members

        #region Protected Members
        #endregion Protected Members

        #region Private Members
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        public override void Update(GameTime gameTime)
        {
            Parent.Position = KomodoVector3.Add(
                Parent.Position,
                new KomodoVector3(
                    (float)(50f * gameTime.ElapsedGameTime.TotalSeconds),
                    (float)(100f * gameTime.ElapsedGameTime.TotalSeconds),
                    0f
                )
            );
        }
        #endregion Public Member Methods

        #region Protected Member Methods
        #endregion Protected Member Methods

        #region Private Member Methods
        #endregion Private Member Methods

        #endregion Member Methods
    }
}