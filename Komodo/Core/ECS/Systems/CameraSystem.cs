using Komodo.Core.ECS.Components;
using Komodo.Core.ECS.Entities;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System;

using GameTime = Microsoft.Xna.Framework.GameTime;

namespace Komodo.Core.ECS.Systems
{
    /// <summary>
    /// Manages all <see cref="Komodo.Core.ECS.Components.CameraComponent"/> objects.
    /// </summary>
    public class CameraSystem : ISystem<CameraComponent>
    {
        #region Public

        #region Constructors
        /// <param name="game">Reference to current <see cref="Komodo.Core.Game"/> instance.</param>
        public CameraSystem(Game game)
        {
            Components = new List<CameraComponent>();
            Entities = new Dictionary<Guid, Entity>();
            Game = game;
            _uninitializedComponents = new Queue<CameraComponent>();
        }
        #endregion

        #region Members
        /// <summary>
        /// All tracked <see cref="Komodo.Core.ECS.Components.CameraComponent"/> objects.
        /// </summary>
        public List<CameraComponent> Components { get; private set; }

        /// <summary>
        /// All tracked <see cref="Komodo.Core.ECS.Entities.Entity"/> objects.
        /// </summary>
        public Dictionary<Guid, Entity> Entities { get; set; }

        /// <summary>
        /// Reference to current <see cref="Komodo.Core.Game"/> instance.
        /// </summary>
        public Game Game { get; }

        /// <summary>
        /// Whether or not the CameraSystem has called <see cref="Initialize()"/>.
        /// </summary>
        public bool IsInitialized { get; private set; }
        #endregion

        #region Member Methods
        /// <summary>
        /// Adds a <see cref="Komodo.Core.ECS.Entities.Entity"/> to the CameraSystem if the <see cref="Komodo.Core.ECS.Entities.Entity"/> is not already present.
        /// </summary>
        /// <param name="entityToAdd"><see cref="Komodo.Core.ECS.Entities.Entity"/> to add.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Entities.Entity"/> was added to this CameraSystem's <see cref="Entites"/>. Returns false if the <see cref="Komodo.Core.ECS.Entities.Entity"/> already existed.</returns>
        public bool AddEntity([NotNull] Entity entityToAdd)
        {
            if (Entities == null)
            {
                Entities = new Dictionary<Guid, Entity>();
            }
            if (Entities.ContainsKey(entityToAdd.ID))
            {
                return false;
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

        /// <summary>
        /// Removes all <see cref="Komodo.Core.ECS.Entities.Entity"/> objects from the CameraSystem.
        /// </summary>
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

        /// <summary>
        /// Initializes the CameraSystem and all tracked <see cref="Komodo.Core.ECS.Components.CameraComponent"/> objects.
        /// </summary>
        public void Initialize()
        {
            if (!IsInitialized)
            {
                IsInitialized = true;
                InitializeComponents();
            }
        }

        /// <summary>
        /// Runs any operations needed at the end of the <see cref="Komodo.Core.Game.Update(GameTime)"/> loop.
        /// </summary>
        /// <remarks>
        /// Will initialize any new uninitialized <see cref="Komodo.Core.ECS.Components.CameraComponent"/> objects.
        /// </remarks>
        /// <param name="_">Time passed since last <see cref="Komodo.Core.Game.Update(GameTime)"/>.</param>
        public void PostUpdate(GameTime _)
        {
            InitializeComponents();
        }

        /// <summary>
        /// Runs any operations needed at the beginning of the <see cref="Komodo.Core.Game.Update(GameTime)"/> loop.
        /// </summary>
        /// <remarks>
        /// Will initialize any new uninitialized <see cref="Komodo.Core.ECS.Components.CameraComponent"/> objects.
        /// </remarks>
        /// <param name="_">Time passed since last <see cref="Komodo.Core.Game.Update(GameTime)"/>.</param>
        public void PreUpdate(GameTime _)
        {
            InitializeComponents();
        }

        /// <summary>
        /// Removes a <see cref="Komodo.Core.ECS.Entities.Entity"/> from the CameraSystem, including all the <see cref="Komodo.Core.ECS.Entities.Entity"/>'s <see cref="Komodo.Core.ECS.Components.CameraComponent"/> objects.
        /// </summary>
        /// <param name="entityID">Unique identifier for the <see cref="Komodo.Core.ECS.Entities.Entity"/>.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Entities.Entity"/> was removed from this CameraSystem's <see cref="Entities"/>. Will return false if the <see cref="Komodo.Core.ECS.Entities.Entity"/> is not present in <see cref="Entities"/>.</returns>
        public bool RemoveEntity(Guid entityID)
        {
            if (Entities != null && Entities.ContainsKey(entityID))
            {
                return RemoveEntity(Entities[entityID]);
            }
            return false;
        }

        /// <summary>
        /// Removes a <see cref="Komodo.Core.ECS.Entities.Entity"/> from the CameraSystem, including all the <see cref="Komodo.Core.ECS.Entities.Entity"/>'s <see cref="Komodo.Core.ECS.Components.CameraComponent"/> objects.
        /// </summary>
        /// <param name="entityToRemove"><see cref="Komodo.Core.ECS.Entities.Entity"/> to remove.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Entities.Entity"/> was removed from this CameraSystem's <see cref="Entities"/>. Will return false if the <see cref="Komodo.Core.ECS.Entities.Entity"/> is not present in <see cref="Entities"/>.</returns>
        public bool RemoveEntity(Entity entityToRemove)
        {
            if (Entities != null && Entities.ContainsKey(entityToRemove.ID))
            {
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
                return Entities.Remove(entityToRemove.ID);
            }
            return false;
        }
        #endregion

        #endregion

        #region Internal

        #region Member Methods
        /// <summary>
        /// Adds a <see cref="Komodo.Core.ECS.Components.CameraComponent"/> to relevant <see cref="Components"/>. If the <see cref="Komodo.Core.ECS.Components.CameraComponent"/> is not initialized, it will be queued for initialization.
        /// </summary>
        /// <param name="componentToAdd"><see cref="Komodo.Core.ECS.Components.CameraComponent"/> to add.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Components.CameraComponent"/> was added to this CameraSystem's <see cref="Components"/>. Returns false if the <see cref="Komodo.Core.ECS.Components.CameraComponent"/> already existed.</returns>
        internal bool AddComponent(CameraComponent componentToAdd)
        {
            if (!componentToAdd.IsInitialized)
            {
                _uninitializedComponents.Enqueue(componentToAdd);
            }
            var parent = componentToAdd.Parent;
            if (!Entities.ContainsKey(parent.ID))
            {
                return AddEntity(parent);
            }
            else
            {
                return AddCameraComponent(componentToAdd);
            }
        }

        /// <summary>
        /// Removes an individual <see cref="Komodo.Core.ECS.Components.CameraComponent"/> from this CameraSystem's <see cref="Components"/>.
        /// </summary>
        /// <param name="componentToRemove"><see cref="Komodo.Core.ECS.Components.CameraComponent"/> to remove.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Components.CameraComponent"/> was removed from this CameraSystem's <see cref="Components"/>. Will return false if the <see cref="Komodo.Core.ECS.Components.CameraComponent"/> is not present in <see cref="Components"/>.</returns>
        internal bool RemoveComponent(CameraComponent componentToRemove)
        {
            return RemoveCameraComponent(componentToRemove);
        }

        /// <summary>
        /// Calls <see cref="Komodo.Core.ECS.Components.CameraComponent.Update(GameTime)"/> on each enabled <see cref="Komodo.Core.ECS.Components.CameraComponent"/>.
        /// </summary>
        /// <param name="gameTime">Time passed since last <see cref="Komodo.Core.Game.Update(GameTime)"/>.</param>
        internal void UpdateComponents(GameTime _)
        {
            if (Components != null)
            {
                var componentsToUpdate = Components.ToArray();
                foreach (var component in componentsToUpdate)
                {
                    if (component.IsEnabled && component.Parent != null && component.Parent.IsEnabled)
                    {
                        UpdateComponent(component);
                    }
                }
            }
        }
        #endregion

        #endregion

        #region Private

        #region Members
        /// <summary>
        /// Tracks all potentially uninitialized <see cref="Komodo.Core.ECS.Components.CameraComponent"/> objects.
        /// All <see cref="Komodo.Core.ECS.Components.CameraComponent"/> objects will be initialized in the <see cref="Initialize"/>, <see cref="PreUpdate(GameTime)"/>, or <see cref="PostUpdate(GameTime)"/> methods.
        /// </summary>
        private Queue<CameraComponent> _uninitializedComponents { get; }
        #endregion

        #region Member Methods
        /// <summary>
        /// Adds a <see cref="Komodo.Core.ECS.Components.CameraComponent"/> to relevant <see cref="Components"/>. If the <see cref="Komodo.Core.ECS.Components.CameraComponent"/> is not initialized, it will be queued for initialization.
        /// </summary>
        /// <param name="componentToAdd"><see cref="Komodo.Core.ECS.Components.CameraComponent"/> to add.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Components.CameraComponent"/> was added to this CameraSystem's <see cref="Components"/>. Returns false if the <see cref="Komodo.Core.ECS.Components.CameraComponent"/> already existed.</returns>
        private bool AddCameraComponent([NotNull] CameraComponent componentToAdd)
        {
            if (Components.Contains(componentToAdd))
            {
                return false;
            }
            Components.Add(componentToAdd);
            return true;
        }

        /// <summary>
        /// Initializes all uninitialized <see cref="Komodo.Core.ECS.Components.CameraComponent"/>.
        /// </summary>
        private void InitializeComponents()
        {
            while (_uninitializedComponents.Count > 0)
            {
                var component = _uninitializedComponents.Dequeue();
                if (!component.IsInitialized)
                {
                    UpdateComponent(component);
                    component.IsInitialized = true;
                }
            }
        }

        /// <summary>
        /// Removes an individual <see cref="Komodo.Core.ECS.Components.CameraComponent"/> from this CameraSystem's <see cref="Components"/>.
        /// </summary>
        /// <param name="componentToRemove"><see cref="Komodo.Core.ECS.Components.CameraComponent"/> to remove.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Components.CameraComponent"/> was removed from this CameraSystem's <see cref="Components"/>. Will return false if the <see cref="Komodo.Core.ECS.Components.CameraComponent"/> is not present in <see cref="Components"/>.</returns>
        private bool RemoveCameraComponent([NotNull] CameraComponent componentToRemove)
        {
            return Components.Remove(componentToRemove);
        }
        #endregion

        #region Static Methods
        /// <summary>
        /// Performs the update logic on all <see cref="Komodo.Core.ECS.Components.CameraComponent"/> objects.
        /// </summary>
        /// <param name="component"><see cref="Komodo.Core.ECS.Components.CameraComponent"/> to update.</param>
        private static void UpdateComponent([NotNull] CameraComponent component)
        {
            component.ViewMatrix = component.CalculateViewMatrix();
        }
        #endregion

        #endregion
    }
}