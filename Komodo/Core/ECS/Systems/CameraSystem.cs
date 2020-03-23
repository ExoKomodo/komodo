using Komodo.Core.ECS.Components;
using Komodo.Core.ECS.Entities;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System;

using GameTime = Microsoft.Xna.Framework.GameTime;

namespace Komodo.Core.ECS.Systems
{
    public class CameraSystem
    {
        #region Constructors
        public CameraSystem(Game game)
        {
            Components = new List<CameraComponent>();
            Entities = new Dictionary<Guid, Entity>();
            Game = game;
            _uninitializedComponents = new Queue<CameraComponent>();
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public List<CameraComponent> Components { get; private set; }
        public Dictionary<Guid, Entity> Entities { get; set; }
        public Game Game { get; set; }
        public bool IsInitialized { get; private set; }
        #endregion Public Members

        #region Protected Members
        protected Queue<CameraComponent> _uninitializedComponents { get; }
        #endregion Protected Members

        #region Private Members
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        public bool AddComponent(CameraComponent componentToAdd)
        {
            if (!componentToAdd.IsInitialized)
            {
                _uninitializedComponents.Enqueue(componentToAdd);
            }
            return AddCameraComponent(componentToAdd);
        }

        public bool AddEntity([NotNull] Entity entityToAdd)
        {
            if (Entities == null)
            {
                Entities = new Dictionary<Guid, Entity>();
            }
            Game.CameraSystem.RemoveEntity(entityToAdd.ID);
            Entities[entityToAdd.ID] = entityToAdd;
            foreach (var component in entityToAdd.Components)
            {
                switch (component)
                {
                    case CameraComponent componentToAdd:
                        AddComponent(componentToAdd);
                        break;
                    default:
                        continue;
                }
            }
            return true;
        }

        public void ClearEntities()
        {
            if (Entities != null)
            {
                foreach (var entityID in Entities.Keys)
                {
                    RemoveEntity(entityID);
                }
                Entities.Clear();
            }
        }

        internal void UpdateComponents()
        {
            if (Components != null)
            {
                var componentsToUpdate = Components.ToArray();
                Array.ForEach(componentsToUpdate, component => UpdateComponent(component));
            }
        }

        public void Initialize()
        {
            if (!IsInitialized)
            {
                IsInitialized = true;
                InitializeComponents();
            }
        }

        public void PostUpdate(GameTime _)
        {
            InitializeComponents();
        }
        public void PreUpdate(GameTime _)
        {
            InitializeComponents();
        }

        public bool RemoveComponent(CameraComponent componentToRemove)
        {
            return RemoveCameraComponent(componentToRemove);
        }

        public bool RemoveEntity(Guid entityID)
        {
            if (Entities != null && Entities.ContainsKey(entityID))
            {
                var entityToRemove = Entities[entityID];
                foreach (var component in entityToRemove.Components)
                {
                    switch (component)
                    {
                        case CameraComponent componentToRemove:
                            RemoveComponent(componentToRemove);
                            break;
                        default:
                            continue;
                    }
                }
                return Entities.Remove(entityID);
            }
            return false;
        }
        #endregion Public Member Methods

        #region Private Member Methods
        private bool AddCameraComponent([NotNull] CameraComponent componentToAdd)
        {
            if (Components.Contains(componentToAdd))
            {
                return false;
            }
            Components.Add(componentToAdd);
            return true;
        }

        private void InitializeComponents()
        {
            while (_uninitializedComponents.Count > 0)
            {
                var component = _uninitializedComponents.Dequeue();
                if (!component.IsInitialized)
                {
                    component.IsInitialized = true;
                    UpdateComponent(component);
                }
            }
        }

        protected bool RemoveCameraComponent([NotNull] CameraComponent componentToRemove)
        {
            return Components.Remove(componentToRemove);
        }

        private void UpdateComponent([NotNull] CameraComponent component)
        {
            component.ViewMatrix = component.CalculateViewMatrix();
        }
        #endregion Protected Member Methods

        #region Private Member Methods
        #endregion Private Member Methods

        #endregion Member Methods
    }
}