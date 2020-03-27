using Komodo.Core.Engine.Graphics;

using BoundingBox = Microsoft.Xna.Framework.BoundingBox;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Komodo.Core.ECS.Components
{
    /// <summary>
    /// Represents any 3D model to be drawn in a <see cref="Komodo.Core.ECS.Systems.Render3DSystem"/>
    /// </summary>
    public class Drawable3DComponent : Component
    {
        #region Constructors
        /// <summary>
        /// Creates a Drawable3DComponent with a given <see cref="Komodo.Core.Engine.Graphics.Model"/>.
        /// </summary>
        /// <param name="model">Model reference containing the raw data of the 3D model.</param>
        public Drawable3DComponent(Model model) : base(true, null)
        {
            ModelData = model;
            ModelPath = null;
            DiffuseColor = Color.White;
            Texture = null;
            TexturePath = null;
        }

        /// <summary>
        /// Creates a Drawable3DComponent with a filepath to a compiled <see cref="Microsoft.Xna.Framework.Graphics.Model"/> content file.
        /// </summary>
        /// <remarks>
        /// The <see cref="Microsoft.Xna.Framework.Graphics.Model"/> will be loaded from disk once the relevant <see cref="Komodo.Core.ECS.Systems.Render3DSystem.Initialize"/>, <see cref="Komodo.Core.ECS.Systems.Render3DSystem.PreUpdate"/>, or <see cref="Komodo.Core.ECS.Systems.Render3DSystem.PostUpdate"/> is called.
        /// </remarks>
        /// <param name="modelPath">File path to a compiled <see cref="Microsoft.Xna.Framework.Graphics.Model"/> content file.</param>
        public Drawable3DComponent(string modelPath) : base(true, null)
        {
            ModelPath = modelPath;
            DiffuseColor = Color.White;
            Texture = null;
            TexturePath = null;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        /// <summary>
        /// Provides a <see cref="Microsoft.Xna.Framework.BoundingBox"/> representing the bounds of the model.
        /// </summary>
        public BoundingBox BoundingBox
        {
            get
            {
                var bounds = ModelData.BoundingBox;
                var min = bounds.Min;
                var max = bounds.Max;
                min.X *= Width;
                max.X *= Width;
                
                min.Y *= Height;
                max.Y *= Height;
                
                min.Z *= Depth;
                max.Z *= Depth;

                min += WorldPosition.MonoGameVector;
                max += WorldPosition.MonoGameVector;
                return new BoundingBox(min, max);
            }
        }

        /// <summary>
        /// <see cref="Microsoft.Xna.Framework.Color"/> to tint the entire <see cref="Komodo.Core.Engine.Graphics.Model"/> with.
        /// </summary>
        public Color DiffuseColor { get; set; }

        /// <summary>
        /// Z dimensional extremity.
        /// </summary>
        public float Depth
        {
            get
            {
                return ModelData.Depth * Parent.Scale.Z;
            }
        }

        /// <summary>
        /// Y dimensional extremity.
        /// </summary>
        public float Height
        {
            get
            {
                return ModelData.Height * Parent.Scale.Y;
            }
        }

        /// <summary>
        /// Raw model data loaded from disk.
        /// </summary>
        public Model ModelData { get; internal set; }

        /// <summary>
        /// Path of the <see cref="Komodo.Core.Engine.Graphics.Model"/> if the Drawable3DComponent was provided a model filepath via <see cref="Drawable3DComponent.Drawable3DComponent(string)"/>.
        /// </summary>
        public string ModelPath { get; internal set;  }

        /// <summary>
        /// Texture to be applied to the <see cref="Komodo.Core.Engine.Graphics.Model"/> surface. 
        /// </summary>
        public Texture Texture { get; set; }

        /// <summary>
        /// Path to texture to be applied to the <see cref="Komodo.Core.Engine.Graphics.Model"/> surface. 
        /// </summary>
        /// <remarks>
        /// Will only be read on <see cref="Komodo.Core.ECS.System.Render3DSystem.Initialize"/>. Will only be used if <see cref="Texture"/> is null.
        /// </remarks>
        public string TexturePath { get; set; }

        /// <summary>
        /// X dimensional extremity.
        /// </summary>
        public float Width
        {
            get
            {
                return ModelData.Width * Parent.Scale.X;
            }
        }
        #endregion Public Members

        #endregion Members
    }
}