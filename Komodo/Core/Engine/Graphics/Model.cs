namespace Komodo.Core.Engine.Graphics
{
    public class Model : IModel
    {
        #region Constructors
        public Model(Microsoft.Xna.Framework.Graphics.Model monoGameModel)
        {
            MonoGameModel = monoGameModel;
            _height = 0f;
            _width = 0f;
            _depth = 0f;
        }
        #endregion Constructors

        #region Members

        #region Public Members

        public float Height
        {
            get
            {
                return _height;
            }
        }

        public float Width
        {
            get
            {
                return _width;
            }
        }
        public float Depth
        {
            get
            {
                return _depth;
            }
        }
        public Microsoft.Xna.Framework.Graphics.Model MonoGameModel { get; private set; }
        #endregion Public Members

        #region Private Members
        private float _height { get; set; }
        private float _width { get; set; }
        private float _depth { get; set; }
        #endregion Private Members

        #endregion Members
    }
}