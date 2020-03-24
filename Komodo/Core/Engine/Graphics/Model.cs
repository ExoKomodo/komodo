namespace Komodo.Core.Engine.Graphics
{
    /// <summary>
    /// Represents raw 3D model data.
    /// </summary>
    public class Model
    {
        #region Constructors
        /// <param name="monoGameModel"><see cref="Microsoft.Xna.Framework.Graphics.Model"/> data loaded in MonoGame's format.</param>
        public Model(Microsoft.Xna.Framework.Graphics.Model monoGameModel)
        {
            MonoGameModel = monoGameModel;
            Depth = 0f;
            Height = 0f;
            Width = 0f;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        /// <summary>
        /// Z dimensional extremity.
        /// </summary>
        public float Depth { get; private set; }

        /// <summary>
        /// Y dimensional extremity.
        /// </summary>
        public float Height { get; private set; }

        /// <summary>
        /// X dimensional extremity.
        /// </summary>
        public float Width { get; private set; }

        /// <summary>
        /// Raw 3D model data.
        /// </summary>
        public Microsoft.Xna.Framework.Graphics.Model MonoGameModel { get; private set; }
        #endregion Public Members

        #endregion Members
    }
}