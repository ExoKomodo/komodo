using Komodo.Core.ECS.Components;
using Komodo.Core.ECS.Entities;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System;
using Komodo.Lib.Math;
using System.Linq;
using Komodo.Core.Physics;

using BoundingBox = Microsoft.Xna.Framework.BoundingBox;
using BoundingSphere = Microsoft.Xna.Framework.BoundingSphere;
using ContainmentType = Microsoft.Xna.Framework.ContainmentType;
using GameTime = Microsoft.Xna.Framework.GameTime;
using MathHelper = Microsoft.Xna.Framework.MathHelper;

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
                    case DynamicBodyComponent dynamicBody:
                        dynamicBody.Force = Vector3.Zero;
                        dynamicBody.Torque = Vector3.Zero;
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
                foreach (var component in Components)
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
        /// Corrects all current collisions between <see cref="Komodo.Core.ECS.Components.DynamicBodyComponent"/> and <see cref="Komodo.Core.ECS.Components.StaticBodyComponent"/>s.
        /// </summary>
        private void CorrectCollisions()
        {
            var dynamicBodies = Components.Where(body => body is DynamicBodyComponent && body.IsEnabled && body.Parent.IsEnabled).Cast<DynamicBodyComponent>();
            foreach (var body in dynamicBodies)
            {
                var ids = body.Collisions.Keys.ToList();
                foreach (var id in ids)
                {
                    var collision = body.Collisions[id];
                    if (collision._isResolved)
                    {
                        continue;
                    }
                    var otherBody = Components.Find(b => b.ID == id) as RigidBodyComponent;
                    if (collision.IsColliding)
                    {
                        switch (otherBody)
                        {
                            case DynamicBodyComponent dynamicBody:
                                body.Parent.Position += collision.Correction / 2f;
                                var otherCollision = dynamicBody.Collisions[body.ID];
                                otherCollision._isResolved = true;
                                dynamicBody.Parent.Position += otherCollision.Correction / 2f;
                                body.LinearVelocity = Vector3.Reflect(body.LinearVelocity, collision.Normal) * body.Material.Restitution;
                                break;
                            case StaticBodyComponent _:
                                body.Parent.Position += collision.Correction;
                                body.LinearVelocity = Vector3.Reflect(body.LinearVelocity, collision.Normal) * body.Material.Restitution;
                                break;
                            default:
                                break;
                        }
                    }
                    collision._isResolved = true;
                }
            }
        }

        /// <summary>
        /// Detects collisions of all enabled <see cref="Komodo.Core.ECS.Components.PhysicsComponent"/>s.
        /// </summary>
        private void DetectCollisions()
        {
            var rigidBodies = Components.Where(body => body is RigidBodyComponent && body.IsEnabled && body.Parent.IsEnabled).Cast<RigidBodyComponent>();
            foreach (var outerBody in rigidBodies)
            {
                var outerShape = outerBody.Shape;
                foreach (var innerBody in rigidBodies)
                {
                    if (innerBody == outerBody || outerBody.Collisions.ContainsKey(innerBody.ID))
                    {
                        continue;
                    }
                    var innerShape = innerBody.Shape;
                    switch (outerShape)
                    {
                        case Box _:
                            var outerBoundingBox = GenerateBoundingBox(outerBody);
                            switch (innerShape)
                            {
                                case Box _:
                                    var innerBoundingBox = GenerateBoundingBox(innerBody);
                                    var collision = GetCollision(outerBoundingBox, innerBoundingBox);
                                    if (collision.IsColliding)
                                    {
                                        outerBody.Collisions[innerBody.ID] = collision;
                                        innerBody.Collisions[outerBody.ID] = new Collision(collision.IsColliding, -collision.Normal, collision.PenetrationDepth);
                                    }
                                    break;
                                case Sphere _:
                                    var innerBoundingSphere = GenerateBoundingSphere(innerBody);
                                    collision = GetCollision(outerBoundingBox, innerBoundingSphere);
                                    if (collision.IsColliding)
                                    {
                                        outerBody.Collisions[innerBody.ID] = collision;
                                        innerBody.Collisions[outerBody.ID] = new Collision(collision.IsColliding, -collision.Normal, collision.PenetrationDepth);
                                    }
                                    break;
                            }
                            break;
                        case Sphere _:
                            var outerBoundingSphere = GenerateBoundingSphere(outerBody);
                            switch (innerShape)
                            {
                                case Box _:
                                    var innerBoundingBox = GenerateBoundingBox(innerBody);
                                    var collision = GetCollision(outerBoundingSphere, innerBoundingBox);
                                    if (collision.IsColliding)
                                    {
                                        outerBody.Collisions[innerBody.ID] = collision;
                                        innerBody.Collisions[outerBody.ID] = new Collision(collision.IsColliding, -collision.Normal, collision.PenetrationDepth);
                                    }
                                    break;
                                case Sphere _:
                                    var innerBoundingSphere = GenerateBoundingSphere(innerBody);
                                    collision = GetCollision(outerBoundingSphere, innerBoundingSphere);
                                    if (collision.IsColliding)
                                    {
                                        outerBody.Collisions[innerBody.ID] = collision;
                                        innerBody.Collisions[outerBody.ID] = new Collision(collision.IsColliding, -collision.Normal, collision.PenetrationDepth);
                                    }
                                    break;
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Detects collisions and corrects them.
        /// </summary>
        private void HandleCollisions()
        {
            foreach (var component in Components)
            {
                component.Collisions.Clear();
            }
            DetectCollisions();
            CorrectCollisions();
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
        #endregion Protected Member Methods

        #endregion Member Methods

        #region Static Methods

        #region Private Static Methods
        /// <summary>
        /// Performs an AABB AABB collision check.
        /// </summary>
        /// <param name="a">First AABB.</param>
        /// <param name="b">Second AABB.</param>
        /// <returns></returns>
        private static Collision AABBAABB(BoundingBox a, BoundingBox b)
        {
            // Minimum Translation Vector
            // ==========================
            float minimumTranslationVectorDistance = float.MaxValue; // Set current minimum distance (max float value so next value is always less)
            Vector3 minimumTranslationVectorAxis = new Vector3();    // Axis along which to travel with the minimum distance
            var containment = a.Contains(b);
            var normal = Vector3.Zero;
            float penetrationDepth = 0f;
            if (containment == ContainmentType.Disjoint)
            {
                return new Collision(false, normal, penetrationDepth);
            }

            // Axes of potential separation
            // ============================
            // - Each shape must be projected on these axes to test for intersection:
            //          
            // (1, 0, 0)                    A0 (= B0) [X Axis]
            // (0, 1, 0)                    A1 (= B1) [Y Axis]
            // (0, 0, 1)                    A1 (= B2) [Z Axis]

            // [X Axis]
            if (!SAT(Vector3.Right, a.Min.X, a.Max.X, b.Min.X, b.Max.X, ref minimumTranslationVectorAxis, ref minimumTranslationVectorDistance))
            {
                return new Collision(false, normal, penetrationDepth);
            }
            // [Y Axis]
            if (!SAT(Vector3.Up, a.Min.Y, a.Max.Y, b.Min.Y, b.Max.Y, ref minimumTranslationVectorAxis, ref minimumTranslationVectorDistance))
            {
                return new Collision(false, normal, penetrationDepth);
            }
            // [Z Axis]
            if (!SAT(Vector3.Back, a.Min.Z, a.Max.Z, b.Min.Z, b.Max.Z, ref minimumTranslationVectorAxis, ref minimumTranslationVectorDistance))
            {
                return new Collision(false, normal, penetrationDepth);
            }

            // Calculate Minimum Translation Vector (MTV) [normal * penetration]
            normal = Vector3.Normalize(minimumTranslationVectorAxis);

            // Multiply the penetration depth by itself plus a small increment
            // When the penetration is resolved using MTV, it will no longer intersect
            penetrationDepth = MathF.Sqrt(minimumTranslationVectorDistance) * 1.001f;

            return new Collision(true, normal, penetrationDepth);
        }

        /// <summary>
        /// Calculates angular velocity for the current frame.
        /// </summary>
        private static void CalculateAngularVelocity(DynamicBodyComponent body, float delta)
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
        private static void CalculateLinearVelocity(DynamicBodyComponent body, float delta)
        {
            var material = body.Material;
            var linearAcceleration = body.Force * (1f / body.Shape.Mass);
            body.LinearVelocity += linearAcceleration * delta;
            body.LinearVelocity *= 1f - (material.LinearDamping * delta);
            if (MathF.Abs(body.LinearVelocity.Length()) <= material.LinearDampingLimit)
            {
                body.LinearVelocity = Vector3.Zero;
            }
        }

        /// <summary>
        /// Generates a <see cref="Microsoft.Xna.Framework.BoundingBox"/> for a <see cref="Komodo.Core.ECS.Components.RigidBodyComponent"/> with an attached <see cref="Komodo.Core.Physics.Box"/>.
        /// </summary>
        /// <param name="body">Body to create a <see cref="Microsoft.Xna.Framework.BoundingBox"/> for.</param>
        /// <returns><see cref="Microsoft.Xna.Framework.BoundingBox"/> representation of the <see cref="Komodo.Core.Physics.Box"/>.</returns>
        private static BoundingBox GenerateBoundingBox(RigidBodyComponent body)
        {
            var box = body.Shape as Box;
            var max = new Vector3(
                MathHelper.Max(-box.Width / 2f, box.Width / 2f),
                MathHelper.Max(-box.Height / 2f, box.Height / 2f),
                MathHelper.Max(-box.Depth / 2f, box.Depth / 2f)
            ) + body.WorldPosition;
            var min = new Vector3(
                MathHelper.Min(-box.Width / 2f, box.Width / 2f),
                MathHelper.Min(-box.Height / 2f, box.Height / 2f),
                MathHelper.Min(-box.Depth / 2f, box.Depth / 2f)
            ) + body.WorldPosition;

            var rotation = body.RotationMatrix;
            max = Vector3.Transform(max - body.WorldPosition, rotation) + body.WorldPosition;
            min = Vector3.Transform(min - body.WorldPosition, rotation) + body.WorldPosition;

            return new BoundingBox(min.MonoGameVector, max.MonoGameVector);
        }

        /// <summary>
        /// Generates a <see cref="Microsoft.Xna.Framework.BoundingSphere"/> for a <see cref="Komodo.Core.ECS.Components.RigidBodyComponent"/> with an attached <see cref="Komodo.Core.Physics.Sphere"/>.
        /// </summary>
        /// <param name="body">Body to create a <see cref="Microsoft.Xna.Framework.BoundingSphere"/> for.</param>
        /// <returns><see cref="Microsoft.Xna.Framework.BoundingSphere"/> representation of the <see cref="Komodo.Core.Physics.Sphere"/>.</returns>
        private static BoundingSphere GenerateBoundingSphere(RigidBodyComponent body)
        {
            var sphere = body.Shape as Sphere;

            return new BoundingSphere(body.WorldPosition.MonoGameVector, sphere.Radius);
        }

        /// <summary>
        /// Gets collision data between two <see cref="Microsoft.Xna.Framework.BoundingBox"/>es.
        /// </summary>
        /// <param name="box">First box to check.</param>
        /// <param name="otherBox">Second box to check.</param>
        /// <returns><see cref="Komodo.Core.Physics.Collision"/> information between the two boxes.</returns>
        private static Collision GetCollision(BoundingBox box, BoundingBox otherBox)
        {
            return AABBAABB(box, otherBox);
        }

        /// <summary>
        /// Gets collision data between a <see cref="Microsoft.Xna.Framework.BoundingBox"/> and a <see cref="Microsoft.Xna.Framework.BoundingSphere"/>.
        /// </summary>
        /// <param name="box">Box to check.</param>
        /// <param name="sphere">Sphere to check.</param>
        /// <returns><see cref="Komodo.Core.Physics.Collision"/> information between the box and sphere.</returns>
        private static Collision GetCollision(BoundingBox box, BoundingSphere sphere)
        {
            var collision = GetCollision(sphere, box);
            return new Collision(collision.IsColliding, -collision.Normal, collision.PenetrationDepth);
        }

        /// <summary>
        /// Gets collision data between two <see cref="Microsoft.Xna.Framework.BoundingSphere"/>s.
        /// </summary>
        /// <param name="sphere">First sphere to check.</param>
        /// <param name="otherSphere">Second sphere to check.</param>
        /// <returns><see cref="Komodo.Core.Physics.Collision"/> information between the two spheres.</returns>
        private static Collision GetCollision(BoundingSphere sphere, BoundingSphere otherSphere)
        {
            var containment = sphere.Contains(otherSphere);
            var normal = Vector3.Zero;
            float penetrationDepth = 0f;
            if (containment != ContainmentType.Disjoint)
            {
                var direction = new Vector3(otherSphere.Center - sphere.Center);
                float distance = direction.Length();
                normal = Vector3.Normalize(direction);
                float combinedRadius = sphere.Radius + otherSphere.Radius;
                penetrationDepth = combinedRadius - distance;
            }
            return new Collision(containment != ContainmentType.Disjoint, normal, penetrationDepth);
        }

        /// <summary>
        /// Gets collision data between a <see cref="Microsoft.Xna.Framework.BoundingSphere"/> and a <see cref="Microsoft.Xna.Framework.BoundingBox"/>.
        /// </summary>
        /// <param name="sphere">Sphere to check.</param>
        /// <param name="box">Box to check.</param>
        /// <returns><see cref="Komodo.Core.Physics.Collision"/> information between the sphere and box.</returns>
        private static Collision GetCollision(BoundingSphere sphere, BoundingBox box)
        {
            var containment = sphere.Contains(box);
            var normal = Vector3.Zero;
            float penetrationDepth = 0f;
            if (containment != ContainmentType.Disjoint)
            {
                var closestPoint = Microsoft.Xna.Framework.Vector3.Clamp(sphere.Center, box.Min, box.Max);
                var toClosest = new Vector3(sphere.Center - closestPoint);
                var closestPointDistance = toClosest.Length();
                if (closestPointDistance < sphere.Radius)
                {
                    penetrationDepth = sphere.Radius - closestPointDistance;
                    normal = Vector3.Normalize(toClosest);
                }
            }

            return new Collision(containment != ContainmentType.Disjoint, normal, penetrationDepth);
        }

        private static bool SAT(Vector3 axis, float minA, float maxA, float minB, float maxB, ref Vector3 mtvAxis, ref float mtvDistance)
        {
            // Separating Axis Theorem
            // =======================
            // - Two convex shapes only overlap if they overlap on all axes of separation
            // - In order to create accurate responses we need to find the collision vector (Minimum Translation Vector)   
            // - The collision vector is made from a vector and a scalar, 
            //   - The vector value is the axis associated with the smallest penetration
            //   - The scalar value is the smallest penetration value
            // - Find if the two boxes intersect along a single axis
            // - Compute the intersection interval for that axis
            // - Keep the smallest intersection/penetration value
            float axisLengthSquared = Vector3.Dot(axis, axis);

            // If the axis is degenerate then ignore
            if (axisLengthSquared < 1.0e-8f)
            {
                return true;
            }

            // Calculate the two possible overlap ranges
            // Either we overlap on the left or the right sides
            float d0 = (maxB - minA);   // 'Left' side
            float d1 = (maxA - minB);   // 'Right' side

            // Intervals do not overlap, so no intersection
            if (d0 <= 0.0f || d1 <= 0.0f)
            {
                return false;
            }

            // Find out if we overlap on the 'right' or 'left' of the object.
            float overlap = (d0 < d1) ? d0 : -d1;

            // The mtd vector for that axis
            Vector3 sep = axis * (overlap / axisLengthSquared);

            // The mtd vector length squared
            float sepLengthSquared = Vector3.Dot(sep, sep);

            // If that vector is smaller than our computed Minimum Translation Distance use that vector as our current MTV distance
            if (sepLengthSquared < mtvDistance)
            {
                mtvDistance = sepLengthSquared;
                mtvAxis = sep;
            }

            return true;
        }

        /// <summary>
        /// Updates a <see cref="Komodo.Core.ECS.Components.DynamicBodyComponent"/> for the given frame, considering relevant forces and velocities.
        /// </summary>
        /// <param name="body"><see cref="Komodo.Core.ECS.Components.DynamicBodyComponent"/> to update</param>
        /// <param name="gameTime">Time passed since last <see cref="Komodo.Core.Game.Update(GameTime)"/>.</param>
        private static void UpdateDynamicBodyComponent(DynamicBodyComponent body, GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            CalculateAngularVelocity(body, delta);
            CalculateLinearVelocity(body, delta);

            body.Parent.Position += body.LinearVelocity * delta;
            body.Parent.Rotation += body.AngularVelocity * delta;
        }

        /// <summary>
        /// Updates a <see cref="Komodo.Core.ECS.Components.KinematicBodyComponent"/> for the given frame, considering relevant movements.
        /// </summary>
        /// <param name="body"><see cref="Komodo.Core.ECS.Components.KinematicBodyComponent"/> to update</param>
        /// <param name="gameTime">Time passed since last <see cref="Komodo.Core.Game.Update(GameTime)"/>.</param>
        private static void UpdateKinematicBodyComponent(KinematicBodyComponent body, GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            body.Parent.Position += body.PositionDelta * delta;
        }
        #endregion Private Static Methods

        #endregion Static Methods
    }
}