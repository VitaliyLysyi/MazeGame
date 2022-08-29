using System.Collections;
using codeBase.extansionMethods;
using codeBase.infrastructure.constants;
using codeBase.infrastructure.Coroutines;
using codeBase.infrastructure.SaveLoadSystem;
using codeBase.infrastructure.structures;
using UnityEngine.Audio;
using UnityEngine.Localization.Settings;

namespace codeBase.infrastructure
{
    public class GameSettings
    {
        private AudioMixer _audioMixer;
        private SettingsData _settings;
        private ICoroutineRunner _coroutineRunner;

        public GameSettings(AudioMixer audioMixer, ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
            _audioMixer = audioMixer;
            _settings = initSettingsData();
        }

        private SettingsData initSettingsData()
        {
            SettingsData settings = new SettingsData();

            if (!DataHandler.Load(ref settings))
            {
                settings.soundVolume = 1f;
                settings.musicVolume = 1f;
                settings.audioVolume = 1f;
                settings.vibrationOn = true;
                settings.language = LanguageType.ENGLISH;
            }

            return settings;
        }

        public void enableSettings()
        {
            setVibrationOn(_settings.vibrationOn);
            setLanguage(_settings.language);
            setMixerVolume(Constants.AUDIO_SOUND, _settings.soundVolume);
            setMixerVolume(Constants.AUDIO_MUSIC, _settings.musicVolume);
            setMixerVolume(Constants.AUDIO_MAIN, _settings.audioVolume);
        }

        public float getMixerVolume(string mixerName) => _settings.getAudioMixerVolume(mixerName);

        public bool getVibration() => _settings.vibrationOn;

        public LanguageType getLanguage() => _settings.language;

        public void setMixerVolume(string mixerName, float value)
        {
            _audioMixer.SetFloat(mixerName, value.toAudioValue01());
            _settings.setAudioMixerVolume(mixerName, value);
        }

        public void setVibrationOn(bool value)
        {
            _settings.vibrationOn = value;
            Taptic.tapticOn = value;
        }

        public void setLanguage(LanguageType language)
        {
            _settings.language = language;
            _coroutineRunner.StartCoroutine(changeLanguige(language));
        }

        public void saveData() => DataHandler.Save(_settings);

        private IEnumerator changeLanguige(LanguageType languageType)
        {
            yield return LocalizationSettings.InitializationOperation;
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[((int)languageType)];
        }


    }
}