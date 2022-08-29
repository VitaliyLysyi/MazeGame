using System;
using System.Diagnostics;
using codeBase.infrastructure.constants;
using UnityEngine;

namespace codeBase.infrastructure.structures
{
    [Serializable]
    public struct SettingsData
    {
        public float audioVolume;
        public float soundVolume;
        public float musicVolume;
        public bool vibrationOn;
        public LanguageType language;

        public float getAudioMixerVolume(string mixerName)
        {
            switch (mixerName)
            {
                case Constants.AUDIO_SOUND: return soundVolume;
                case Constants.AUDIO_MUSIC: return musicVolume;
                case Constants.AUDIO_MAIN: return audioVolume;
                default: 
                    UnityEngine.Debug.LogError("Not correct Audio Constant"); 
                    return 0f;
            }
        }

        public void setAudioMixerVolume(string mixerName, float value)
        {
            switch (mixerName)
            {
                case Constants.AUDIO_SOUND: soundVolume = value; break;
                case Constants.AUDIO_MUSIC: musicVolume = value; break;
                case Constants.AUDIO_MAIN: audioVolume = value; break;
                default: UnityEngine.Debug.LogError("Not correct Audio Constant"); break;
            }
        }

    }
}