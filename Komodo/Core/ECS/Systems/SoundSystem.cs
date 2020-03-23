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
    public class SoundSystem
    {
        #region Constructors
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
        public List<SoundComponent> Components { get; private set; }
        public Dictionary<Guid, Entity> Entities { get; set; }
        public Game Game { get; set; }
        public bool IsInitialized { get; private set; }
        #endregion Public Members

        #region Protected Members
        protected Queue<SoundComponent> _uninitializedComponents { get; }
        #endregion Protected Members

        #region Private Members
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        public bool AddComponent(SoundComponent componentToAdd)
        {
            if (!componentToAdd.IsInitialized)
            {
                _uninitializedComponents.Enqueue(componentToAdd);
            }
            return AddSoundComponent(componentToAdd);
        }

        public bool AddEntity([NotNull] Entity entityToAdd)
        {
            if (Entities == null)
            {
                Entities = new Dictionary<Guid, Entity>();
            }
            Game.BehaviorSystem.RemoveEntity(entityToAdd.ID);
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

        public bool RemoveComponent(SoundComponent componentToRemove)
        {
            return RemoveSoundComponent(componentToRemove);
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
                        case SoundComponent componentToRemove:
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


        #region Internal Member Methods
        internal void UpdateComponents(GameTime gameTime)
        {
            if (Components != null)
            {
                var componentsToUpdate = Components.ToArray();
                foreach (var component in componentsToUpdate)
                {
                    UpdateComponent(component, gameTime);
                }
            }
        }
        #endregion Internal Member Methods

        #region Private Member Methods
        private bool AddSoundComponent([NotNull] SoundComponent componentToAdd)
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
                    var loadedSound = Game.Content.Load<SoundEffect>(component.SoundPath);
                    component.Sound = loadedSound;
                }
            }
        }

        private bool RemoveSoundComponent([NotNull] SoundComponent componentToRemove)
        {
            return Components.Remove(componentToRemove);
        }

        private void UpdateComponent(SoundComponent component, GameTime _)
        {
            var instances = new List<SoundEffectInstance>();
            foreach (var instance in component.Instances)
            {
                if (instance.State != SoundState.Stopped)
                {
                    instances.Add(instance);
                }
            }

            component.Instances = instances;
        }
        #endregion Private Member Methods

        #endregion Member Methods
    }
}