using Komodo.Lib.Math;
using System;

namespace Komodo.Core.Engine.Input
{
    public readonly struct InputInfo : IEquatable<InputInfo>
    {
        #region Constructors
        public InputInfo(InputState state = InputState.Undefined)
        {
            Amplitude = 0f;
            Direction = Vector2.Zero;
            State = state;
        }

        public InputInfo(InputState state, Vector2 direction, float amplitude = 0f)
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
            Direction = Vector2.Normalize(direction);
            State = state;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public float Amplitude { get; }
        public Vector2 Direction { get; }
        public InputState State { get; }
        #endregion Public Members

        #endregion Members

        #region Static Members

        #region Public Static Members
        #endregion Public Static Members

        #endregion Static Members

        #region Member Methods

        #region Public Member Methods
        public override bool Equals(object obj)
        {
            if (obj is InputInfo other)
            {
                return Equals(other);
            }
            return false;
        }

        public bool Equals(InputInfo other)
        {
            return Amplitude == other.Amplitude && Direction == other.Direction && State == other.State;
        }

        public override int GetHashCode()
        {
            return Amplitude.GetHashCode() + Direction.GetHashCode() + State.GetHashCode();
        }
        #endregion Public Member Methods

        #endregion Member Methods

        #region Static Methods

        #region Public Static Methods
        public static bool operator ==(InputInfo left, InputInfo right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(InputInfo left, InputInfo right)
        {
            return !(left == right);
        }
        #endregion Public Static Methods

        #endregion Static Methods
    }
}