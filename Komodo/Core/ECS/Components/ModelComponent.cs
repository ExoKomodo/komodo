using Komodo.Core.Engine.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Komodo.Core.ECS.Components
{
    public class ModelComponent : Drawable3DComponent
    {
        #region Constructors
        public ModelComponent(KomodoModel model, Effect shader) : base(true, null)
        {
            ModelData = model;
            ModelPath = null;
            DiffuseColor = Color.White;
            Texture = null;
        }
        public ModelComponent(string modelPath) : base(true, null)
        {
            var loadedModel = KomodoGame.Content.Load<Model>(modelPath);
            ModelData = new KomodoModel(loadedModel);
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
        public KomodoModel ModelData { get; set; }
        public string ModelPath { get; set; }
        public KomodoTexture Texture { get; set; }
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

        #region Member Methods

        #region Public Member Methods
        public override void Deserialize(SerializedObject serializedObject)
        {
            
        }

        public override void Draw()
        {
            var position = WorldPosition;
            var rotationMatrix = RotationMatrix;
            var scale = Scale;
            var camera = Parent.ParentScene.ActiveCamera;
            if (camera != null)
            {
                position = KomodoVector3.Transform(
                    position,
                    camera.ViewMatrix
                    * Matrix.CreateScale(1f, 1f, -1f)
                );
            }
            var positionMatrix = Matrix.CreateTranslation(position.MonoGameVector);

            foreach (var mesh in ModelData.MonoGameModel.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.Texture = Texture?.MonoGameTexture;
                    effect.TextureEnabled = Texture?.MonoGameTexture != null;
                    effect.DiffuseColor = DiffuseColor.ToVector3();
                    effect.World = Matrix.CreateScale(scale.MonoGameVector) * rotationMatrix * positionMatrix;

                    effect.Projection = camera.Projection;
                }

                mesh.Draw();
            }
        }

        public override SerializedObject Serialize()
        {
            var serializedObject = new SerializedObject();
            serializedObject.Type = this.GetType().ToString();

            return serializedObject;
        }
        #endregion Public Member Methods

        #region Protected Member Methods
        #endregion Protected Member Methods

        #region Private Member Methods
        #endregion Private Member Methods

        #endregion Member Methods
    }
}