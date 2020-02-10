namespace Komodo.Core.Engine.Input
{
    public readonly struct InputInfo
    {
        #region Constructors
        public InputInfo(InputState state = InputState.Undefined)
        {
            Amplitude = 0f;
            Direction = KomodoVector2.Zero;
            State = state;
        }

        public InputInfo(InputState state, KomodoVector2 direction, float amplitude = 0f)
        {
            if (amplitude > 1f)
            {
                amplitude = 1f;
            }
            else if (amplitude < -1f)
            {
                amplitude = -1f;
            }
            Amplitude = amplitude;
            Direction = KomodoVector2.Normalize(direction);
            State = state;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public float Amplitude { get; }
        public KomodoVector2 Direction { get; }
        public InputState State { get; }
        #endregion Public Members

        #endregion Members

        #region Static Members
        
        #region Public Static Members
        #endregion Public Static Members
        
        #endregion Static Members

        #region Member Methods
        
        #region Public Member Methods
        #endregion Public Member Methods
        
        #endregion Member Methods

        #region Static Methods

        #region Public Static Methods
        #endregion Public Static Methods

        #endregion Static Methods
    }
}