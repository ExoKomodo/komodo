using Komodo.Core.Engine.Graphics;
using System.Collections.Generic;
using Komodo.Core.Engine.Input;
using System;
using Komodo.Core.ECS.Systems;

using Color = Microsoft.Xna.Framework.Color;
using GameTime = Microsoft.Xna.Framework.GameTime;

using ContentManager = Microsoft.Xna.Framework.Content.ContentManager;

using BasicEffect = Microsoft.Xna.Framework.Graphics.BasicEffect;

namespace Komodo.Core
{
    /// <summary>
    /// Manages all graphics initialization, systems, and underlying interactions with the MonoGame framework.
    /// </summary>
    public class Game : IDisposable
    {
        #region Constructors
        /// <summary>
        /// Creates the Game instance, instantiating the underlying <see cref="Komodo.Core.MonoGame"/> instance, <see cref="Komodo.Core.Engine.Graphics.GraphicsManager"/>, and <see cref="Komodo.Core.ECS.Systems.ISystem"/> objects.
        /// </summary>
        public Game()
        {
            _monoGame = new MonoGame(this);
            GraphicsManager = new GraphicsManager(this)
            {
                IsMouseVisible = true
            };

            Content = _monoGame.Content;

            BehaviorSystem = new BehaviorSystem(this);
            CameraSystem = new CameraSystem(this);
            Render2DSystems = new List<Render2DSystem>();
            Render3DSystems = new List<Render3DSystem>();
            SoundSystem = new SoundSystem(this);
        }
        #endregion Constructors

        #region Members

        #region Public Members
        /// <summary>
        /// Manages all <see cref="Komodo.Core.ECS.Components.BehaviorComponent"/> objects.
        /// </summary>
        public BehaviorSystem BehaviorSystem { get; }

        /// <summary>
        /// Manages all <see cref="Komodo.Core.ECS.Components.CameraComponent"/> objects.
        /// </summary>
        public CameraSystem CameraSystem { get; }

        /// <summary>
        /// Default shader for all <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/>.
        /// </summary>
        public BasicEffect DefaultSpriteShader { get; set; }

        /// <summary>
        /// Manages all <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> objects.
        /// </summary>
        public List<Render2DSystem> Render2DSystems { get; }

        /// <summary>
        /// Manages all <see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/> objects.
        /// </summary>
        public List<Render3DSystem> Render3DSystems { get; }

        /// <summary>
        /// Manages all <see cref="Komodo.Core.ECS.Components.SoundComponent"/> objects.
        /// </summary>
        public SoundSystem SoundSystem { get; }

        /// <summary>
        /// Tracks the FPS based on current <see cref="Microsoft.Xna.Framework.GameTime"/>.
        /// </summary>
        public float FramesPerSecond { get; private set; }

        /// <summary>
        /// Manages graphics devices for the Game window.
        /// </summary>
        public GraphicsManager GraphicsManager { get; private set; }

        /// <summary>
        /// Window title.
        /// </summary>
        public string Title
        {
            get
            {
                return _monoGame?.Window?.Title;
            }
            set
            {
                if (_monoGame?.Window != null)
                {
                    _monoGame.Window.Title = value;
                }
            }
        }
        #endregion Public Members
        
        #region Internal Members
        /// <summary>
        /// Provides access to MonoGame APIs.
        /// </summary>
        internal readonly MonoGame _monoGame;
        #endregion Internal Members

        #endregion Members

        #region Static Members

        #region Public Static Members
        /// <summary>
        /// Provides access to the content files compiled by the MonoGame Content Pipeline (Releases: https://github.com/MonoGame/MonoGame/releases).
        /// </summary>
        public static ContentManager Content { get; private set; }
        #endregion Public Static Members

        #endregion Static Members

        #region Member Methods

        #region Public Member Methods
        /// <summary>
        /// Creates and begins tracking a new <see cref="Komodo.Core.ECS.Systems.Render2DSystem"/>.
        /// </summary>
        public Render2DSystem CreateRender2DSystem()
        {
            var system = new Render2DSystem(this);
            Render2DSystems.Add(system);
            return system;
        }

        /// <summary>
        /// Creates and begins tracking a new <see cref="Komodo.Core.ECS.Systems.Render3DSystem"/>.
        /// </summary>
        public Render3DSystem CreateRender3DSystem()
        {
            var system = new Render3DSystem(this);
            Render3DSystems.Add(system);
            return system;
        }

        /// <summary>
        /// Draws a frame with a default clear color.
        /// </summary>
        /// <param name="gameTime">Time passed since last <see cref="Draw(GameTime)"/>.</param>
        public void Draw(GameTime gameTime)
        {
            FramesPerSecond = (float)(1 / gameTime.ElapsedGameTime.TotalSeconds);
            Draw(gameTime, Color.DarkOliveGreen);
        }

        /// <summary>
        /// Draws a frame with a provided clear color.
        /// </summary>
        /// <param name="_">Time passed since last <see cref="Draw(GameTime)"/>.</param>
        /// <param name="clearColor"><see cref="Microsoft.Xna.Framework.Color"/> to clear the screen with.</param>
        public void Draw(GameTime _, Color clearColor)
        {
            GraphicsManager.Clear(clearColor);

            var render2DSystems = Render2DSystems.ToArray();
            var render3DSystems = Render3DSystems.ToArray();
            // 3D must render before 2D or else the 2D sprites will fail to render in the Z dimension properly
            foreach (var system in render3DSystems)
            {
                system.DrawComponents();
            }
            var spriteBatch = GraphicsManager.SpriteBatch;
            foreach (var system in render2DSystems)
            {
                system.DrawComponents(spriteBatch);
            }
        }

        /// <summary>
        /// Exits the application.
        /// </summary>
        public void Exit()
        {
            _monoGame.Exit();
        }


        /// <summary>
        /// Initializes the <see cref="Komodo.Core.Engine.Graphics.GraphicsManager"/> and all <see cref="Komodo.Core.ECS.Systems.ISystem"/> objects.
        /// </summary>
        public void Initialize()
        {
            GraphicsManager.Initialize();
            DefaultSpriteShader = new BasicEffect(GraphicsManager.GraphicsDeviceManager.GraphicsDevice)
            {
                TextureEnabled = true,
                VertexColorEnabled = true,
            };
            GraphicsManager.VSync = false;

            CameraSystem.Initialize();
            SoundSystem.Initialize();

            var render3DSystems = Render3DSystems.ToArray();
            foreach (var system in render3DSystems)
            {
                system.Initialize();
            }
            var render2DSystems = Render2DSystems.ToArray();
            foreach (var system in render2DSystems)
            {
                system.Initialize();
            }

            BehaviorSystem.Initialize();
        }

        public void Run()
        {
            _monoGame.Run();
        }

        /// <summary>
        /// Updates <see cref="Komodo.Core.ECS.Systems.ISystem"/> objects.
        /// </summary>
        /// <param name="gameTime">Time passed since last <see cref="Update(GameTime)"/>.</param>
        public void Update(GameTime gameTime)
        {
            InputManager.Update();

            BehaviorSystem.PreUpdate(gameTime);
            CameraSystem.PreUpdate(gameTime);
            SoundSystem.PreUpdate(gameTime);
            var render3DSystems = Render3DSystems.ToArray();
            foreach (var system in render3DSystems)
            {
                system.PreUpdate(gameTime);
            }
            var render2DSystems = Render2DSystems.ToArray();
            foreach (var system in render2DSystems)
            {
                system.PreUpdate(gameTime);
            }

            BehaviorSystem.UpdateComponents(gameTime);
            CameraSystem.UpdateComponents(gameTime);
            SoundSystem.UpdateComponents(gameTime);

            BehaviorSystem.PostUpdate(gameTime);
            CameraSystem.PostUpdate(gameTime);
            SoundSystem.PostUpdate(gameTime);
            foreach (var system in render3DSystems)
            {
                system.PostUpdate(gameTime);
            }
            foreach (var system in render2DSystems)
            {
                system.PostUpdate(gameTime);
            }
        }
        #endregion Public Member Methods

        #endregion Member Methods

        #region IDisposable Support
        /// <summary>
        /// Implicit call to <see cref="Dispose(bool)"/>.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Detects redundant calls to <see cref="Dispose(bool)"/>.
        /// </summary>
        private bool disposedValue = false;

        /// <summary>
        /// Disposes of the underlying <see cref="Komodo.Core.MonoGame"/> instance.
        /// </summary>
        /// <param name="isDisposing">Whether or not the Game is disposing.</param>
        protected virtual void Dispose(bool isDisposing)
        {
            if (!disposedValue)
            {
                if (isDisposing)
                {
                    _monoGame.Dispose();
                }

                disposedValue = true;
            }
        }
        #endregion
    }
}

