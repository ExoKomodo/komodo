using Komodo.Lib.Math;
using BoundingBox = Microsoft.Xna.Framework.BoundingBox;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Komodo.Core.Engine.Graphics
{
    /// <summary>
    /// Represents raw 3D model data.
    /// </summary>
    public class Model
    {
        #region Constructors
        /// <param name="monoGameModel"><see cref="Microsoft.Xna.Framework.Graphics.Model"/> data loaded in MonoGame's format.</param>
        public Model(Microsoft.Xna.Framework.Graphics.Model monoGameModel)
        {
            MonoGameModel = monoGameModel;
            BoundingBox = CalculateBoundingBox();

            var dimensions = BoundingBox.Max - BoundingBox.Min;
            Depth = dimensions.Z;
            Height = dimensions.Y;
            Width = dimensions.X;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        /// <summary>
        /// Z dimensional extremity.
        /// </summary>
        public float Depth { get; private set; }

        /// <summary>
        /// Y dimensional extremity.
        /// </summary>
        public float Height { get; private set; }

        /// <summary>
        /// Provides a <see cref="Microsoft.Xna.Framework.BoundingBox"/> representing the bounds of the model.
        /// </summary>
        public BoundingBox BoundingBox { get; private set; }

        /// <summary>
        /// X dimensional extremity.
        /// </summary>
        public float Width { get; private set; }

        /// <summary>
        /// Raw 3D model data.
        /// </summary>
        public Microsoft.Xna.Framework.Graphics.Model MonoGameModel { get; private set; }
        #endregion Public Members

        #endregion Members

        #region Member Methods
        
        #region Private Member Methods
        /// <summary>
        /// Calculates the bounding box from the raw model data.
        /// </summary>
        private BoundingBox CalculateBoundingBox()
        {
            Vector3 min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            Vector3 max = new Vector3(float.MinValue, float.MinValue, float.MinValue);

            foreach (var mesh in MonoGameModel.Meshes)
            {
                foreach (var meshPart in mesh.MeshParts)
                {
                    int vertexStride = meshPart.VertexBuffer.VertexDeclaration.VertexStride;
                    int vertexBufferSize = meshPart.NumVertices * vertexStride;

                    int vertexDataSize = vertexBufferSize / sizeof(float);
                    float[] vertexData = new float[vertexDataSize];
                    meshPart.VertexBuffer.GetData(vertexData);

                    for (int i = 0; i < vertexDataSize; i += vertexStride / sizeof(float))
                    {
                        Vector3 vertex = new Vector3(vertexData[i], vertexData[i + 1], vertexData[i + 2]);
                        min = Vector3.Min(min, vertex);
                        max = Vector3.Max(max, vertex);
                    }
                }
            }

            return new BoundingBox(min.MonoGameVector, max.MonoGameVector);
        }
        #endregion Private Member Methods

        #endregion Member Methods
    }
}