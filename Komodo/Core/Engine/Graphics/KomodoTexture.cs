using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Komodo.Core.Engine.Graphics
{
    public struct KomodoTexture : IKomodoTexture
    {
        #region Constructors
        public KomodoTexture(
            IGraphicsManager graphicsManager,
            Color[] data,
            int width,
            int height
        )
        {
            Data = null;
            Width = 0;
            Height = 0;
            MonoGameTexture = null;

            Initialize(data, width, height);
            CreateMonoGameTexture(graphicsManager);
        }
        
        public KomodoTexture(
            IGraphicsManager graphicsManager,
            Color[,] data
        )
        {
            Data = null;
            Width = 0;
            Height = 0;
            MonoGameTexture = null;

            Initialize(data);
            CreateMonoGameTexture(graphicsManager);
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public Color[] Data { get; private set; }

        public int Height { get; private set; }

        public int Width { get; private set; }
        public Texture2D MonoGameTexture { get; private set; }
        #endregion Public Members

        #region Private Members
        private void CreateMonoGameTexture(IGraphicsManager graphicsManager)
        {
            if (graphicsManager is GraphicsManagerMonoGame)
            {
                var graphicsDevice = ((GraphicsManagerMonoGame)graphicsManager)._graphicsDeviceManager.GraphicsDevice;
                MonoGameTexture = new Texture2D(graphicsDevice, Width, Height);
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
            Height = height;
            Width = width;
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
                Height = 0;
                Width = 0;
            }
            else
            {
                Height = data.Rank;
                Width = data.GetLength(0);
                Data = new Color[Width * Height];
                int i = 0;
                foreach (Color color in data)
                {
                    Data[i] = color;
                    i++;
                }
            }
        }
        #endregion Private Members

        #endregion Members
    }
}