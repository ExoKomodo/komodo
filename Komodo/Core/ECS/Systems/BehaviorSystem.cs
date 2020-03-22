using Komodo.Core.ECS.Components;
using Komodo.Core.ECS.Entities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System;

namespace Komodo.Core.ECS.Systems
{
    public class BehaviorSystem
    {
        #region Constructors
        public BehaviorSystem(KomodoGame game)
        {
            Components = new List<BehaviorComponent>();
            Entities = new Dictionary<Guid, Entity>();
            Game = game;
            _uninitializedComponents = new Queue<BehaviorComponent>();
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public List<BehaviorComponent> Components { get; private set; }
        public Dictionary<Guid, Entity> Entities { get; set; }
        public KomodoGame Game { get; set; }
        public bool IsInitialized { get; private set; }
        #endregion Public Members

        #region Protected Members
        protected Queue<BehaviorComponent> _uninitializedComponents { get; }
        #endregion Protected Members

        #region Private Members
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        public bool AddComponent(BehaviorComponent componentToAdd)
        {
            if (!componentToAdd.IsInitialized)
            {
                _uninitializedComponents.Enqueue(componentToAdd);
            }
            return AddBehaviorComponent(componentToAdd);
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
                    case BehaviorComponent componentToAdd:
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

        internal void UpdateComponents(GameTime gameTime)
        {
            if (Components != null)
            {
                var componentsToUpdate = Components.ToArray();
                Array.ForEach(componentsToUpdate, component => component.Update(gameTime));
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

        public void PostUpdate(GameTime gameTime)
        {
            InitializeComponents();
        }
        public void PreUpdate(GameTime gameTime)
        {
            InitializeComponents();
        }

        public bool RemoveComponent(BehaviorComponent componentToRemove)
        {
            return RemoveBehaviorComponent(componentToRemove);
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
                        case BehaviorComponent componentToRemove:
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
        private bool AddBehaviorComponent([NotNull] BehaviorComponent componentToAdd)
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
                    component.Initialize();
                }
            }
        }

        protected bool RemoveBehaviorComponent([NotNull] BehaviorComponent componentToRemove)
        {
            return Components.Remove(componentToRemove);
        }
        #endregion Protected Member Methods

        #region Private Member Methods
        #endregion Private Member Methods

        #endregion Member Methods
    }
}