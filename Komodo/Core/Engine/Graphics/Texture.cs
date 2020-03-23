using System;

using Color = Microsoft.Xna.Framework.Color;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;

namespace Komodo.Core.Engine.Graphics
{
    public class Texture : ITexture
    {
        #region Constructors
        public Texture(Texture2D monoGameTexture)
        {
            SetData(null);
            MonoGameTexture = monoGameTexture;
            _height = 0;
            _width = 0;
        }

        public Texture(
            GraphicsManager graphicsManager,
            Color[] data,
            int width,
            int height
        )
        {
            SetData(null);
            MonoGameTexture = null;
            _height = height;
            _width = width;

            Initialize(data, width, height);
            CreateMonoGameTexture(graphicsManager);
        }
        
        public Texture(
            GraphicsManager graphicsManager,
            Color[,] data
        )
        {
            SetData(null);
            MonoGameTexture = null;
            _height = 0;
            _width = 0;

            Initialize(data);
            CreateMonoGameTexture(graphicsManager);
        }

        #endregion Constructors

        #region Members

        #region Public Members
        private void SetData(Color[] value)
        {
            _data = value;
        }

        public int Height
        {
            get
            {
                return MonoGameTexture == null ? 0 : MonoGameTexture.Height;
            }
        }

        public int Width
        {
            get
            {
                return MonoGameTexture == null ? 0 : MonoGameTexture.Width;
            }
        }
        public Texture2D MonoGameTexture { get; private set; }
        #endregion Public Members

        #region Private Members
        private int _height { get; set; }
        private int _width { get; set; }
        private Color[] _data;
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        public Color[] GetData()
        {
            return _data;
        }
        #endregion Public Member Methods

        #region Private Member Methods
        private void CreateMonoGameTexture(GraphicsManager graphicsManager)
        {
            var graphicsDevice = graphicsManager.GraphicsDeviceManager.GraphicsDevice;
            MonoGameTexture = new Texture2D(graphicsDevice, _width, _height);
            MonoGameTexture.SetData(GetData());
        }

        private void Initialize(
            Color[] data,
            int width,
            int height
        )
        {
            if (data == null)
            {
                // TODO: Create data cannot be null exception
                throw new Exception("Data cannot be null");
            }
            if (data.Length != width * height)
            {
                // TODO: Create data was the wrong size exception
                throw new Exception("Data was the wrong size");
            }
            SetData(data);
        }

        private void Initialize(Color[,] data)
        {
            if (data == null)
            {
                // TODO: Create data cannot be null exception
                throw new Exception("Data cannot be null");
            }
            if (data.Length == 0)
            {
                SetData(null);
            }
            else
            {
                _height = data.Rank;
                _width = data.GetLength(0);
                SetData(new Color[_width * _height]);
                int i = 0;
                foreach (Color color in data)
                {
                    GetData()[i] = color;
                    i++;
                }
            }
        }

        #endregion Private Member Methods

        #endregion Member Methods
    }
}