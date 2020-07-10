using System;
using System.Text.Json.Serialization;
using Komodo.Core.ECS.Entities;
using Komodo.Lib.Math;

using Matrix = Microsoft.Xna.Framework.Matrix;
using Quaternion = Microsoft.Xna.Framework.Quaternion;

namespace Komodo.Core.ECS.Components
{
    /// <summary>
    /// Abstract class defining all Components.
    /// A class derived from Component will be managed by an appropriate <see cref="Komodo.Core.ECS.Systems.ISystem"/>.
    /// </summary>
    public abstract class Component
    {
        #region Public

        #region Constructors
        public Component(bool isEnabled = true, Entity parent = null)
        {
            ID = Guid.NewGuid();
            IsEnabled = isEnabled;
            Parent = parent;
        }
        #endregion

        #region Members
        /// <summary>
        /// Each Component maintains a reference to the <see cref="Komodo.Core.Game"/> instance.
        /// </summary>
        public Game Game
        {
            get
            {
                return Parent?.Game;
            }
        }

        /// <summary>
        /// Unique identifier for the Component.
        /// </summary>
        public Guid ID { get; private set; }

        /// <summary>
        /// Enabled Components are managed by their corresponding <see cref="Komodo.Core.ECS.Systems.ISystem"/>, otherwise the Component is ignored.
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Uninitialized Components are initialized by their corresponding <see cref="Komodo.Core.ECS.Systems.ISystem"/>,
        /// otherwise the Component is initialized on the next <see cref="Komodo.Core.ECS.Systems.ISystem.Initialize"/>, <see cref="Komodo.Core.ECS.Systems.ISystem.PreUpdate"/>, or <see cref="Komodo.Core.ECS.Systems.ISystem.PostUpdate"/> methods.
        /// </summary>
        public bool IsInitialized { get; internal set; }

        /// <summary>
        /// Each Component belongs to a <see cref="Komodo.Core.ECS.Entities.Entity"/> and maintains a reference to the parent <see cref="Komodo.Core.ECS.Entities.Entity"/>.
        /// </summary>
        public Entity Parent { get; set; }

        /// <summary>
        /// Each Component has a position relative to their <see cref="Parent"/>.
        /// </summary>
        public Vector3 Position { get; set; }

        /// <summary>
        /// The sum of <see cref="Position"/> and the <see cref="Parent"/>'s <see cref="Komodo.Core.ECS.Entities.Entity.Position"/>, representing the Component's position in world space.
        /// </summary>
        public Vector3 WorldPosition
        {
            get
            {
                return Parent?.Position != null ? Vector3.Add(Parent.Position, Position) : Position;
            }
        }

        /// <summary>
        /// Derived from the <see cref="Parent"/>'s <see cref="Komodo.Core.ECS.Entities.Entity.Rotation"/>.
        /// </summary>
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

        /// <summary>
        /// Derived from the <see cref="Parent"/>'s <see cref="Komodo.Core.ECS.Entities.Entity.RotationMatrix"/>.
        /// </summary>
        public Matrix RotationMatrix
        {
            get
            {
                return Parent?.RotationMatrix != null ? Parent.RotationMatrix : Matrix.CreateFromYawPitchRoll(0f, 0f, 0f);
            }
        }

        /// <summary>
        /// Derived from the <see cref="Parent"/>'s <see cref="Komodo.Core.ECS.Entities.Entity.RotationQuaternion"/>.
        /// </summary>
        public Quaternion RotationQuaternion
        {
            get
            {
                return Parent?.RotationQuaternion != null ? Parent.RotationQuaternion : Quaternion.CreateFromYawPitchRoll(0f, 0f, 0f);
            }
        }

        /// <summary>
        /// Derived from the <see cref="Parent"/>'s <see cref="Komodo.Core.ECS.Entities.Entity.Scale"/>.
        /// </summary>
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
        #endregion

        #endregion
    }
}
