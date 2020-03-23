using Komodo.Core.Engine.Graphics;

using Color = Microsoft.Xna.Framework.Color;

namespace Komodo.Core.ECS.Components
{
    public class Drawable3DComponent : Component
    {
        #region Constructors
        public Drawable3DComponent(Model model) : base(true, null)
        {
            ModelData = model;
            ModelPath = null;
            DiffuseColor = Color.White;
            Texture = null;
        }
        public Drawable3DComponent(string modelPath) : base(true, null)
        {
            ModelPath = modelPath;
            DiffuseColor = Color.White;
            Texture = null;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public Color DiffuseColor { get; set; }
        public float Depth
        {
            get
            {
                return ModelData.Depth * Parent.Scale.Z;
            }
        }
        public float Height
        {
            get
            {
                return ModelData.Height * Parent.Scale.Y;
            }
        }
        public Model ModelData { get; set; }
        public string ModelPath { get; set; }
        public Engine.Graphics.Texture Texture { get; set; }
        public float Width
        {
            get
            {
                return ModelData.Width * Parent.Scale.X;
            }
        }
        #endregion Public Members

        #region Protected Members
        #endregion Protected Members

        #region Private Members
        #endregion Private Members

        #endregion Members
    }
}