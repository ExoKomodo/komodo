namespace Komodo.Core.Engine.Graphics
{
    public struct Resolution
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
    }
}
