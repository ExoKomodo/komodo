// TODO: Remove dependency on MonoGame: KomodoGame
using System.Collections.Generic;
using Komodo.Core.Engine.Components;
using Komodo.Core.Engine.Entities;
using Komodo.Core.Engine.Graphics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Komodo.Core
{
    public class KomodoGame : IKomodoGame
    {
        #region Constructors
        public KomodoGame()
        {
            _komodoMonoGame = new KomodoMonoGame(this);
            _graphicsManagerMonoGame = new GraphicsManagerMonoGame(_komodoMonoGame);
            _graphicsManagerMonoGame.IsMouseVisible = true;

            MainEntity = new Entity();
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public IEntity MainEntity { get; set; }
        #endregion Public Members
        
        #region Protected Members
        #endregion Protected Members
        
        #region Private Members
        private GraphicsManagerMonoGame _graphicsManagerMonoGame;
        private KomodoMonoGame _komodoMonoGame;
        #endregion Private Members

        #endregion Members

        #region Member Methods
        
        #region Public Member Methods
        public void Draw(GameTime gameTime)
        {
            Draw(gameTime, Color.Transparent);
        }

        public void Draw(GameTime gameTime, Color clearColor)
        {
            _graphicsManagerMonoGame.Clear(clearColor);

            _graphicsManagerMonoGame._spriteManagerMonoGame.BeginDraw();
            _graphicsManagerMonoGame._spriteManagerMonoGame.Draw(MainEntity);
            _graphicsManagerMonoGame._spriteManagerMonoGame.EndDraw();
        }
        
        public void Exit()
        {
            _komodoMonoGame.Exit();
        }

        public void Initialize()
        {
            _graphicsManagerMonoGame.Initialize();

            int width = 100;
            int height = 100;
            Color[] data = new Color[width * height];
            for (int pixel = 0; pixel < width * height; pixel++)
            {
                //the function applies the color according to the specified pixel
                data[pixel] = Color.Blue;
            }
            var texture = _graphicsManagerMonoGame.CreateTexture(data, width, height);

            MainEntity.Components = new List<IComponent> {
                new SpriteComponent(MainEntity, texture),
            };
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
            MainEntity.Update(gameTime);
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
