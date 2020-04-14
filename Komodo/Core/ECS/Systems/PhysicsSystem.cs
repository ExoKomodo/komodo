using Komodo.Core.ECS.Components;
using Komodo.Core.ECS.Entities;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System;

using GameTime = Microsoft.Xna.Framework.GameTime;
using Komodo.Lib.Math;

namespace Komodo.Core.ECS.Systems
{
    /// <summary>
    /// Manages all <see cref="Komodo.Core.ECS.Components.PhysicsComponent"/> objects.
    /// </summary>
    public class PhysicsSystem : ISystem<PhysicsComponent>
    {
        #region Constructors
        /// <param name="game">Reference to current <see cref="Komodo.Core.Game"/> instance.</param>
        public PhysicsSystem(Game game)
        {
            Components = new List<PhysicsComponent>();
            Entities = new Dictionary<Guid, Entity>();
            Game = game;
            _uninitializedComponents = new Queue<PhysicsComponent>();
        }
        #endregion Constructors

        #region Members

        #region Public Members
        /// <summary>
        /// All tracked <see cref="Komodo.Core.ECS.Components.PhysicsComponent"/> objects.
        /// </summary>
        public List<PhysicsComponent> Components { get; private set; }

        /// <summary>
        /// All tracked <see cref="Komodo.Core.ECS.Entities.Entity"/> objects.
        /// </summary>
        public Dictionary<Guid, Entity> Entities { get; set; }

        /// <summary>
        /// Reference to current <see cref="Komodo.Core.Game"/> instance.
        /// </summary>
        public Game Game { get; }

        /// <summary>
        /// Whether or not the PhysicsSystem has called <see cref="Initialize()"/>.
        /// </summary>
        public bool IsInitialized { get; private set; }
        #endregion Public Members

        #region Private Members
        /// <summary>
        /// Tracks all potentially uninitialized <see cref="Komodo.Core.ECS.Components.PhysicsComponent"/> objects.
        /// All <see cref="Komodo.Core.ECS.Components.PhysicsComponent"/> objects will be initialized in the <see cref="Initialize"/>, <see cref="PreUpdate(GameTime)"/>, or <see cref="PostUpdate(GameTime)"/> methods.
        /// </summary>
        private Queue<PhysicsComponent> _uninitializedComponents { get; }
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        /// <summary>
        /// Adds a <see cref="Komodo.Core.ECS.Entities.Entity"/> to the PhysicsSystem if the <see cref="Komodo.Core.ECS.Entities.Entity"/> is not already present.
        /// </summary>
        /// <param name="entityToAdd"><see cref="Komodo.Core.ECS.Entities.Entity"/> to add.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Entities.Entity"/> was added to this PhysicsSystem's <see cref="Entites"/>. Returns false if the <see cref="Komodo.Core.ECS.Entities.Entity"/> already existed.</returns>
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
            if (entityToAdd.PhysicsSystem != null)
            {
                entityToAdd.PhysicsSystem.RemoveEntity(entityToAdd.ID);
            }
            Entities[entityToAdd.ID] = entityToAdd;
            foreach (var component in entityToAdd.Components)
            {
                switch (component)
                {
                    case PhysicsComponent componentToAdd:
                        AddComponent(componentToAdd);
                        break;
                    default:
                        continue;
                }
            }
            return true;
        }

        /// <summary>
        /// Removes all <see cref="Komodo.Core.ECS.Entities.Entity"/> objects from the PhysicsSystem.
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
        /// Initializes the PhysicsSystem and all tracked <see cref="Komodo.Core.ECS.Components.PhysicsComponent"/> objects.
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
        /// Will initialize any new uninitialized <see cref="Komodo.Core.ECS.Components.PhysicsComponent"/> objects.
        /// </remarks>
        /// <param name="_">Time passed since last <see cref="Komodo.Core.Game.Update(GameTime)"/>.</param>
        public void PostUpdate(GameTime _)
        {
            InitializeComponents();
            foreach (var component in Components)
            {
                switch (component)
                {
                    case KinematicBodyComponent kinematicBody:
                        kinematicBody.PositionDelta = Vector3.Zero;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Runs any operations needed at the beginning of the <see cref="Komodo.Core.Game.Update(GameTime)"/> loop.
        /// </summary>
        /// <remarks>
        /// Will initialize any new uninitialized <see cref="Komodo.Core.ECS.Components.PhysicsComponent"/> objects.
        /// </remarks>
        /// <param name="_">Time passed since last <see cref="Komodo.Core.Game.Update(GameTime)"/>.</param>
        public void PreUpdate(GameTime _)
        {
            InitializeComponents();
            foreach (var component in Components)
            {
                switch (component)
                {
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Removes a <see cref="Komodo.Core.ECS.Entities.Entity"/> from the PhysicsSystem, including all the <see cref="Komodo.Core.ECS.Entities.Entity"/>'s <see cref="Komodo.Core.ECS.Components.PhysicsComponent"/> objects.
        /// </summary>
        /// <param name="entityID">Unique identifier for the <see cref="Komodo.Core.ECS.Entities.Entity"/>.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Entities.Entity"/> was removed from this PhysicsSystem's <see cref="Entities"/>. Will return false if the <see cref="Komodo.Core.ECS.Entities.Entity"/> is not present in <see cref="Entities"/>.</returns>
        public bool RemoveEntity(Guid entityID)
        {
            if (Entities != null && Entities.ContainsKey(entityID))
            {
                return RemoveEntity(Entities[entityID]);
            }
            return false;
        }

        /// <summary>
        /// Removes a <see cref="Komodo.Core.ECS.Entities.Entity"/> from the PhysicsSystem, including all the <see cref="Komodo.Core.ECS.Entities.Entity"/>'s <see cref="Komodo.Core.ECS.Components.PhysicsComponent"/> objects.
        /// </summary>
        /// <param name="entityToRemove"><see cref="Komodo.Core.ECS.Entities.Entity"/> to remove.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Entities.Entity"/> was removed from this PhysicsSystem's <see cref="Entities"/>. Will return false if the <see cref="Komodo.Core.ECS.Entities.Entity"/> is not present in <see cref="Entities"/>.</returns>
        public bool RemoveEntity(Entity entityToRemove)
        {
            if (Entities != null && Entities.ContainsKey(entityToRemove.ID))
            {
                foreach (var component in entityToRemove.Components)
                {
                    switch (component)
                    {
                        case PhysicsComponent componentToRemove:
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
        /// Adds a <see cref="Komodo.Core.ECS.Components.PhysicsComponent"/> to relevant <see cref="Components"/>. If the <see cref="Komodo.Core.ECS.Components.PhysicsComponent"/> is not initialized, it will be queued for initialization.
        /// </summary>
        /// <param name="componentToAdd"><see cref="Komodo.Core.ECS.Components.PhysicsComponent"/> to add.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Components.PhysicsComponent"/> was added to this PhysicsSystem's <see cref="Components"/>. Returns false if the <see cref="Komodo.Core.ECS.Components.PhysicsComponent"/> already existed.</returns>
        internal bool AddComponent(PhysicsComponent componentToAdd)
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
                return AddPhysicsComponent(componentToAdd);
            }
        }

        /// <summary>
        /// Removes an individual <see cref="Komodo.Core.ECS.Components.PhysicsComponent"/> from this PhysicsSystem's <see cref="Components"/>.
        /// </summary>
        /// <param name="componentToRemove"><see cref="Komodo.Core.ECS.Components.PhysicsComponent"/> to remove.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Components.PhysicsComponent"/> was removed from this PhysicsSystem's <see cref="Components"/>. Will return false if the <see cref="Komodo.Core.ECS.Components.PhysicsComponent"/> is not present in <see cref="Components"/>.</returns>
        internal bool RemoveComponent(PhysicsComponent componentToRemove)
        {
            return RemovePhysicsComponent(componentToRemove);
        }

        /// <summary>
        /// Calls <see cref="Komodo.Core.ECS.Components.PhysicsComponent.Update(GameTime)"/> on each enabled <see cref="Komodo.Core.ECS.Components.PhysicsComponent"/>.
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
                        switch (component)
                        {
                            case KinematicBodyComponent kinematicBody:
                                UpdateKinematicBodyComponent(kinematicBody, gameTime);
                                break;
                            case DynamicBodyComponent dynamicBody:
                                UpdateDynamicBodyComponent(dynamicBody, gameTime);
                                break;
                            default:
                                break;
                        }
                    }
                }
                HandleCollisions();
            }
        }
        #endregion Internal Member Methods

        #region Private Member Methods
        /// <summary>
        /// Adds a <see cref="Komodo.Core.ECS.Components.PhysicsComponent"/> to relevant <see cref="Components"/>. If the <see cref="Komodo.Core.ECS.Components.PhysicsComponent"/> is not initialized, it will be queued for initialization.
        /// </summary>
        /// <param name="componentToAdd"><see cref="Komodo.Core.ECS.Components.PhysicsComponent"/> to add.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Components.PhysicsComponent"/> was added to this PhysicsSystem's <see cref="Components"/>. Returns false if the <see cref="Komodo.Core.ECS.Components.PhysicsComponent"/> already existed.</returns>
        private bool AddPhysicsComponent([NotNull] PhysicsComponent componentToAdd)
        {
            if (Components.Contains(componentToAdd))
            {
                return false;
            }
            Components.Add(componentToAdd);
            return true;
        }

        /// <summary>
        /// Calculates angular velocity for the current frame.
        /// </summary>
        private void CalculateAngularVelocity(DynamicBodyComponent body, float delta)
        {
            var angularAcceleration = new Vector3(
                body.Torque.X * (1.0f / body.Shape.MomentOfInertia.X),
                body.Torque.Y * (1.0f / body.Shape.MomentOfInertia.Y),
                body.Torque.Z * (1.0f / body.Shape.MomentOfInertia.Z)
            );
            body.AngularVelocity += angularAcceleration * delta;
        }

        /// <summary>
        /// Calculates linear velocity for the current frame.
        /// </summary>
        private void CalculateLinearVelocity(DynamicBodyComponent body, float delta)
        {
            var linearAcceleration = body.Force * (1f / body.Shape.Mass);
            body.LinearVelocity += linearAcceleration * delta;
        }

        /// <summary>
        /// Finds collisions and corrects them.
        /// </summary>
        private void HandleCollisions()
        {

        }

        /// <summary>
        /// Initializes all uninitialized <see cref="Komodo.Core.ECS.Components.PhysicsComponent"/>.
        /// </summary>
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

        /// <summary>
        /// Removes an individual <see cref="Komodo.Core.ECS.Components.PhysicsComponent"/> from this PhysicsSystem's <see cref="Components"/>.
        /// </summary>
        /// <param name="componentToRemove"><see cref="Komodo.Core.ECS.Components.PhysicsComponent"/> to remove.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Components.PhysicsComponent"/> was removed from this PhysicsSystem's <see cref="Components"/>. Will return false if the <see cref="Komodo.Core.ECS.Components.PhysicsComponent"/> is not present in <see cref="Components"/>.</returns>
        private bool RemovePhysicsComponent([NotNull] PhysicsComponent componentToRemove)
        {
            return Components.Remove(componentToRemove);
        }

        private void UpdateDynamicBodyComponent(DynamicBodyComponent body, GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            CalculateAngularVelocity(body, delta);
            CalculateLinearVelocity(body, delta);

            body.Parent.Position += body.LinearVelocity * delta;
            body.Parent.Rotation += body.AngularVelocity * delta;

            body.Force = Vector3.Zero;
            body.Torque = Vector3.Zero;
        }

        private void UpdateKinematicBodyComponent(KinematicBodyComponent body, GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            body.Parent.Position += body.PositionDelta * delta;
        }
        #endregion Protected Member Methods

        #endregion Member Methods
    }
}