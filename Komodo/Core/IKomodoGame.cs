using System;
using System.Collections.Generic;
using Komodo.Core.Engine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Komodo.Core
{
    public interface IKomodoGame : IDisposable
    {
        #region Members

        #region Public Members
        BasicEffect DefaultShader { get; set; }
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
        void Initialize();
        void ResetElapsedTime();
        void Run(List<Entity> startupEntities = null);
        void RunOneFrame();
        void Update(GameTime gameTime);
        #endregion Public Member Methods
        
        #endregion Member Methods
    }
}
