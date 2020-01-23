using System;
using System.Collections.Generic;
using System.Linq;
using Komodo.Core.Engine.Graphics.Sprites;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Komodo.Core.Engine.Graphics
{
    internal class GraphicsManagerMonoGame : IGraphicsManager
    {
        #region Constructors
        public GraphicsManagerMonoGame(KomodoMonoGame komodoMonoGame)
        {
            _komodoMonoGame = komodoMonoGame;
            _graphicsDeviceManager = new GraphicsDeviceManager(_komodoMonoGame);
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public bool IsMouseVisible {
            get
            {
                return _komodoMonoGame == null ? false : _komodoMonoGame.IsMouseVisible;
            }
            set
            {
                if (_komodoMonoGame != null)
                {
                    _komodoMonoGame.IsMouseVisible = value;
                }
            }
        }

        public List<Resolution> Resolutions
        {
            get
            {
                var resolutions = new List<Resolution>();
                var modes = _graphicsDeviceManager?.GraphicsDevice?.Adapter?.SupportedDisplayModes.ToList();
                if (modes != null)
                {
                    foreach (var mode in modes)
                    {
                        resolutions.Add(new Resolution(mode.Width, mode.Height));
                    }
                }
                return resolutions;
            }
        }
        public GraphicsDeviceManager _graphicsDeviceManager;
        public SpriteManagerMonoGame _spriteManagerMonoGame;
        #endregion Public Members
        
        #region Protected Members
        #endregion Protected Members
        
        #region Private Members
        private KomodoMonoGame _komodoMonoGame;
        #endregion Private Members

        #endregion Members

        #region Member Methods
        
        #region Public Member Methods
        public void Clear(Color clearColor)
        {
            _graphicsDeviceManager.GraphicsDevice.Clear(clearColor);
        }

        public Texture2D CreateTexture(Color[] data, int width, int height)
        {
            if (data.Count() != width * height)
            {
                // TODO: Create a ColorDataIsWrongSizeException
                throw new Exception("Color data is the wrong size");
            }
            var texture = new Texture2D(_graphicsDeviceManager.GraphicsDevice, width, height);
            texture.SetData(data);

            return texture;
        }
        public Texture2D CreateTexture(Color[,] data, int width, int height)
        {
            if (data.Length != width * height)
            {
                // TODO: Create a ColorDataIsWrongSizeException
                throw new Exception("Color data is the wrong size");
            }
            var texture = new Texture2D(_graphicsDeviceManager.GraphicsDevice, width, height);
            var transformedData = new Color[width * height];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    transformedData[i * j + j] = data[i, j];
                }
            }
            texture.SetData(transformedData);

            return texture;
        }

        // Initialize is called after all framework resources have been initialized and allocated
        public void Initialize()
        {
            // Sprite manager requires framework graphics resources to be initialized
            _spriteManagerMonoGame = new SpriteManagerMonoGame(this);

            var resolution = Resolutions.First();
            SetResolution(resolution);
            SetFullscreen(false);
        }

        public void SetFullscreen(bool isFullscreen, bool shouldApplyChanges = true)
        {
            _graphicsDeviceManager.IsFullScreen = isFullscreen;
            if (shouldApplyChanges)
            {                
                _graphicsDeviceManager.ApplyChanges();
            }
        }

        public void SetResolution(Resolution resolution, bool shouldApplyChanges = true)
        {
            var modes = _graphicsDeviceManager.GraphicsDevice.Adapter.SupportedDisplayModes;
            foreach (var mode in modes)
            {
                if (mode.Width == resolution.Width && mode.Height == resolution.Height)
                {
                    _graphicsDeviceManager.PreferredBackBufferWidth = resolution.Width;
                    _graphicsDeviceManager.PreferredBackBufferHeight = resolution.Height;
                    if (shouldApplyChanges)
                    {                
                        _graphicsDeviceManager.ApplyChanges();
                    }
                    return;
                }
            }
            // TODO: Add ResolutionNotSupportedException
            throw new Exception("Resolution not supported");
        }

        public void ToggleFullscreen(bool shouldApplyChanges = true)
        {
            _graphicsDeviceManager.ToggleFullScreen();
            if (shouldApplyChanges)
            {                
                _graphicsDeviceManager.ApplyChanges();
            }
        }
        #endregion Public Member Methods

        #region Protected Member Methods
        #endregion Protected Member Methods

        #region Private Member Methods
        #endregion Private Member Methods

        #endregion Member Methods
    }
}