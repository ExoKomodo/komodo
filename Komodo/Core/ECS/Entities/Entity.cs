using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Komodo.Core.ECS.Components;
using Komodo.Core.ECS.Systems;
using Microsoft.Xna.Framework;

namespace Komodo.Core.ECS.Entities
{
    public class Entity
    {
        #region Constructors
        public Entity([NotNull] KomodoGame game)
        {
            ID = Guid.NewGuid();
            Components = new List<Component>();
            Game = game;
            IsEnabled = true;
            Position = KomodoVector3.Zero;
            Rotation = KomodoVector3.Zero;
            Scale = KomodoVector3.One;
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
        public KomodoGame Game { get; private set; }
        public Guid ID { get; private set; }
        public bool IsEnabled { get; set; }
        public KomodoVector3 Position { get; set; }
        public Render2DSystem Render2DSystem { get; set; }
        public Render3DSystem Render3DSystem { get; set; }
        public KomodoVector3 Rotation { get; set; }
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
        public KomodoVector3 Scale { get; set; }
        #endregion Public Members

        #region Protected Members
        protected List<Component> _components;
        #endregion Protected Members

        #region Private Members
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        public void AddComponent(Component component)
        {
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
                    Game.BehaviorSystem.AddComponent(componentToAdd);
                    break;
                case CameraComponent componentToAdd:
                    if (Render2DSystem == null)
                    {
                        Render2DSystem = Game.CreateRender2DSystem();
                    }
                    if (Render3DSystem == null)
                    {
                        Render3DSystem = Game.CreateRender3DSystem();
                    }
                    Game.CameraSystem.AddComponent(componentToAdd);
                    break;
                case Drawable2DComponent componentToAdd:
                    if (Render2DSystem == null)
                    {
                        Render2DSystem = Game.CreateRender2DSystem();
                    }
                    Render2DSystem.AddComponent(componentToAdd);
                    break;
                case Drawable3DComponent componentToAdd:
                    if (Render3DSystem == null)
                    {
                        Render3DSystem = Game.CreateRender3DSystem();
                    }
                    Render3DSystem.AddComponent(componentToAdd);
                    break;
                default:
                    break;
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
        
        public bool RemoveComponent(Component component)
        {
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
                    default:
                        break;
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