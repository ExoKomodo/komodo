using System;

namespace Komodo.Core.Engine.Graphics
{
    public readonly struct Resolution : IEquatable<Resolution>
    {
        #region Constructors
        public Resolution(int width, int height)
        {
            Width = width;
            Height = height;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public readonly int Width;
        public readonly int Height;
        #endregion Public Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        public override bool Equals(object obj)
        {
            if (obj is Resolution other)
            {
                return Equals(other);
            }
            return false;
        }

        public bool Equals(Resolution other)
        {
            return Width == other.Width && Height == other.Height;
        }

        public override int GetHashCode()
        {
            return Width.GetHashCode() + Height.GetHashCode();
        }
        #endregion Public Member Methods

        #endregion Member Methods

        #region Static Methods

        #region Public Static Methods
        public static bool operator ==(Resolution left, Resolution right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Resolution left, Resolution right)
        {
            return !(left == right);
        }
        #endregion Public Static Methods

        #endregion Static Methods
    }
}
