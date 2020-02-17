using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Komodo.Core.Engine.Graphics
{
    public struct KomodoTexture : IKomodoTexture
    {
        #region Constructors
        public KomodoTexture(Texture2D monoGameTexture)
        {
            Data = null;
            MonoGameTexture = monoGameTexture;
            _height = 0;
            _width = 0;
        }

        public KomodoTexture(
            IGraphicsManager graphicsManager,
            Color[] data,
            int width,
            int height
        )
        {
            Data = null;
            MonoGameTexture = null;
            _height = height;
            _width = width;

            Initialize(data, width, height);
            CreateMonoGameTexture(graphicsManager);
        }
        
        public KomodoTexture(
            IGraphicsManager graphicsManager,
            Color[,] data
        )
        {
            Data = null;
            MonoGameTexture = null;
            _height = 0;
            _width = 0;

            Initialize(data);
            CreateMonoGameTexture(graphicsManager);
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public Color[] Data { get; private set; }

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
        #endregion Private Members

        #endregion Members

        #region Member Methods
        
        #region Private Member Methods
        private void CreateMonoGameTexture(IGraphicsManager graphicsManager)
        {
            if (graphicsManager is GraphicsManagerMonoGame)
            {
                var graphicsDevice = ((GraphicsManagerMonoGame)graphicsManager).GraphicsDeviceManager.GraphicsDevice;
                MonoGameTexture = new Texture2D(graphicsDevice, _width, _height);
                MonoGameTexture.SetData(Data);
            }
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
            Data = data;
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
                Data = null;
            }
            else
            {
                _height = data.Rank;
                _width = data.GetLength(0);
                Data = new Color[_width * _height];
                int i = 0;
                foreach (Color color in data)
                {
                    Data[i] = color;
                    i++;
                }
            }
        }

        #endregion Private Member Methods

        #endregion Member Methods
    }
}