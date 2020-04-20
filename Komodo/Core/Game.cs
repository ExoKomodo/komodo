using Komodo.Core.Engine.Graphics;
using System.Collections.Generic;
using Komodo.Core.Engine.Input;
using System;
using Komodo.Core.ECS.Systems;

using Color = Microsoft.Xna.Framework.Color;
using GameTime = Microsoft.Xna.Framework.GameTime;
using InputKeyEventArgs = Microsoft.Xna.Framework.InputKeyEventArgs;
using TextInputEventArgs = Microsoft.Xna.Framework.TextInputEventArgs;

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
            PhysicsSystems = new List<PhysicsSystem>();
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
        /// Tracks the FPS based on current <see cref="Microsoft.Xna.Framework.GameTime"/>.
        /// </summary>
        public float FramesPerSecond { get; private set; }

        /// <summary>
        /// Manages graphics devices for the Game window.
        /// </summary>
        public GraphicsManager GraphicsManager { get; private set; }

        /// <summary>
        /// Whether or not the game is the current window in focus.
        /// </summary>
        /// <remarks>
        /// Can be used to know whether or not inputs should be dropped while user is not in game.
        /// </remarks>
        public bool IsActive => _monoGame.IsActive;

        /// <summary>
        /// Manages all <see cref="Komodo.Core.ECS.Components.PhysicsComponent"/> objects.
        /// </summary>
        public List<PhysicsSystem> PhysicsSystems { get; }

        /// <summary>
        /// Manages all <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> objects.
        /// </summary>
        public List<Render2DSystem> Render2DSystems { get; }

        /// <summary>
        /// Manages all <see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/> objects.
        /// </summary>
        public List<Render3DSystem> Render3DSystems { get; }

        /// <summary>
        /// Name of the current screen device.
        /// </summary>
        public string ScreenDeviceName => _monoGame.Window.ScreenDeviceName;

        /// <summary>
        /// Manages all <see cref="Komodo.Core.ECS.Components.SoundComponent"/> objects.
        /// </summary>
        public SoundSystem SoundSystem { get; }

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

        #region Add event handlers
        /// <summary>
        /// Adds a handler to be executed when game is exiting.
        /// </summary>
        /// <param name="handler">Handler to be executed.</param>
        public void AddExitingEventHandler(EventHandler<EventArgs> handler)
        {
            _monoGame.Exiting += handler;
        }
        
        /// <summary>
        /// Adds a handler to be executed when game is exiting.
        /// </summary>
        /// <param name="handler">Handler to be executed.</param>
        /// <returns>Reference to the registered <see cref="System.EventHandler"/>. Can be used to remove the registered handler.</returns>
        public EventHandler<EventArgs> AddExitingHandler(Action<object, EventArgs> handler)
        {
            var eventHandler = new EventHandler<EventArgs>(handler);
            AddExitingEventHandler(eventHandler);
            return eventHandler;
        }

        /// <summary>
        /// Adds a handler to be executed when game gains window focus.
        /// </summary>
        /// <param name="handler">Handler to be executed.</param>
        public void AddFocusGainedEventHandler(EventHandler<EventArgs> handler)
        {
            _monoGame.Activated += handler;
        }

        /// <summary>
        /// Adds a handler to be executed when game gains window focus.
        /// </summary>
        /// <param name="handler">Handler to be executed.</param>
        /// <returns>Reference to the registered <see cref="System.EventHandler"/>. Can be used to remove the registered handler.</returns>
        public EventHandler<EventArgs> AddFocusGainedHandler(Action<object, EventArgs> handler)
        {
            var eventHandler = new EventHandler<EventArgs>(handler);
            AddFocusGainedEventHandler(eventHandler);
            return eventHandler;
        }

        /// <summary>
        /// Adds a handler to be executed when game loses window focus.
        /// </summary>
        /// <param name="handler">Handler to be executed.</param>
        public void AddFocusLostEventHandler(EventHandler<EventArgs> handler)
        {
            _monoGame.Deactivated += handler;
        }

        /// <summary>
        /// Adds a handler to be executed when game loses window focus.
        /// </summary>
        /// <param name="handler">Handler to be executed.</param>
        /// <returns>Reference to the registered <see cref="System.EventHandler"/>. Can be used to remove the registered handler.</returns>
        public EventHandler<EventArgs> AddFocusLostHandler(Action<object, EventArgs> handler)
        {
            var eventHandler = new EventHandler<EventArgs>(handler);
            AddFocusLostEventHandler(eventHandler);
            return eventHandler;
        }

        /// <summary>
        /// Adds a handler to be executed when key is pressed down.
        /// </summary>
        /// <remarks>
        /// Provides access to the <see cref="Microsoft.Xna.Framework.Input.Keys"/> representation of the key pressed down.
        /// </remarks>
        /// <param name="handler">Handler to be executed.</param>
        public void AddKeyDownEventHandler(EventHandler<InputKeyEventArgs> handler)
        {
            _monoGame.Window.KeyDown += handler;
        }
        
        /// <summary>
        /// Adds a handler to be executed when key is pressed down.
        /// </summary>
        /// <remarks>
        /// Provides access to the <see cref="Microsoft.Xna.Framework.Input.Keys"/> representation of the key pressed down.
        /// </remarks>
        /// <param name="handler">Handler to be executed.</param>
        /// <returns>Reference to the registered <see cref="System.EventHandler"/>. Can be used to remove the registered handler.</returns>
        public EventHandler<InputKeyEventArgs> AddKeyDownHandler(Action<object, InputKeyEventArgs> handler)
        {
            var eventHandler = new EventHandler<InputKeyEventArgs>(handler);
            AddKeyDownEventHandler(eventHandler);
            return eventHandler;
        }

        /// <summary>
        /// Adds a handler to be executed when key is released.
        /// </summary>
        /// <remarks>
        /// Provides access to the <see cref="Microsoft.Xna.Framework.Input.Keys"/> representation of the key released.
        /// </remarks>
        /// <param name="handler">Handler to be executed.</param>
        public void AddKeyUpEventHandler(EventHandler<InputKeyEventArgs> handler)
        {
            _monoGame.Window.KeyUp += handler;
        }
        
        /// <summary>
        /// Adds a handler to be executed when key is released.
        /// </summary>
        /// <remarks>
        /// Provides access to the <see cref="Microsoft.Xna.Framework.Input.Keys"/> representation of the key released.
        /// </remarks>
        /// <param name="handler">Handler to be executed.</param>
        /// <returns>Reference to the registered <see cref="System.EventHandler"/>. Can be used to remove the registered handler.</returns>
        public EventHandler<InputKeyEventArgs> AddKeyUpHandler(Action<object, InputKeyEventArgs> handler)
        {
            var eventHandler = new EventHandler<InputKeyEventArgs>(handler);
            AddKeyUpEventHandler(eventHandler);
            return eventHandler;
        }

        /// <summary>
        /// Adds a handler to be executed when screen device name changes, so normally if the screen device is changed.
        /// </summary>
        /// <remarks>
        /// Does not provide access to the new screen device name. This can be retrieved from <see cref="ScreenDeviceName"/>.
        /// </remarks>
        /// <param name="handler">Handler to be executed.</param>
        public void AddScreenDeviceNameChangedEventHandler(EventHandler<EventArgs> handler)
        {
            _monoGame.Window.ScreenDeviceNameChanged += handler;
        }
        
        /// <summary>
        /// Adds a handler to be executed when screen device name changes, so normally if the screen device is changed.
        /// </summary>
        /// <remarks>
        /// Does not provide access to the new screen device name. This can be retrieved from <see cref="ScreenDeviceName"/>.
        /// </remarks>
        /// <param name="handler">Handler to be executed.</param>
        /// <returns>Reference to the registered <see cref="System.EventHandler"/>. Can be used to remove the registered handler.</returns>
        public EventHandler<EventArgs> AddScreenDeviceNameChangedHandler(Action<object, EventArgs> handler)
        {
            var eventHandler = new EventHandler<EventArgs>(handler);
            AddScreenDeviceNameChangedEventHandler(eventHandler);
            return eventHandler;
        }

        /// <summary>
        /// Adds a handler to be run when text is input.
        /// </summary>
        /// <remarks>
        /// Provides access to the printable character and the <see cref="Microsoft.Xna.Framework.Input.Keys"/> representation of the key.
        /// </remarks>
        /// <param name="handler">Handler to be executed when a key is pressed. <c>object</c> provides access to the Window object the event was sent from. <c>args</c> provides access to the pressed key.</param>
        public void AddTextInputEventHandler(EventHandler<TextInputEventArgs> handler)
        {
            _monoGame.Window.TextInput += handler;
        }
        
        /// <summary>
        /// Adds a handler to be run when text is input.
        /// </summary>
        /// <remarks>
        /// Provides access to the printable character and the <see cref="Microsoft.Xna.Framework.Input.Keys"/> representation of the key.
        /// </remarks>
        /// <param name="handler">Handler to be executed when a key is pressed. <c>object</c> provides access to the Window object the event was sent from. <c>args</c> provides access to the pressed key.</param>
        /// <returns>Reference to the registered <see cref="System.EventHandler"/>. Can be used to remove the registered handler.</returns>
        public EventHandler<TextInputEventArgs> AddTextInputHandler(Action<object, TextInputEventArgs> handler)
        {
            var eventHandler = new EventHandler<TextInputEventArgs>(handler);
            AddTextInputEventHandler(eventHandler);
            return eventHandler;
        }

        /// <summary>
        /// Adds a handler to be executed when window changes size.
        /// </summary>
        /// <remarks>
        /// Does not provide access to the new window size. This can be retrieved from <see cref="GraphicsManager.ViewPort"/>.
        /// </remarks>
        /// <param name="handler">Handler to be executed.</param>
        /// <returns>Reference to the registered <see cref="System.EventHandler"/>. Can be used to remove the registered handler.</returns>
        public EventHandler<EventArgs> AddWindowSizeChangedHandler(Action<object, EventArgs> handler)
        {
            _monoGame.Window.AllowUserResizing = true;
            var eventHandler = new EventHandler<EventArgs>(handler);
            AddWindowSizeChangedEventHandler(eventHandler);
            return eventHandler;
        }

        /// <summary>
        /// Adds a handler to be executed when window changes size.
        /// </summary>
        /// <remarks>
        /// Does not provide access to the new window size. This can be retrieved from <see cref="GraphicsManager.ViewPort"/>.
        /// </remarks>
        /// <param name="handler">Handler to be executed.</param>
        public void AddWindowSizeChangedEventHandler(EventHandler<EventArgs> handler)
        {
            _monoGame.Window.ClientSizeChanged += handler;
        }
        #endregion Add event handlers

        #region Remove event handlers
        /// <summary>
        /// Removes a previously registered handler for when game is exiting.
        /// </summary>
        /// <param name="handler">Handler to be removed.</param>
        public void RemoveExitingEventHandler(EventHandler<EventArgs> handler)
        {
            _monoGame.Exiting -= handler;
        }

        /// <summary>
        /// Removes a previously registered handler for when game gaining window focus.
        /// </summary>
        /// <param name="handler">Handler to be removed.</param>
        public void RemoveFocusGainedEventHandler(EventHandler<EventArgs> handler)
        {
            _monoGame.Activated -= handler;
        }

        /// <summary>
        /// Removes a previously registered handler for when game loses window focus.
        /// </summary>
        /// <param name="handler">Handler to be removed.</param>
        public void RemoveFocusLostEventHandler(EventHandler<EventArgs> handler)
        {
            _monoGame.Deactivated -= handler;
        }

        /// <summary>
        /// Removes a previously registered handler for when key is pressed down.
        /// </summary>
        /// <param name="handler">Handler to be removed.</param>
        public void RemoveKeyDownEventHandler(EventHandler<InputKeyEventArgs> handler)
        {
            _monoGame.Window.KeyDown -= handler;
        }

        /// <summary>
        /// Removes a previously registered handler for when key is released.
        /// </summary>
        /// <param name="handler">Handler to be removed.</param>
        public void RemoveKeyUpEventHandler(EventHandler<InputKeyEventArgs> handler)
        {
            _monoGame.Window.KeyUp -= handler;
        }
        
        /// <summary>
        /// Removes a previously registered handler for when screen device name changes, so normally if the screen device is changed.
        /// </summary>
        /// <param name="handler">Handler to be removed.</param>
        public void RemoveScreenDeviceNameChangedEventHandler(EventHandler<EventArgs> handler)
        {
            _monoGame.Window.ScreenDeviceNameChanged -= handler;
        }

        /// <summary>
        /// Removes a previously registered handler for text input.
        /// </summary>
        /// <param name="handler">Handler to be removed.</param>
        public void RemoveTextInputEventHandler(EventHandler<TextInputEventArgs> handler)
        {
            _monoGame.Window.TextInput -= handler;
        }

        /// <summary>
        /// Removes a previously registered handler for when window changes size.
        /// </summary>
        /// <param name="handler">Handler to be removed.</param>
        public void RemoveWindowSizeChangedEventHandler(EventHandler<EventArgs> handler)
        {
            _monoGame.Window.ClientSizeChanged -= handler;
        }
        #endregion Remove event handlers

        /// <summary>
        /// Creates and begins tracking a new <see cref="Komodo.Core.ECS.Systems.PhysicsSystem"/>.
        /// </summary>
        public PhysicsSystem CreatePhysicsSystem()
        {
            var system = new PhysicsSystem(this);
            PhysicsSystems.Add(system);
            return system;
        }

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

            var physicsSystems = PhysicsSystems.ToArray();
            foreach (var system in physicsSystems)
            {
                system.Initialize();
            }
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
            var physicsSystems = PhysicsSystems.ToArray();
            foreach (var system in physicsSystems)
            {
                system.PreUpdate(gameTime);
            }
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
            foreach (var system in physicsSystems)
            {
                system.UpdateComponents(gameTime);
            }

            BehaviorSystem.PostUpdate(gameTime);
            CameraSystem.PostUpdate(gameTime);
            SoundSystem.PostUpdate(gameTime);
            foreach (var system in physicsSystems)
            {
                system.PostUpdate(gameTime);
            }
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

