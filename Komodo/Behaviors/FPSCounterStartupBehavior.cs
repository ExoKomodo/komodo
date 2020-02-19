using Komodo.Core;
using Komodo.Core.Engine.Components;
using Komodo.Core.Engine.Input;
using Microsoft.Xna.Framework;

namespace Komodo.Behaviors
{
    public class FPSCounterStartupBehavior : BehaviorComponent
    {
        #region Constructors
        public FPSCounterStartupBehavior() : base()
        {
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public bool IsInitialized
        {
            get;
            private set;
        }
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
            if (!IsInitialized)
            {
                IsInitialized = true;
                var textComponent = new TextComponent("fonts/font", Color.Black, "");
                Parent.AddComponent(textComponent);
                Parent.AddComponent(new FPSCounterBehavior(textComponent));
            }
        }
        #endregion Public Member Methods

        #region Protected Member Methods
        #endregion Protected Member Methods

        #region Private Member Methods
        #endregion Private Member Methods

        #endregion Member Methods
    }
}