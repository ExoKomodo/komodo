using Komodo.Core.ECS.Components;
using Komodo.Core.ECS.Entities;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System;

using GameTime = Microsoft.Xna.Framework.GameTime;

using SoundEffect = Microsoft.Xna.Framework.Audio.SoundEffect;
using SoundEffectInstance = Microsoft.Xna.Framework.Audio.SoundEffectInstance;
using SoundState = Microsoft.Xna.Framework.Audio.SoundState;

namespace Komodo.Core.ECS.Systems
{
    /// <summary>
    /// Manages all <see cref="Komodo.Core.ECS.Components.SoundComponent"/> objects.
    /// </summary>
    public class SoundSystem : ISystem<SoundComponent>
    {
        #region Constructors
        /// <param name="game">Reference to current <see cref="Komodo.Core.Game"/> instance.</param>
        public SoundSystem(Game game)
        {
            Components = new List<SoundComponent>();
            Entities = new Dictionary<Guid, Entity>();
            Game = game;
            _uninitializedComponents = new Queue<SoundComponent>();
        }
        #endregion Constructors

        #region Members

        #region Public Members
        /// <summary>
        /// All tracked <see cref="Komodo.Core.ECS.Components.SoundComponent"/> objects.
        /// </summary>
        public List<SoundComponent> Components { get; private set; }

        /// <summary>
        /// All tracked <see cref="Komodo.Core.ECS.Entities.Entity"/> objects.
        /// </summary>
        public Dictionary<Guid, Entity> Entities { get; set; }

        /// <summary>
        /// Reference to current <see cref="Komodo.Core.Game"/> instance.
        /// </summary>
        public Game Game { get; }

        /// <summary>
        /// Whether or not the SoundSystem has called <see cref="Initialize()"/>.
        /// </summary>
        public bool IsInitialized { get; private set; }
        #endregion Public Members

        #region Private Members
        /// <summary>
        /// Tracks all potentially uninitialized <see cref="Komodo.Core.ECS.Components.SoundComponent"/> objects.
        /// All <see cref="Komodo.Core.ECS.Components.SoundComponent"/> objects will be initialized in the <see cref="Initialize"/>, <see cref="PreUpdate(GameTime)"/>, or <see cref="PostUpdate(GameTime)"/> methods.
        /// </summary>
        private Queue<SoundComponent> _uninitializedComponents { get; }
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        /// <summary>
        /// Adds a <see cref="Komodo.Core.ECS.Entities.Entity"/> to the SoundSystem if the <see cref="Komodo.Core.ECS.Entities.Entity"/> is not already present.
        /// </summary>
        /// <param name="entityToAdd"><see cref="Komodo.Core.ECS.Entities.Entity"/> to add.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Entities.Entity"/> was added to this SoundSystem's <see cref="Entites"/>. Returns false if the <see cref="Komodo.Core.ECS.Entities.Entity"/> already existed.</returns>
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
            Game.SoundSystem.RemoveEntity(entityToAdd.ID);
            Entities[entityToAdd.ID] = entityToAdd;
            foreach (var component in entityToAdd.Components)
            {
                switch (component)
                {
                    case SoundComponent componentToAdd:
                        AddComponent(componentToAdd);
                        break;
                    default:
                        continue;
                }
            }
            return true;
        }

        /// <summary>
        /// Removes all <see cref="Komodo.Core.ECS.Entities.Entity"/> objects from the SoundSystem.
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
        /// Initializes the SoundSystem and all tracked <see cref="Komodo.Core.ECS.Components.SoundComponent"/> objects.
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
        /// Will initialize any new uninitialized <see cref="Komodo.Core.ECS.Components.SoundComponent"/> objects.
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
        /// Will initialize any new uninitialized <see cref="Komodo.Core.ECS.Components.SoundComponent"/> objects.
        /// </remarks>
        /// <param name="_">Time passed since last <see cref="Komodo.Core.Game.Update(GameTime)"/>.</param>
        public void PreUpdate(GameTime _)
        {
            InitializeComponents();
        }

        /// <summary>
        /// Removes a <see cref="Komodo.Core.ECS.Entities.Entity"/> from the SoundSystem, including all the <see cref="Komodo.Core.ECS.Entities.Entity"/>'s <see cref="Komodo.Core.ECS.Components.SoundComponent"/> objects.
        /// </summary>
        /// <param name="entityID">Unique identifier for the <see cref="Komodo.Core.ECS.Entities.Entity"/>.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Entities.Entity"/> was removed from this SoundSystem's <see cref="Entities"/>. Will return false if the <see cref="Komodo.Core.ECS.Entities.Entity"/> is not present in <see cref="Entities"/>.</returns>
        public bool RemoveEntity(Guid entityID)
        {
            if (Entities != null && Entities.ContainsKey(entityID))
            {
                return RemoveEntity(Entities[entityID]);
            }
            return false;
        }

        /// <summary>
        /// Removes a <see cref="Komodo.Core.ECS.Entities.Entity"/> from the SoundSystem, including all the <see cref="Komodo.Core.ECS.Entities.Entity"/>'s <see cref="Komodo.Core.ECS.Components.SoundComponent"/> objects.
        /// </summary>
        /// <param name="entityToRemove"><see cref="Komodo.Core.ECS.Entities.Entity"/> to remove.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Entities.Entity"/> was removed from this SoundSystem's <see cref="Entities"/>. Will return false if the <see cref="Komodo.Core.ECS.Entities.Entity"/> is not present in <see cref="Entities"/>.</returns>
        public bool RemoveEntity(Entity entityToRemove)
        {
            if (Entities != null && Entities.ContainsKey(entityToRemove.ID))
            {
                foreach (var component in entityToRemove.Components)
                {
                    switch (component)
                    {
                        case SoundComponent componentToRemove:
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
        #endregion Public Member Methods


        #region Internal Member Methods
        /// <summary>
        /// Adds a <see cref="Komodo.Core.ECS.Components.SoundComponent"/> to relevant <see cref="Components"/>. If the <see cref="Komodo.Core.ECS.Components.SoundComponent"/> is not initialized, it will be queued for initialization.
        /// </summary>
        /// <param name="componentToAdd"><see cref="Komodo.Core.ECS.Components.SoundComponent"/> to add.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Components.SoundComponent"/> was added to this SoundSystem's <see cref="Components"/>. Returns false if the <see cref="Komodo.Core.ECS.Components.SoundComponent"/> already existed.</returns>
        internal bool AddComponent(SoundComponent componentToAdd)
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
                return AddSoundComponent(componentToAdd);
            }
        }

        /// <summary>
        /// Removes an individual <see cref="Komodo.Core.ECS.Components.SoundComponent"/> from this SoundSystem's <see cref="Components"/>.
        /// </summary>
        /// <param name="componentToRemove"><see cref="Komodo.Core.ECS.Components.SoundComponent"/> to remove.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Components.SoundComponent"/> was removed from this SoundSystem's <see cref="Components"/>. Will return false if the <see cref="Komodo.Core.ECS.Components.SoundComponent"/> is not present in <see cref="Components"/>.</returns>
        internal bool RemoveComponent(SoundComponent componentToRemove)
        {
            return RemoveSoundComponent(componentToRemove);
        }

        /// <summary>
        /// Calls <see cref="UpdateComponent(SoundComponent, GameTime)"/> on each enabled <see cref="Komodo.Core.ECS.Components.SoundComponent"/>.
        /// </summary>
        /// <param name="gameTime">Time passed since last <see cref="Komodo.Core.Game.Update(GameTime)"/>.</param>
        internal void UpdateComponents(GameTime gameTime)
        {
            if (Components != null)
            {
                var componentsToUpdate = Components.ToArray();
                foreach (var component in componentsToUpdate)
                {
                    if (component.IsEnabled && component.Parent != null && component.Parent.IsEnabled)
                    {
                        UpdateComponent(component, gameTime);
                    }
                }
            }
        }
        #endregion Internal Member Methods

        #region Private Member Methods
        /// <summary>
        /// Adds a <see cref="Komodo.Core.ECS.Components.SoundComponent"/> to relevant <see cref="Components"/>. If the <see cref="Komodo.Core.ECS.Components.SoundComponent"/> is not initialized, it will be queued for initialization.
        /// </summary>
        /// <param name="componentToAdd"><see cref="Komodo.Core.ECS.Components.SoundComponent"/> to add.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Components.SoundComponent"/> was added to this SoundSystem's <see cref="Components"/>. Returns false if the <see cref="Komodo.Core.ECS.Components.SoundComponent"/> already existed.</returns>
        private bool AddSoundComponent([NotNull] SoundComponent componentToAdd)
        {
            if (Components.Contains(componentToAdd))
            {
                return false;
            }
            Components.Add(componentToAdd);
            return true;
        }

        /// <summary>
        /// Initializes all uninitialized <see cref="Komodo.Core.ECS.Components.SoundComponent"/>.
        /// </summary>
        private void InitializeComponents()
        {
            while (_uninitializedComponents.Count > 0)
            {
                var component = _uninitializedComponents.Dequeue();
                if (!component.IsInitialized)
                {
                    component.IsInitialized = true;
                    var loadedSound = Game.Content.Load<SoundEffect>(component.SoundPath);
                    component.Sound = loadedSound;
                }
            }
        }

        /// <summary>
        /// Removes an individual <see cref="Komodo.Core.ECS.Components.SoundComponent"/> from this SoundSystem's <see cref="Components"/>.
        /// </summary>
        /// <param name="componentToRemove"><see cref="Komodo.Core.ECS.Components.SoundComponent"/> to remove.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Components.SoundComponent"/> was removed from this SoundSystem's <see cref="Components"/>. Will return false if the <see cref="Komodo.Core.ECS.Components.SoundComponent"/> is not present in <see cref="Components"/>.</returns>
        private bool RemoveSoundComponent([NotNull] SoundComponent componentToRemove)
        {
            return Components.Remove(componentToRemove);
        }
        #endregion Private Member Methods

        #endregion Member Methods

        #region Static Methods

        #region Private Static Methods
        /// <summary>
        /// Performs the update logic on all <see cref="Komodo.Core.ECS.Components.SoundComponent"/> objects.
        /// </summary>
        /// <param name="component"><see cref="Komodo.Core.ECS.Components.SoundComponent"/> to update.</param>
        /// <param name="_">Time passed since last <see cref="Komodo.Core.Game.Update(GameTime)"/>.</param>
        private static void UpdateComponent(SoundComponent component, GameTime _)
        {
            var instances = new Dictionary<Guid, SoundEffectInstance>();
            foreach (var pair in component._instances)
            {
                var id = pair.Key;
                var instance = pair.Value;
                if (instance.State != SoundState.Stopped)
                {
                    instances[id] = instance;
                }
            }

            component._instances = instances;
        }
        #endregion Private Static Methods

        #endregion Static Methods
    }
}