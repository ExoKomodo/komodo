using System;
using System.Collections.Generic;
using System.Linq;

using SoundEffect = Microsoft.Xna.Framework.Audio.SoundEffect;
using SoundEffectInstance = Microsoft.Xna.Framework.Audio.SoundEffectInstance;
using SoundState = Microsoft.Xna.Framework.Audio.SoundState;

namespace Komodo.Core.ECS.Components
{
    /// <summary>
    /// Represents a single <see cref="Microsoft.Xna.Framework.Audio.SoundEffect"/> and all of the associated <see cref="Microsoft.Xna.Framework.Audio.SoundEffect"/>
    /// </summary>
    public class SoundComponent : Component
    {
        #region Constructors
        /// <summary>
        /// Creates a SoundComponent with a filepath to a compiled <see cref="Microsoft.Xna.Framework.Audio.SoundEffect"/> content file.
        /// </summary>
        /// <remarks>
        /// The <see cref="Microsoft.Xna.Framework.Audio.SoundEffect"/> will be loaded from disk once the relevant <see cref="Komodo.Core.ECS.Systems.SoundSystem.Initialize"/>, <see cref="Komodo.Core.ECS.Systems.SoundSystem.PreUpdate"/>, or <see cref="Komodo.Core.ECS.Systems.SoundSystem.PostUpdate"/> is called.
        /// </remarks>
        /// <param name="soundPath">File path to a compiled <see cref="Microsoft.Xna.Framework.Audio.SoundEffect"/> content file.</param>
        public SoundComponent(string soundPath) : base(true, null)
        {
            _instances = new Dictionary<Guid, SoundEffectInstance>();
            SoundPath = soundPath;
        }
        #endregion Constructors

        #region Destructor
        /// <summary>
        /// Stops all sound instance found in <see cref="_instances"/>.
        /// </summary>
        ~SoundComponent()
        {
            StopAll();
        }
        #endregion Destructor

        #region Members

        #region Public Members
        /// <summary>
        /// Raw sound data loaded from disk.
        /// </summary>
        public SoundEffect Sound { get; set;  }
        
        /// <summary>
        /// Path of the <see cref="Microsoft.Xna.Framework.Audio.SoundEffect"/> if the SoundComponent was provided a model filepath via <see cref="SoundComponent.SoundComponent(string)"/>.
        /// </summary>
        public string SoundPath { get; }
        #endregion Public Members

        #region Internal Members
        internal Dictionary<Guid, SoundEffectInstance> _instances { get; set;  }
        #endregion Internal Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        /// <summary>
        /// Changes the intensity of a valid sound instance found in <see cref="_instances"/>.
        /// </summary>
        /// <param name="id">Identifier for the instance that will have its volume intensity modified.</param>
        /// <param name="volume">Value, clamped between 0 and 1, representing the volume intensity.</param>
        public void ChangeVolume(Guid id, float volume)
        {
            if (IsValidInstance(id))
            {
                var instance = _instances[id];
                if (volume < 0f)
                {
                    volume = 0f;
                }
                else if (volume > 1f)
                {
                    volume = 1f;
                }
                instance.Volume = volume;
            }
        }

        /// <summary>
        /// Clears all sound instances, stopping all of them immediately.
        /// </summary>
        public void Clear()
        {
            foreach (var id in _instances.Keys)
            {
                Stop(id);
            }
            _instances.Clear();
        }

        /// <summary>
        /// Checks whether or not a sound instance exists and is not disposed.
        /// </summary>
        /// <param name="id">Identifier of the instance to check.</param>
        /// <returns>Whether or not the id represents a valid sound instance.</returns>
        public bool IsValidInstance(Guid id)
        {
            bool instanceExists = _instances.TryGetValue(id, out SoundEffectInstance instance);
            return instanceExists && !instance.IsDisposed;
        }

        /// <summary>
        /// Pauses the given sound if the instance is present on the SoundComponent.
        /// </summary>
        /// <param name="id">Identifier for the specific instance to pause.</param>
        public void Pause(Guid id)
        {
            if (IsValidInstance(id))
            {
                var instance = _instances[id];
                instance.Pause();
            }
        }

        /// <summary>
        /// Pauses all sound instances found in <see cref="_instances"/>.
        /// </summary>
        public void PauseAll()
        {
            foreach (var id in _instances.Keys)
            {
                Pause(id);
            }
        }

        /// <summary>
        /// Creates a sound instance from <see cref="Sound"/>.
        /// </summary>
        /// <param name="loop">The sound instance will continue to repeat until paused or stopped.</param>
        /// <param name="shouldLayerSound"></param>
        /// <returns>A sound instance ID for pausing, resuming, and stopping.</returns>
        public Guid Play(bool loop = false, bool shouldLayerSound = true)
        {
            var id = Guid.Empty;
            if (Sound != null)
            {
                var instance = Sound.CreateInstance();
                instance.IsLooped = loop;
                if (!shouldLayerSound)
                {
                    Clear();
                }
                id = Guid.NewGuid();
                _instances[id] = instance;
                instance.Play();
            }
            return id;
        }

        /// <summary>
        /// Resumes a paused sound instance.
        /// </summary>
        /// <param name="id">Sound instance to resume playing.</param>
        public void Resume(Guid id)
        {
            if (IsValidInstance(id))
            {
                var instance = _instances[id];
                if (instance.State == SoundState.Paused)
                {
                    instance.Resume();
                }
            }
        }

        /// <summary>
        /// Stops a sound instance. Stopping a sound will remove the instance from <see cref="_instances"/>.
        /// </summary>
        /// <param name="id">Identifier for sound to stop.</param>
        public void Stop(Guid id)
        {
            if (IsValidInstance(id))
            {
                var instance = _instances[id];
                instance.Stop();
                _instances.Remove(id);
                instance.Dispose();
            }
        }

        /// <summary>
        /// Stops all sound instances found in <see cref="_instances"/>.
        /// </summary>
        public void StopAll()
        {
            foreach (var id in _instances.Keys)
            {
                Stop(id);
            }
        }
        #endregion Public Member Methods

        #endregion Member Methods
    }
}