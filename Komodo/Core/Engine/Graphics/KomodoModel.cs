using Microsoft.Xna.Framework.Graphics;

namespace Komodo.Core.Engine.Graphics
{
    public class KomodoModel : IKomodoModel
    {
        #region Constructors
        public KomodoModel(Model monoGameModel)
        {
            MonoGameModel = monoGameModel;
            _height = 0f;
            _width = 0f;
            _depth = 0f;
        }

        public KomodoModel(
            GraphicsManager graphicsManager,
            float width,
            float height,
            float depth
        )
        {
            MonoGameModel = null;
            _height = height;
            _width = width;
            _depth = depth;

            // Initialize(data, width, height);
            // CreateMonoGameTexture(graphicsManager);
        }
        
        public KomodoModel(GraphicsManager graphicsManager)
        {
            MonoGameModel = null;
            _height = 0f;
            _width = 0f;
            _depth = 0f;

            // Initialize(data);
            // CreateMonoGameTexture(graphicsManager);
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
        public Model MonoGameModel { get; private set; }
        #endregion Public Members

        #region Private Members
        private float _height { get; set; }
        private float _width { get; set; }
        private float _depth { get; set; }
        #endregion Private Members

        #endregion Members

        #region Member Methods
        
        #region Private Member Methods
        private void CreateMonoGameModel(GraphicsManager graphicsManager)
        {
        }

        private void Initialize(
            float width,
            float height,
            float depth
        )
        {
            // if (data == null)
            // {
            //     // TODO: Create data cannot be null exception
            //     throw new Exception("Data cannot be null");
            // }
            // if (data.Length != width * height)
            // {
            //     // TODO: Create data was the wrong size exception
            //     throw new Exception("Data was the wrong size");
            // }
            // Data = data;
        }

        private void Initialize()
        {
            // if (data == null)
            // {
            //     // TODO: Create data cannot be null exception
            //     throw new Exception("Data cannot be null");
            // }
            // if (data.Length == 0)
            // {
            //     Data = null;
            // }
            // else
            // {
            //     _height = data.Rank;
            //     _width = data.GetLength(0);
            //     Data = new Color[_width * _height];
            //     int i = 0;
            //     foreach (Color color in data)
            //     {
            //         Data[i] = color;
            //         i++;
            //     }
            // }
        }

        #endregion Private Member Methods

        #endregion Member Methods
    }
}