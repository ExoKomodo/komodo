using System.Collections.Generic;
using System.Linq;
using System;

using Color = Microsoft.Xna.Framework.Color;
using GraphicsDeviceManager = Microsoft.Xna.Framework.GraphicsDeviceManager;

using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using Viewport = Microsoft.Xna.Framework.Graphics.Viewport;

namespace Komodo.Core.Engine.Graphics
{
    public class GraphicsManager
    {
        #region Constructors
        public GraphicsManager(MonoGame komodoMonoGame)
        {
            _komodoMonoGame = komodoMonoGame;
            GraphicsDeviceManager = new GraphicsDeviceManager(_komodoMonoGame);
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
                var modes = GraphicsDeviceManager?.GraphicsDevice?.Adapter?.SupportedDisplayModes.ToList();
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
        public GraphicsDeviceManager GraphicsDeviceManager { get; set; }
        public SpriteBatch SpriteBatch { get; set; }
        public Viewport ViewPort => GraphicsDeviceManager.GraphicsDevice.Viewport;
        public bool VSync
        {
            get
            {
                return GraphicsDeviceManager.SynchronizeWithVerticalRetrace && _komodoMonoGame.IsFixedTimeStep;
            }
            set
            {
                if (value != VSync)
                {
                    GraphicsDeviceManager.SynchronizeWithVerticalRetrace = value;
                    _komodoMonoGame.IsFixedTimeStep = value;
                    GraphicsDeviceManager.ApplyChanges();
                }
            }
        }
        #endregion Public Members

        #region Protected Members
        #endregion Protected Members

        #region Private Members
        private readonly MonoGame _komodoMonoGame;
        #endregion Private Members

        #endregion Members

        #region Member Methods
        
        #region Public Member Methods
        public void Clear(Color clearColor)
        {
            GraphicsDeviceManager.GraphicsDevice.Clear(clearColor);
        }

        public Texture CreateTexture(Color[] data, int width, int height)
        {
            var texture = new Texture(this, data, width, height);
            return texture;
        }
        public Texture CreateTexture(Color[,] data)
        {
            var texture = new Texture(this, data);
            return texture;
        }

        // Initialize is called after all framework resources have been initialized and allocated
        public void Initialize()
        {
            // Sprite manager requires framework graphics resources to be initialized
            SpriteBatch = new SpriteBatch(GraphicsDeviceManager.GraphicsDevice);

            var resolution = Resolutions.First();
            if (Resolutions.Count > 3)
            {
                resolution = Resolutions[3];
            }
            SetResolution(resolution);
            SetFullscreen(false);
        }

        public void SetFullscreen(bool isFullscreen, bool shouldApplyChanges = true)
        {
            GraphicsDeviceManager.IsFullScreen = isFullscreen;
            if (shouldApplyChanges)
            {                
                GraphicsDeviceManager.ApplyChanges();
            }
        }

        public void SetResolution(Resolution resolution, bool shouldApplyChanges = true)
        {
            var modes = GraphicsDeviceManager.GraphicsDevice.Adapter.SupportedDisplayModes;
            foreach (var mode in modes)
            {
                if (mode.Width == resolution.Width && mode.Height == resolution.Height)
                {
                    GraphicsDeviceManager.PreferredBackBufferWidth = resolution.Width;
                    GraphicsDeviceManager.PreferredBackBufferHeight = resolution.Height;
                    if (shouldApplyChanges)
                    {                
                        GraphicsDeviceManager.ApplyChanges();
                    }
                    return;
                }
            }
            // TODO: Add ResolutionNotSupportedException
            throw new Exception("Resolution not supported");
        }

        public void ToggleFullscreen(bool shouldApplyChanges = true)
        {
            GraphicsDeviceManager.ToggleFullScreen();
            if (shouldApplyChanges)
            {                
                GraphicsDeviceManager.ApplyChanges();
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