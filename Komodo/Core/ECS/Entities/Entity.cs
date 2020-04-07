using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Komodo.Core.ECS.Components;
using Komodo.Core.ECS.Systems;
using Komodo.Lib.Math;

using Matrix = Microsoft.Xna.Framework.Matrix;
using Quaternion = Microsoft.Xna.Framework.Quaternion;

namespace Komodo.Core.ECS.Entities
{
    /// <summary>
    /// Represents a collection of <see cref="Komodo.Core.ECS.Components.Component"/> objects tracked by the relevant <see cref="Komodo.Core.ECS.Systems.ISystem"/> objects.
    /// </summary>
    public class Entity
    {
        #region Constructors
        /// <param name="game">Reference to current <see cref="Komodo.Core.Game"/> instance.</param>
        public Entity([NotNull] Game game)
        {
            ID = Guid.NewGuid();
            Components = new List<Component>();
            Game = game;
            IsEnabled = true;
            Position = Vector3.Zero;
            Rotation = Vector3.Zero;
            Scale = Vector3.One;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        /// <summary>
        /// All tracked <see cref="Komodo.Core.ECS.Components.Component"/> objects.
        /// </summary>
        public List<Component> Components { get; private set; }

        /// <summary>
        /// Reference to current <see cref="Komodo.Core.Game"/> instance.
        /// </summary>
        public Game Game { get; private set; }

        /// <summary>
        /// Unique identifier for the Entity.
        /// </summary>
        public Guid ID { get; private set; }

        /// <summary>
        /// Whether or not the Entity and all child Components should be drawn or updated.
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Position in world space. Used by <see cref="Komodo.Core.ECS.Components.Component"/> objects to determine their world space.
        /// </summary>
        public Vector3 Position { get; set; }

        /// <summary>
        /// Defines what <see cref="Komodo.Core.ECS.Systems.Render2DSystem"/> should be used to render <see cref="Komodo.Core.ECS.Components.Drawable2DComponent"/> objects. This allows for <see cref="Komodo.Core.ECS.Components.CameraComponent"/> objects to render specific subsets of all Entity objects.
        /// </summary>
        public Render2DSystem Render2DSystem { get; set; }

        /// <summary>
        /// Defines what <see cref="Komodo.Core.ECS.Systems.Render3DSystem"/> should be used to render <see cref="Komodo.Core.ECS.Components.Drawable3DComponent"/> objects. This allows for <see cref="Komodo.Core.ECS.Components.CameraComponent"/> objects to render specific subsets of all Entity objects.
        /// </summary>
        public Render3DSystem Render3DSystem { get; set; }
        
        /// <summary>
        /// Rotation in world space.
        /// </summary>
        public Vector3 Rotation { get; set; }

        /// <summary>
        /// Rotation in world space as a <see cref="Microsoft.Xna.Framework.Matrix"/>.
        /// </summary>
        public Matrix RotationMatrix => Matrix.CreateFromYawPitchRoll(Rotation.Y, Rotation.X, Rotation.Z);

        /// <summary>
        /// Rotation in world space as a <see cref="Microsoft.Xna.Framework.Quaternion"/>.
        /// </summary>
        public Quaternion RotationQuaternion => Quaternion.CreateFromYawPitchRoll(Rotation.Y, Rotation.X, Rotation.Z);
        
        /// <summary>
        /// Scaling for the entire entity. Scales all child <see cref="Komodo.Core.ECS.Components.Component"/> objects.
        /// </summary>
        public Vector3 Scale { get; set; }
        #endregion Public Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        /// <summary>
        /// Adds a <see cref="Komodo.Core.ECS.Components.Component"/> to the relevant <see cref="Komodo.Core.ECS.Systems.ISystem"/>. <see cref="AddComponent(Component)"/> will also remove the <see cref="Komodo.Core.ECS.Components.Component"/> from any Entity and <see cref="Komodo.Core.ECS.Systems.ISystem"/> it was attached to before.
        /// </summary>
        /// <param name="component"><see cref="Komodo.Core.ECS.Components.Component"/> to add.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Components.Component"/> was added to this Entity's <see cref="Components"/>. Returns false if the <see cref="Komodo.Core.ECS.Components.Component"/> already existed.</returns>
        public bool AddComponent([NotNull] Component component)
        {
            if (component == null)
            {
                return false;
            }
            if (Components == null)
            {
                Components = new List<Component>();
            }
            if (Components.Contains(component))
            {
                return false;
            }
            if (component.Parent != null)
            {
                component.Parent.RemoveComponent(component);
            }
            Components.Add(component);
            component.Parent = this;
            switch (component)
            {
                case BehaviorComponent componentToAdd:
                    return Game.BehaviorSystem.AddComponent(componentToAdd);
                case CameraComponent componentToAdd:
                    return Game.CameraSystem.AddComponent(componentToAdd);
                case Drawable2DComponent componentToAdd:
                    if (Render2DSystem == null)
                    {
                        Render2DSystem = Game.CreateRender2DSystem();
                    }
                    return Render2DSystem.AddComponent(componentToAdd);
                case Drawable3DComponent componentToAdd:
                    if (Render3DSystem == null)
                    {
                        Render3DSystem = Game.CreateRender3DSystem();
                    }
                    return Render3DSystem.AddComponent(componentToAdd);
                case SoundComponent componentToAdd:
                    return Game.SoundSystem.AddComponent(componentToAdd);
                default:
                    return false;
            }
        }

        /// <summary>
        /// Removes all <see cref="Komodo.Core.ECS.Components.Component"/> objects from the Entity.
        /// </summary>
        public void ClearComponents()
        {
            var componentsToRemove = Components.ToArray();
            foreach (var component in componentsToRemove)
            {
                RemoveComponent(component);
            }
            Components.Clear();
        }

        /// <summary>
        /// Removes an individual <see cref="Komodo.Core.ECS.Components.Component"/> from this Entity's <see cref="Components"/>.
        /// </summary>
        /// <param name="component"><see cref="Komodo.Core.ECS.Components.Component"/> to remove.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Components.Component"/> was removed from this Entity's <see cref="Components"/>. Will return false if the <see cref="Komodo.Core.ECS.Components.Component"/> is not present in <see cref="Components"/>.</returns>
        public bool RemoveComponent([NotNull] Component component)
        {
            if (component == null)
            {
                return false;
            }
            if (Components != null)
            {
                switch (component)
                {
                    case BehaviorComponent componentToRemove:
                        if (!Game.BehaviorSystem.RemoveComponent(componentToRemove))
                        {
                            return false;
                        }
                        break;
                    case CameraComponent componentToRemove:
                        if (!Game.CameraSystem.RemoveComponent(componentToRemove))
                        {
                            return false;
                        }
                        break;
                    case Drawable2DComponent componentToRemove:
                        if (Render2DSystem != null)
                        {
                            if (!Render2DSystem.RemoveComponent(componentToRemove))
                            {
                                return false;
                            }
                        }
                        break;
                    case Drawable3DComponent componentToRemove:
                        if (Render3DSystem != null)
                        {
                            if (!Render3DSystem.RemoveComponent(componentToRemove))
                            {
                                return false;
                            }
                        }
                        break;
                    case SoundComponent componentToRemove:
                        if (!Game.SoundSystem.RemoveComponent(componentToRemove))
                        {
                            return false;
                        }
                        break;
                    default:
                        return false;
                }
                component.Parent = null;
                return Components.Remove(component);
            }
            return false;
        }
        #endregion Public Member Methods

        #endregion Member Methods
    }
}