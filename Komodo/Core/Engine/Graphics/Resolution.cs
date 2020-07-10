using System;

namespace Komodo.Core.Engine.Graphics
{
    /// <summary>
    /// Represents a screen resolution.
    /// </summary>
    public readonly struct Resolution : IEquatable<Resolution>
    {
        #region Public

        #region Constructors
        /// <param name="width">Width of screen.</param>
        /// <param name="height">Width of screen.</param>
        public Resolution(int width, int height)
        {
            Width = width;
            Height = height;
        }
        #endregion

        #region Members
        /// <summary>
        /// Aspect ratio of the resolution.
        /// </summary>
        public float AspectRatio => Height == 0 ? 0 : Width / (float)Height;

        /// <summary>
        /// Height of the screen resolution.
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Width of the screen resolution.
        /// </summary>
        public int Width { get; }
        #endregion

        #region Member Methods
        /// <summary>
        /// Compares the equality of Resolution and an arbitrary type.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns>Whether or not the Object is equivalent.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Resolution other)
            {
                return Equals(other);
            }
            return false;
        }

        /// <summary>
        /// Compares the equality of Resolution and another Resolution.
        /// </summary>
        /// <param name="other">Resolution to compare against.</param>
        /// <returns>Whether or not the other Resolution is equivalent.</returns>
        public bool Equals(Resolution other)
        {
            return Width == other.Width && Height == other.Height;
        }

        /// <summary>
        /// Generates a hashcode from the Resolution.
        /// </summary>
        /// <returns>Summation of property hashcodes.</returns>
        public override int GetHashCode()
        {
            return Width.GetHashCode() + Height.GetHashCode();
        }
        #endregion

        #region Static Methods
        /// <returns>Whether or not the Resolutions are equivalent.</returns>
        public static bool operator ==(Resolution left, Resolution right)
        {
            return left.Equals(right);
        }

        /// <returns>Whether or not the Resolutions are not equivalent.</returns>
        public static bool operator !=(Resolution left, Resolution right)
        {
            return !(left == right);
        }
        #endregion

        #endregion
    }
}
