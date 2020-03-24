using Komodo.Core.ECS.Components;
using Komodo.Core.ECS.Entities;
using System;
using System.Collections.Generic;

using GameTime = Microsoft.Xna.Framework.GameTime;

namespace Komodo.Core.ECS.Systems
{
    /// <summary>
    /// Defines the interface for all <see cref="Komodo.Core.ECS.Systems"/> classes.
    /// </summary>
    public interface ISystem<T> where T : Component
    {
        #region Members

        #region Public Members
        /// <summary>
        /// All tracked <see cref="T"/> objects.
        /// </summary>
        List<T> Components { get; }
        
        /// <summary>
        /// All tracked <see cref="Komodo.Core.ECS.Entities.Entity"/> objects.
        /// </summary>
        Dictionary<Guid, Entity> Entities { get; set; }

        /// <summary>
        /// Reference to current <see cref="Komodo.Core.Game"/> instance.
        /// </summary>
        Game Game { get; }

        /// <summary>
        /// Whether or not the ISystem has called <see cref="Initialize()"/>.
        /// </summary>
        public bool IsInitialized { get; }
        #endregion Public Members

        #endregion Members

        #region Member Methods
        #region Public Member Methods
        /// <summary>
        /// Adds a <see cref="Komodo.Core.ECS.Entities.Entity"/> to the ISystem if the <see cref="Komodo.Core.ECS.Entities.Entity"/> is not already present.
        /// </summary>
        /// <param name="entityToAdd"><see cref="Komodo.Core.ECS.Entities.Entity"/> to add.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Entities.Entity"/> was added to this Drawable2DSystem's <see cref="Entites"/>. Returns false if the <see cref="Komodo.Core.ECS.Entities.Entity"/> already existed.</returns>
        bool AddEntity(Entity entityToAdd);

        /// <summary>
        /// Removes all <see cref="Komodo.Core.ECS.Entities.Entity"/> objects from the ISystem.
        /// </summary>
        public void ClearEntities();

        /// <summary>
        /// Should update the ISystem as well as all of it's <see cref="T"/> objects.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Runs any operations needed at the end of the <see cref="Komodo.Core.Game.Update(GameTime)"/> loop.
        /// </summary>
        /// <param name="gameTime">Time passed since last <see cref="Komodo.Core.Game.Update(GameTime)"/>.</param>
        void PostUpdate(GameTime gameTime);

        /// <summary>
        /// Runs any operations needed at the beginning of the <see cref="Komodo.Core.Game.Update(GameTime)"/> loop.
        /// </summary>
        /// <param name="gameTime">Time passed since last <see cref="Komodo.Core.Game.Update(GameTime)"/>.</param>
        void PreUpdate(GameTime gameTime);

        /// <summary>
        /// Removes a <see cref="Komodo.Core.ECS.Entities.Entity"/> from the ISystem, including all the <see cref="Komodo.Core.ECS.Entities.Entity"/>'s <see cref="T"/> objects.
        /// </summary>
        /// <param name="entityID">Unique identifier for the <see cref="Komodo.Core.ECS.Entities.Entity"/>.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Entities.Entity"/> was removed from this ISystem's <see cref="Entities"/>. Will return false if the <see cref="Komodo.Core.ECS.Entities.Entity"/> is not present in <see cref="Entities"/>.</returns>
        public bool RemoveEntity(Guid entityID);

        /// <summary>
        /// Removes a <see cref="Komodo.Core.ECS.Entities.Entity"/> from the ISystem, including all the <see cref="Komodo.Core.ECS.Entities.Entity"/>'s <see cref="Komodo.Core.ECS.Components.Component"/> objects.
        /// </summary>
        /// <param name="entityToRemove"><see cref="Komodo.Core.ECS.Entities.Entity"/> to remove.</param>
        /// <returns>Whether or not the <see cref="Komodo.Core.ECS.Entities.Entity"/> was removed from this ISystem's <see cref="Entities"/>. Will return false if the <see cref="Komodo.Core.ECS.Entities.Entity"/> is not present in <see cref="Entities"/>.</returns>
        public bool RemoveEntity(Entity entityToRemove);
        #endregion Public Member Methods

        #endregion Member Methods
    }
}