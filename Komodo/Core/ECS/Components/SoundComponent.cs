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
            _instances = new List<SoundEffectInstance>();
            SoundPath = soundPath;
        }
        #endregion Constructors

        #region Destructor
        /// <summary>
        /// Stops all <see cref="Microsoft.Xna.Framework.Audio.SoundEffectInstance"/> objects found in <see cref="Instances"/>.
        /// </summary>
        ~SoundComponent()
        {
            StopAll();
        }
        #endregion Destructor

        #region Members

        #region Public Members
        /// <summary>
        /// Collection of current and valid <see cref="Microsoft.Xna.Framework.Audio.SoundEffectInstance"/> objects.
        /// </summary>
        public List<SoundEffectInstance> Instances => _instances;
        
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
        internal List<SoundEffectInstance> _instances { get; set;  }
        #endregion Internal Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        /// <summary>
        /// Changes the intensity of a valid sound instance found in <see cref="Instances"/>.
        /// </summary>
        /// <param name="sound">Specific instance that will have its volume intensity modified.</param>
        /// <param name="volume">Value, clamped between 0 and 1, representing the volume intensity.</param>
        public void ChangeVolume(SoundEffectInstance sound, float volume)
        {
            if (IsValidInstance(sound))
            {
                if (volume < 0f)
                {
                    volume = 0f;
                }
                else if (volume > 1f)
                {
                    volume = 1f;
                }
                sound.Volume = volume;
            }
        }

        /// <summary>
        /// Clears all <see cref="Microsoft.Xna.Framework.Audio.SoundEffectInstance"/> objects found in <see cref="Instances"/>, stopping all of them immediately.
        /// </summary>
        public void Clear()
        {
            var instances = Instances.ToList();
            foreach (var instance in instances)
            {
                Stop(instance);
            }
            Instances.Clear();
        }

        /// <summary>
        /// Checks whether or not a <see cref="Microsoft.Xna.Framework.Audio.SoundEffectInstance"/> is not null, not disposed, and is present in <see cref="Instances"/>.
        /// </summary>
        /// <param name="instance"></param>
        /// <returns>Whether or not the <see cref="Microsoft.Xna.Framework.Audio.SoundEffectInstance"/> is valid.</returns>
        public bool IsValidInstance(SoundEffectInstance instance)
        {
            return instance != null && !instance.IsDisposed && Instances.Contains(instance);
        }

        /// <summary>
        /// Pauses the given <see cref="Microsoft.Xna.Framework.Audio.SoundEffectInstance"/> if the instance is present on the SoundComponent.
        /// </summary>
        /// <param name="soundToPause">Specific instance to pause.</param>
        public void Pause(SoundEffectInstance soundToPause)
        {
            if (IsValidInstance(soundToPause))
            {
                soundToPause.Pause();
            }
        }

        /// <summary>
        /// Pauses all <see cref="Microsoft.Xna.Framework.Audio.SoundEffectInstance"/> objects found in <see cref="Instances"/>.
        /// </summary>
        public void PauseAll()
        {
            foreach (var instance in Instances)
            {
                Pause(instance);
            }
        }

        /// <summary>
        /// Creates a <see cref="Microsoft.Xna.Framework.Audio.SoundEffectInstance"/> from <see cref="Sound"/>.
        /// </summary>
        /// <param name="loop">The <see cref="Microsoft.Xna.Framework.Audio.SoundEffectInstance"/> will continue to repeat until paused or stopped.</param>
        /// <param name="shouldLayerSound"></param>
        /// <returns>A <see cref="Microsoft.Xna.Framework.Audio.SoundEffectInstance"/> handle for pausing, resuming, and stopping.</returns>
        public SoundEffectInstance Play(bool loop = false, bool shouldLayerSound = true)
        {
            if (Sound != null)
            {
                var instance = Sound.CreateInstance();
                instance.IsLooped = loop;
                if (!shouldLayerSound)
                {
                    Clear();
                }
                Instances.Add(instance);
                instance.Play();

                return instance;
            }
            return null;
        }

        /// <summary>
        /// Resumes a paused <see cref="Microsoft.Xna.Framework.Audio.SoundEffectInstance"/>.
        /// </summary>
        /// <param name="soundToResume"><see cref="Microsoft.Xna.Framework.Audio.SoundEffectInstance"/> to resume playing.</param>
        public void Resume(SoundEffectInstance soundToResume)
        {
            if (IsValidInstance(soundToResume) && soundToResume.State == SoundState.Paused)
            {
                soundToResume.Resume();
            }
        }

        /// <summary>
        /// Stops a <see cref="Microsoft.Xna.Framework.Audio.SoundEffectInstance"/>. Stopping a sound will remove the <see cref="Microsoft.Xna.Framework.Audio.SoundEffectInstance"/> from <see cref="Instances"/>.
        /// </summary>
        /// <param name="soundToStop"><see cref="Microsoft.Xna.Framework.Audio.SoundEffectInstance"/> to stop.</param>
        public void Stop(SoundEffectInstance soundToStop)
        {
            if (IsValidInstance(soundToStop))
            {
                soundToStop.Stop();
                Instances.Remove(soundToStop);
                soundToStop.Dispose();
            }
        }

        /// <summary>
        /// Stops all <see cref="Microsoft.Xna.Framework.Audio.SoundEffectInstance"/> objects found in <see cref="Instances"/>.
        /// </summary>
        public void StopAll()
        {
            var instances = Instances.ToList();
            foreach (var instance in instances)
            {
                Stop(instance);
            }
        }
        #endregion Public Member Methods

        #endregion Member Methods
    }
}