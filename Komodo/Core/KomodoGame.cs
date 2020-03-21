// TODO: Remove dependency on MonoGame: Color
using Komodo.Core.ECS.Scenes;
using Komodo.Core.Engine.Graphics;

using System.Text.Json;

using Microsoft.Xna.Framework;
using System.IO;
using System.Collections.Generic;
using Komodo.Core.Engine.Input;
using Microsoft.Xna.Framework.Graphics;
using Komodo.Core.ECS.Entities;
using Microsoft.Xna.Framework.Content;
using System;

namespace Komodo.Core
{
    public class KomodoGame : IDisposable
    {
        #region Constructors
        public KomodoGame()
        {
            _komodoMonoGame = new KomodoMonoGame(this);
            _graphicsManagerMonoGame = new GraphicsManagerMonoGame(_komodoMonoGame)
            {
                IsMouseVisible = true
            };

            Content = _komodoMonoGame.Content;

            ActiveScene = new Scene(this);
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public Scene ActiveScene {
            get
            {
                return _activeScene;
            }
            set
            {
                _activeScene = value;
                _activeScene.Game = this;
            }
        }
        // public SpriteEffect DefaultSpriteShader { get; set; }
        public BasicEffect DefaultSpriteShader { get; set; }

        public float FramesPerSecond
        {
            get;
            protected set;
        }
        public IGraphicsManager GraphicsManager {
            get
            {
                return this._graphicsManagerMonoGame;
            }
        }
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
        protected Scene _activeScene;
        #endregion Protected Members
        
        #region Private Members
        private readonly GraphicsManagerMonoGame _graphicsManagerMonoGame;
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
        public void Draw(GameTime gameTime)
        {
            Draw(gameTime, Color.Transparent);
        }

        public void Draw(GameTime _, Color clearColor)
        {
            _graphicsManagerMonoGame.Clear(clearColor);

            _graphicsManagerMonoGame.DrawScene(ActiveScene);
        }

        public void Exit()
        {
            _komodoMonoGame.Exit();
        }

        public void Initialize()
        {
            _graphicsManagerMonoGame.Initialize();
            // DefaultSpriteShader = new SpriteEffect(_graphicsManagerMonoGame.GraphicsDeviceManager.GraphicsDevice);
            DefaultSpriteShader = new BasicEffect(_graphicsManagerMonoGame.GraphicsDeviceManager.GraphicsDevice)
            {
                TextureEnabled = true,
                VertexColorEnabled = true,
            };
            _graphicsManagerMonoGame.VSync = false;

            ActiveScene.Initialize();
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

            ActiveScene.PreUpdate(gameTime);
            ActiveScene.Update(gameTime);
            ActiveScene.PostUpdate(gameTime);
        }
        #endregion Public Member Methods
        
        #region Protected Member Methods
        public void ParseScenes()
        {
            /*var thing = new List<int>().GetType().ToString();
            var type = System.Type.GetType(thing);*/
            var serializedScene = ActiveScene.Serialize();
            ActiveScene.Deserialize(serializedScene);
            Directory.CreateDirectory("Config/Scenes");
            File.WriteAllText(
                "Config/Scenes/ActiveScene.json",
                JsonSerializer.Serialize(serializedScene)
            );
            
            /*var thing = SerializedObject.Serialize(ActiveScene);
            var serializedScene = JsonSerializer.Serialize<SerializedObject>(thing);
            File.WriteAllText("Config/Scenes/ActiveScene.json", serializedScene);*/
            throw new System.Exception();
        }
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
