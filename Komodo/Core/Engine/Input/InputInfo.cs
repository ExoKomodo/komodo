using Komodo.Lib.Math;
using System;

namespace Komodo.Core.Engine.Input
{
    /// <summary>
    /// Represents available information from any user inputs.
    /// </summary>
    public readonly struct InputInfo : IEquatable<InputInfo>
    {
        #region Constructors
        /// <summary>
        /// Creates InputInfo for digital inputs.
        /// </summary>
        /// <param name="input">Input identifier.</param>
        /// <param name="state">State of the digital input.</param>
        internal InputInfo(Inputs input = Inputs.Undefined, InputState state = InputState.Undefined)
        {
            Direction = Vector2.Zero;
            Input = input;
            State = state;
            Strength = 0f;
        }

        /// <summary>
        /// Creates InputInfo for analog inputs.
        /// </summary>
        /// <param name="input">Input identifier.</param>
        /// <param name="state">State of the analog input.</param>
        /// <param name="direction">Direction of the analog input.</param>
        /// <param name="strength">Strength of the analog input.</param>
        internal InputInfo(Inputs input, InputState state, Vector2 direction, float strength = 0f)
        {
            if (strength > 1f)
            {
                strength = 1f;
            }
            else if (strength < -1f)
            {
                strength = -1f;
            }
            Direction = direction;
            Input = input;
            State = state;
            Strength = strength;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        /// <summary>
        /// Direction of the supplied <see cref="Komodo.Core.Engine.Input.Inputs"/>.
        /// </summary>
        public Vector2 Direction { get; }

        /// <summary>
        /// Identifier for which <see cref="Komodo.Core.Engine.Input.Inputs"/> the InputInfo is for.
        /// </summary>
        public Inputs Input { get; }

        /// <summary>
        /// State of the <see cref="Komodo.Core.Engine.Input.Inputs"/>.
        /// </summary>
        public InputState State { get; }

        /// <summary>
        /// Strength of the <see cref="Komodo.Core.Engine.Input.Inputs"/>.
        /// </summary>
        public float Strength { get; }
        #endregion Public Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        /// <summary>
        /// Compares the equality of InputInfo and an arbitrary type.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns>Whether or not the Object is equivalent.</returns>
        public override bool Equals(object obj)
        {
            if (obj is InputInfo other)
            {
                return Equals(other);
            }
            return false;
        }

        /// <summary>
        /// Compares the equality of InputInfo and another InputInfo.
        /// </summary>
        /// <param name="other">InputInfo to compare against.</param>
        /// <returns>Whether or not the other InputInfo is equivalent.</returns>
        public bool Equals(InputInfo other)
        {
            return Direction == other.Direction && Input == other.Input && State == other.State && Strength == other.Strength;
        }

        /// <summary>
        /// Generates a hashcode from the InputInfo.
        /// </summary>
        /// <returns>Summation of property hashcodes.</returns>
        public override int GetHashCode()
        {
            return Direction.GetHashCode() + Input.GetHashCode() + State.GetHashCode() + Strength.GetHashCode();
        }
        #endregion Public Member Methods

        #endregion Member Methods

        #region Static Methods

        #region Public Static Methods
        /// <returns>Whether or not the InputInfos are equivalent.</returns>
        public static bool operator ==(InputInfo left, InputInfo right)
        {
            return left.Equals(right);
        }

        /// <returns>Whether or not the InputInfos are not equivalent.</returns>
        public static bool operator !=(InputInfo left, InputInfo right)
        {
            return !(left == right);
        }
        #endregion Public Static Methods

        #endregion Static Methods
    }
}