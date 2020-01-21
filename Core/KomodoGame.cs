# TODO: Remove dependency on MonoGame: KomodoGame
using Microsoft.Xna.Framework;

namespace Komodo.Core
{
    public class KomodoGame : IKomodoGame
    {
        #region Members

        #region Public Members
        #endregion Public Members
        
        #region Protected Members
        #endregion Protected Members
        
        #region Private Members
        private KomodoMonoGame _komodoMonoGame;
        #endregion Private Members

        #endregion Members

        #region Constructors
        public KomodoGame()
        {
            _komodoMonoGame = new KomodoMonoGame(this);
        }
        #endregion Constructors

        #region Member Methods
        
        #region Public Member Methods
        public void Draw(GameTime gameTime)
        {

        }
        
        public void Exit()
        {
            _komodoMonoGame.Exit();
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
