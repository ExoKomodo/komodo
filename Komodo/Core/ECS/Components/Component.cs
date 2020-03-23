using System.Text.Json.Serialization;
using Komodo.Core.ECS.Entities;
using Komodo.Lib.Math;

using Matrix = Microsoft.Xna.Framework.Matrix;
using Quaternion = Microsoft.Xna.Framework.Quaternion;

namespace Komodo.Core.ECS.Components
{
    public abstract class Component
    {
        #region Constructors
        protected Component(bool isEnabled = true, Entity parent = null)
        {
            IsEnabled = isEnabled;
            Parent = parent;
        }
        #endregion

        #region Members

        #region Public Members
        public Game Game
        {
            get
            {
                return Parent?.Game;
            }
        }
        public bool IsEnabled { get; set; }
        public bool IsInitialized { get; internal set; }
        [JsonIgnore]
        public Entity Parent { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 WorldPosition
        {
            get
            {
                return Parent?.Position != null ? Vector3.Add(Parent.Position, Position) : Position;
            }
        }
        public Vector3 Rotation
        {
            get
            {
                return Parent?.Rotation != null ? Parent.Rotation : Vector3.Zero;
            }
            set
            {
                if (Parent != null)
                {
                    Parent.Rotation = value;
                }
            }
        }
        public Matrix RotationMatrix
        {
            get
            {
                return Parent?.RotationMatrix != null ? Parent.RotationMatrix : Matrix.CreateFromYawPitchRoll(0f, 0f, 0f);
            }
        }
        public Quaternion RotationQuaternion
        {
            get
            {
                return Parent?.RotationQuaternion != null ? Parent.RotationQuaternion : Quaternion.CreateFromYawPitchRoll(0f, 0f, 0f);
            }
        }
        public Vector3 Scale
        {
            get
            {
                return Parent?.Scale != null ? Parent.Scale : Vector3.Zero;
            }
            set
            {
                if (Parent != null)
                {
                    Parent.Scale = value;
                }
            }
        }
        #endregion Public Members

        #endregion Members
    }
}
