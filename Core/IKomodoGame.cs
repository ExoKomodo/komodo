using System;
using Microsoft.Xna.Framework;

namespace Komodo.Core
{
    public interface IKomodoGame : IDisposable
    {
        #region Members

        #region Public Members
        #endregion Public Members
        
        #region Protected Members
        #endregion Protected Members
        
        #region Private Members
        #endregion Private Members

        #endregion Members

        #region Member Methods
        
        #region Public Member Methods
        void Draw(GameTime gameTime);
        void Draw(GameTime gameTime, Color clearColor);
        void Exit();
        void ResetElapsedTime();
        void Run();
        void RunOneFrame();
        void Update(GameTime gameTime);
        #endregion Public Member Methods
        
        #endregion Member Methods
    }
}
