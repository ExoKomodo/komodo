using System.Collections.Generic;
using System.Linq;

using GameTime = Microsoft.Xna.Framework.GameTime;

using SoundEffect = Microsoft.Xna.Framework.Audio.SoundEffect;
using SoundEffectInstance = Microsoft.Xna.Framework.Audio.SoundEffectInstance;
using SoundState = Microsoft.Xna.Framework.Audio.SoundState;

namespace Komodo.Core.ECS.Components
{
    public class SoundComponent : Component
    {
        #region Constructors
        public SoundComponent(string soundPath) : base(true, null)
        {
            Instances = new List<SoundEffectInstance>();
            SoundPath = soundPath;
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public SoundEffect Sound { get; set;  }
        public string SoundPath { get; }
        #endregion Public Members

        #region Internal Members
        internal List<SoundEffectInstance> Instances { get; set;  }
        #endregion Internal Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
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

        public void Clear()
        {
            var instances = Instances.ToList();
            foreach (var instance in instances)
            {
                Stop(instance);
            }
            Instances.Clear();
        }

        public void Pause(SoundEffectInstance soundToPause)
        {
            if (IsValidInstance(soundToPause))
            {
                soundToPause.Pause();
            }
        }

        public void PauseAll()
        {
            foreach (var instance in Instances)
            {
                Pause(instance);
            }
        }

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

        public void Resume(SoundEffectInstance soundToResume)
        {
            if (IsValidInstance(soundToResume) && soundToResume.State == SoundState.Paused)
            {
                soundToResume.Resume();
            }
        }

        public void Stop(SoundEffectInstance soundToStop)
        {
            if (IsValidInstance(soundToStop))
            {
                soundToStop.Stop();
                Instances.Remove(soundToStop);
                soundToStop.Dispose();
            }
        }

        public void StopAll()
        {
            var instances = Instances.ToList();
            foreach (var instance in instances)
            {
                Stop(instance);
            }
        }
        #endregion Public Member Methods

        #region Protected Member Methods
        protected bool IsValidInstance(SoundEffectInstance instance)
        {
            return instance != null && !instance.IsDisposed && Instances.Contains(instance);
        }
        #endregion Protected Member Methods

        #region Private Member Methods
        #endregion Private Member Methods

        #endregion Member Methods
    }
}