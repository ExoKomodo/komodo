using System;

using Color = Microsoft.Xna.Framework.Color;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;

namespace Komodo.Core.Engine.Graphics
{
    /// <summary>
    /// Represents raw texture data.
    /// </summary>
    public class Texture
    {
        #region Constructors
        /// <summary>
        /// Creates a Texture from <see cref="Microsoft.Xna.Framework.Graphics.Texture2D"/> data.
        /// </summary>
        /// <param name="monoGameTexture"><see cref="Microsoft.Xna.Framework.Graphics.Texture2D"/> data loaded in MonoGame's format.</param>
        public Texture(Texture2D monoGameTexture)
        {
            SetData(null);
            MonoGameTexture = monoGameTexture;
            _height = 0;
            _width = 0;
        }

        /// <summary>
        /// Constructs a new Texture from raw <see cref="Microsoft.Xna.Framework.Color"/> data.
        /// </summary>
        /// <param name="graphicsManager"></param>
        /// <param name="data">1D array of <see cref="Microsoft.Xna.Framework.Color"/> data.</param>
        /// <param name="width">Width of the <see cref="Komodo.Core.Engine.Graphics.Texture"/> to generate.</param>
        /// <param name="height">Height of the <see cref="Komodo.Core.Engine.Graphics.Texture"/> to generate.</param>
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

        /// <summary>
        /// Constructs a new Texture from raw <see cref="Microsoft.Xna.Framework.Color"/> data.
        /// </summary>
        /// <param name="graphicsManager"></param>
        /// <param name="data">2D array of <see cref="Microsoft.Xna.Framework.Color"/> data.</param>
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
        /// <summary>
        /// Height of the Texture data.
        /// </summary>
        public int Height
        {
            get
            {
                return MonoGameTexture == null ? 0 : MonoGameTexture.Height;
            }
        }

        /// <summary>
        /// Width of the Texture data.
        /// </summary>
        public int Width
        {
            get
            {
                return MonoGameTexture == null ? 0 : MonoGameTexture.Width;
            }
        }

        /// <summary>
        /// Raw MonoGame <see cref="Microsoft.Xna.Framework.Graphics.Texture2D"/>.
        /// </summary>
        public Texture2D MonoGameTexture { get; private set; }
        #endregion Public Members

        #region Private Members
        /// <summary>
        /// Used to store the Texture height from <see cref="Initialize"/> to be used in <see cref="CreateMonoGameTexture(GraphicsManager)"/>.
        /// </summary>
        private int _height { get; set; }

        /// <summary>
        /// Used to store the Texture width from <see cref="Initialize"/> to be used in <see cref="CreateMonoGameTexture(GraphicsManager)"/>.
        /// </summary>
        private int _width { get; set; }

        /// <summary>
        /// Raw <see cref="Microsoft.Xna.Framework.Color"/> data.
        /// </summary>
        private Color[] _data;
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        /// <summary>
        /// Accessor for raw <see cref="Microsoft.Xna.Framework.Color"/> data.
        /// </summary>
        /// <returns></returns>
        public Color[] GetData()
        {
            return _data;
        }
        #endregion Public Member Methods

        #region Private Member Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="graphicsManager">The <see cref="Komodo.Core.Engine.Graphics.GraphicsManager"/> is needed to generate a Texture, as the <see cref="Microsoft.Xna.Framework.Graphics.GraphicsDevice"/> is needed to generate a <see cref="Microsoft.Xna.Framework.Graphics.Texture2D"/>.</param>
        private void CreateMonoGameTexture(GraphicsManager graphicsManager)
        {
            var graphicsDevice = graphicsManager.GraphicsDeviceManager.GraphicsDevice;
            MonoGameTexture = new Texture2D(graphicsDevice, _width, _height);
            MonoGameTexture.SetData(GetData());
        }

        /// <summary>
        /// Initializes the raw <see cref="Microsoft.Xna.Framework.Color"/> data, width, and height of the Texture.
        /// </summary>
        /// <param name="data">1D array of raw <see cref="Microsoft.Xna.Framework.Color"/> data.</param>
        /// <param name="width">Width of the Texture.</param>
        /// <param name="height">Height of the Texture.</param>
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

        /// <summary>
        /// Initializes the raw <see cref="Microsoft.Xna.Framework.Color"/> data of the Texture.
        /// </summary>
        /// <param name="data">2D array of raw <see cref="Microsoft.Xna.Framework.Color"/> data.</param>
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
                _width = data.GetLength(0);
                _height = data.Length / _width;
                _data = new Color[_width * _height];
                int i = 0;
                foreach (var color in data)
                {
                    _data[i] = color;
                    i++;
                }
            }
        }

        /// <summary>
        /// Sets the raw color <see cref="Microsoft.Xna.Framework.Color"/> data of the Texture.
        /// </summary>
        /// <param name="value"></param>
        private void SetData(Color[] value)
        {
            _data = value;
        }
        #endregion Private Member Methods

        #endregion Member Methods
    }
}