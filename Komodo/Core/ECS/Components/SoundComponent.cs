using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Komodo.Core.ECS.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace Komodo.Core.ECS.Components
{
    public class SoundComponent : Component, ISerializable<SoundComponent>
    {
        #region Constructors
        public SoundComponent(string soundPath) : base(true, null)
        {
            Sound = KomodoGame.Content.Load<SoundEffect>(soundPath);
            _instances = new List<SoundEffectInstance>();
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public SoundEffect Sound { get; }
        #endregion Public Members

        #region Protected Members
        protected List<SoundEffectInstance> _instances { get; set;  }
        #endregion Protected Members

        #region Private Members
        #endregion Private Members

        #endregion Members

        #region Member Methods

        #region Public Member Methods
        public override void Deserialize(SerializedObject serializedObject)
        {
        }

        sealed public override void Draw(SpriteBatch spriteBatch)
        {
        }

        public override SerializedObject Serialize()
        {
            var serializedObject = new SerializedObject();

            return serializedObject;
        }

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
            var instances = _instances.ToList();
            foreach (var instance in instances)
            {
                Stop(instance);
            }
            _instances.Clear();
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
            foreach (var instance in _instances)
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
                _instances.Add(instance);
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
                _instances.Remove(soundToStop);
                soundToStop.Dispose();
            }
        }

        public void StopAll()
        {
            var instances = _instances.ToList();
            foreach (var instance in instances)
            {
                Stop(instance);
            }
        }

        sealed public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            var instances = _instances.ToList();
            foreach (var instance in _instances)
            {
                if (instance.State != SoundState.Stopped)
                {
                    instances.Add(instance);
                }
            }

            _instances = instances;
        }
        #endregion Public Member Methods

        #region Protected Member Methods
        protected bool IsValidInstance(SoundEffectInstance instance)
        {
            return instance != null && !instance.IsDisposed && _instances.Contains(instance);
        }
        #endregion Protected Member Methods

        #region Private Member Methods
        #endregion Private Member Methods

        #endregion Member Methods
    }
}