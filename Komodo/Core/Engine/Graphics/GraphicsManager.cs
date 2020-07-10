using System.Collections.Generic;
using System.Linq;
using System;

using Color = Microsoft.Xna.Framework.Color;
using GraphicsDeviceManager = Microsoft.Xna.Framework.GraphicsDeviceManager;

using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using Viewport = Microsoft.Xna.Framework.Graphics.Viewport;

namespace Komodo.Core.Engine.Graphics
{
    /// <summary>
    /// Manages all the underlying graphics resources and devices.
    /// </summary>
    public class GraphicsManager
    {
        #region Public

        #region Constructors
        /// <param name="game">Reference to current <see cref="Komodo.Core.Game"/> instance.</param>
        public GraphicsManager(Game game)
        {
            Game = game;
            GraphicsDeviceManager = new GraphicsDeviceManager(_monoGame);
        }
        #endregion

        #region Members
        /// <summary>
        /// Reference to current <see cref="Komodo.Core.Game"/> instance.
        /// </summary>
        public Game Game { get; }

        /// <summary>
        /// Whether or not to display as a borderless window.
        /// </summary>
        public bool IsBorderless
        {
            get
            {
                return _monoGame.Window.IsBorderless;
            }
            set
            {
                _monoGame.Window.IsBorderless = value;
            }
        }

        /// <summary>
        /// Whether or not to show the mouse in the game window.
        /// </summary>
        public bool IsMouseVisible {
            get
            {
                return _monoGame == null ? false : _monoGame.IsMouseVisible;
            }
            set
            {
                if (_monoGame != null)
                {
                    _monoGame.IsMouseVisible = value;
                }
            }
        }

        /// <summary>
        /// Supported resolutions for the current graphics device.
        /// </summary>
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

        /// <summary>
        /// Underlying <see cref="Microsoft.Xna.Framework.GraphicsDeviceManager"/>, providing access to the underlying <see cref="Microsoft.Xna.Framework.Graphics.GraphicsDevice"/>.
        /// </summary>
        public GraphicsDeviceManager GraphicsDeviceManager { get; }

        /// <summary>
        /// Current <see cref="Microsoft.Xna.Framework.Graphics.SpriteBatch"/> for the underlying <see cref="Microsoft.Xna.Framework.Graphics.GraphicsDevice"/>.
        /// </summary>
        public SpriteBatch SpriteBatch { get; set; }

        /// <summary>
        /// Current <see cref="Microsoft.Xna.Framework.Graphics.Viewport"/> for the <see cref="Microsoft.Xna.Framework.Graphics.GraphicsDevice"/>.
        /// </summary>
        public Viewport ViewPort => GraphicsDeviceManager.GraphicsDevice.Viewport;

        /// <summary>
        /// Whether or not to render using vertical sync.
        /// </summary>
        public bool VSync
        {
            get
            {
                return GraphicsDeviceManager.SynchronizeWithVerticalRetrace && _monoGame.IsFixedTimeStep;
            }
            set
            {
                if (value != VSync)
                {
                    GraphicsDeviceManager.SynchronizeWithVerticalRetrace = value;
                    _monoGame.IsFixedTimeStep = value;
                    GraphicsDeviceManager.ApplyChanges();
                }
            }
        }
        #endregion

        #region Member Methods
        /// <summary>
        /// Applies pending changes to the <see cref="Microsoft.Xna.Framework.GraphicsDeviceManager"/>.
        /// </summary>
        public void ApplyChanges()
        {
            GraphicsDeviceManager.ApplyChanges();
        }

        /// <summary>
        /// Clears the screen with a given <see cref="Microsoft.Xna.Framework.Color"/>.
        /// </summary>
        /// <param name="clearColor"><see cref="Microsoft.Xna.Framework.Color"/> to clear the <see cref="Microsoft.Xna.Framework.Graphics.GraphicsDevice"/> with.</param>
        public void Clear(Color clearColor)
        {
            GraphicsDeviceManager.GraphicsDevice.Clear(clearColor);
        }

        /// <summary>
        /// Creates a new <see cref="Komodo.Core.Engine.Graphics.Texture"/> from raw <see cref="Microsoft.Xna.Framework.Color"/> data and dimensions.
        /// </summary>
        /// <param name="data">1D array of <see cref="Microsoft.Xna.Framework.Color"/>.</param>
        /// <param name="width">Width of the <see cref="Komodo.Core.Engine.Graphics.Texture"/> to generate.</param>
        /// <param name="height">Height of the <see cref="Komodo.Core.Engine.Graphics.Texture"/> to generate.</param>
        /// <returns>Newly generated Texture. Will return null if dimensions do not match dimensions of <see cref="Microsoft.Xna.Framework.Color"/> data.</returns>
        public Texture CreateTexture(Color[] data, int width, int height)
        {
            if (data.Length != width * height)
            {
                return null;
            }
            var texture = new Texture(this, data, width, height);
            return texture;
        }

        /// <summary>
        /// Creates a new <see cref="Komodo.Core.Engine.Graphics.Texture"/> from raw <see cref="Microsoft.Xna.Framework.Color"/> data.
        /// </summary>
        /// <param name="data">2D array of <see cref="Microsoft.Xna.Framework.Color"/>.</param>
        /// <returns>Newly generated Texture.</returns>
        public Texture CreateTexture(Color[,] data)
        {
            var texture = new Texture(this, data);
            return texture;
        }

        /// <summary>
        /// Called after all framework resources have been initialized and allocated.
        /// </summary>
        /// <remarks>
        /// Before <see cref="Initialize"/> is called, MonoGame will not have set up the <see cref="Microsoft.Xna.Framework.Graphics.GraphicsDevice"/> yet, preventing <see cref="Komodo.Core.Engine.Graphics.Texture"/> or <see cref="Komodo.Core.Engine.Graphics.Model"/> from being generated.
        /// </remarks>
        public void Initialize()
        {
            SpriteBatch = new SpriteBatch(GraphicsDeviceManager.GraphicsDevice);

            var resolution = Resolutions.First();
            if (Resolutions.Count > 3)
            {
                resolution = Resolutions[3];
            }
            SetResolution(resolution);
            SetFullscreen(false);
        }

        /// <summary>
        /// Sets the game window to render either in fullscreen or windowed mode.
        /// </summary>
        /// <param name="isFullscreen">Whether or not to render in fullscreen.</param>
        /// <param name="shouldApplyChanges">Whether or not to apply the graphics changes immediately.</param>
        public void SetFullscreen(bool isFullscreen, bool shouldApplyChanges = true)
        {
            GraphicsDeviceManager.IsFullScreen = isFullscreen;
            if (shouldApplyChanges)
            {
                ApplyChanges();
            }
        }

        /// <summary>
        /// Sets the game window resolution.
        /// </summary>
        /// <param name="resolution">New resolution to display.</param>
        /// <param name="shouldApplyChanges">Whether or not to apply the graphics changes immediately.</param>
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
                        ApplyChanges();
                    }
                    return;
                }
            }
            // TODO: Add ResolutionNotSupportedException
            throw new Exception("Resolution not supported");
        }

        /// <summary>
        /// Toggles whether or not the game window renders in fullscreen or windowed mode
        /// </summary>
        /// <param name="shouldApplyChanges">Whether or not to apply the graphics changes immediately.</param>
        public void ToggleFullscreen(bool shouldApplyChanges = true)
        {
            GraphicsDeviceManager.ToggleFullScreen();
            if (shouldApplyChanges)
            {                
                GraphicsDeviceManager.ApplyChanges();
            }
        }
        #endregion

        #endregion

        #region Private

        #region Members
        /// <summary>
        /// Accessor for the underlying <see cref="Komodo.Core.MonoGame"/>.
        /// </summary>
        private MonoGame _monoGame => Game?._monoGame;
        #endregion

        #endregion
    }
}