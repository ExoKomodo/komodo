using Komodo.Core.Engine.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Komodo.Core.Engine.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using Komodo.Core.ECS.Systems;

namespace Komodo.Core
{
    public class KomodoGame : IDisposable
    {
        #region Constructors
        public KomodoGame()
        {
            _komodoMonoGame = new KomodoMonoGame(this);
            GraphicsManager = new GraphicsManager(_komodoMonoGame)
            {
                IsMouseVisible = true
            };

            Content = _komodoMonoGame.Content;

            BehaviorSystem = new BehaviorSystem(this);
            CameraSystem = new CameraSystem(this);
            Render2DSystems = new List<Render2DSystem>();
            Render3DSystems = new List<Render3DSystem>();
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public BehaviorSystem BehaviorSystem { get; private set; }
        public CameraSystem CameraSystem { get; private set; }
        public List<Render2DSystem> Render2DSystems { get; private set; }
        public List<Render3DSystem> Render3DSystems { get; private set; }
        public BasicEffect DefaultSpriteShader { get; set; }

        public float FramesPerSecond
        {
            get;
            protected set;
        }
        public GraphicsManager GraphicsManager { get; private set; }
        public string Title
        {
            get
            {
                return _komodoMonoGame?.Window?.Title;
            }
            set
            {
                if (_komodoMonoGame?.Window != null)
                {
                    _komodoMonoGame.Window.Title = value;
                }
            }
        }
        #endregion Public Members
        
        #region Protected Members
        #endregion Protected Members
        
        #region Private Members
        private readonly KomodoMonoGame _komodoMonoGame;
        #endregion Private Members

        #endregion Members

        #region Static Members

        #region Public Static Members
        public static ContentManager Content { get; private set; }
        #endregion Public Static Members

        #endregion Static Members

        #region Member Methods

        #region Public Member Methods        
        public Render2DSystem CreateRender2DSystem()
        {
            var system = new Render2DSystem(this);
            Render2DSystems.Add(system);
            return system;
        }

        public Render3DSystem CreateRender3DSystem()
        {
            var system = new Render3DSystem(this);
            Render3DSystems.Add(system);
            return system;
        }

        public void Draw(GameTime gameTime)
        {
            Draw(gameTime, Color.Transparent);
        }

        public void Draw(GameTime _, Color clearColor)
        {
            GraphicsManager.Clear(clearColor);

            var render2DSystems = Render2DSystems.ToArray();
            var render3DSystems = Render3DSystems.ToArray();
            // 3D must render before 2D or else the 2D sprites will fail to render in the Z dimension properly
            Array.ForEach(render3DSystems, system => system.DrawComponents());
            var spriteBatch = GraphicsManager.SpriteBatch;
            Array.ForEach(render2DSystems, system => system.DrawComponents(spriteBatch));
        }

        public void Exit()
        {
            _komodoMonoGame.Exit();
        }

        public void Initialize()
        {
            GraphicsManager.Initialize();
            DefaultSpriteShader = new BasicEffect(GraphicsManager.GraphicsDeviceManager.GraphicsDevice)
            {
                TextureEnabled = true,
                VertexColorEnabled = true,
            };
            GraphicsManager.VSync = false;

            BehaviorSystem.Initialize();
            CameraSystem.Initialize();
            Render3DSystems.ForEach(system => system.Initialize());
            Render2DSystems.ForEach(system => system.Initialize());
        }

        public void ResetElapsedTime()
        {
            _komodoMonoGame.ResetElapsedTime();
        }

        public void Run()
        {
            _komodoMonoGame.Run();
        }

        public void RunOneFrame()
        {
            _komodoMonoGame.RunOneFrame();
        }

        public void Update(GameTime gameTime)
        {
            FramesPerSecond = (float)(1 / gameTime.ElapsedGameTime.TotalSeconds);
            InputManager.Update();

            var render2DSystems = Render2DSystems.ToArray();
            var render3DSystems = Render3DSystems.ToArray();
            BehaviorSystem.PreUpdate(gameTime);
            CameraSystem.PreUpdate(gameTime);
            Array.ForEach(render3DSystems, system => system.PreUpdate(gameTime));
            Array.ForEach(render2DSystems, system => system.PreUpdate(gameTime));

            BehaviorSystem.UpdateComponents(gameTime);
            CameraSystem.UpdateComponents();

            BehaviorSystem.PostUpdate(gameTime);
            CameraSystem.PostUpdate(gameTime);
            Array.ForEach(render2DSystems, system => system.PostUpdate(gameTime));
            Array.ForEach(render3DSystems, system => system.PostUpdate(gameTime));
        }
        #endregion Public Member Methods
        
        #region Protected Member Methods
        #endregion Protected Member Methods
        
        #region Private Member Methods
        #endregion Private Member Methods
        
        #endregion Member Methods

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _komodoMonoGame.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~KomodoGame()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
