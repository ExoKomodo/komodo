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
    public class Entity
    {
        #region Constructors
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
        public List<Component> Components
        {
            get
            {
                return _components;
            }
            protected set
            {
                _components = value;
            }
        }
        public Game Game { get; private set; }
        public Guid ID { get; private set; }
        public bool IsEnabled { get; set; }
        public Vector3 Position { get; set; }
        public Render2DSystem Render2DSystem { get; set; }
        public Render3DSystem Render3DSystem { get; set; }
        public Vector3 Rotation { get; set; }
        public Matrix RotationMatrix
        {
            get
            {
                return Matrix.CreateFromYawPitchRoll(Rotation.Y, Rotation.X, Rotation.Z);
            }
        }
        public Quaternion RotationQuaternion
        {
            get
            {
                return Quaternion.CreateFromYawPitchRoll(Rotation.Y, Rotation.X, Rotation.Z);
            }
        }
        public Vector3 Scale { get; set; }
        #endregion Public Members

        #region Protected Members
        protected List<Component> _components;
        #endregion Protected Members

        #region Private Members
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
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
                    if (Render2DSystem == null)
                    {
                        Render2DSystem = Game.CreateRender2DSystem();
                    }
                    if (Render3DSystem == null)
                    {
                        Render3DSystem = Game.CreateRender3DSystem();
                    }
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

        public void ClearComponents()
        {
            var componentsToRemove = Components.ToArray();
            foreach (var component in componentsToRemove)
            {
                RemoveComponent(component);
            }
            Components.Clear();
        }
        
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

        #region Protected Member Methods
        #endregion Protected Member Methods

        #region Private Member Methods
        #endregion Private Member Methods

        #endregion Member Methods
    }
}