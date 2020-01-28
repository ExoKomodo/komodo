// TODO: Remove dependency on MonoGame: GraphicsManager
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Komodo.Core.Engine.Scenes;

namespace Komodo.Core.Engine.Graphics
{
    public interface IGraphicsManager
    {
        #region Members

        #region Public Members
        bool IsMouseVisible { get; set; }
        List<Resolution> Resolutions { get; }
        #endregion Public Members

        #endregion Members

        #region Member Methods
        
        #region Public Member Methods
        void Clear(Color clearColor);
        KomodoTexture CreateTexture(Color[] data, int width, int height);
        KomodoTexture CreateTexture(Color[,] data);
        void DrawScene(IScene scene);
        void Initialize();
        void SetFullscreen(bool isFullscreen, bool shouldApplyChanges = true);
        void SetResolution(Resolution resolution, bool shouldApplyChanges = true);
        void ToggleFullscreen(bool shouldApplyChanges = true);
        #endregion Public Member Methods
        
        #endregion Member Methods
    }
}
