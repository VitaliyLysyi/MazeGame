using System;
using codeBase.infrastructure;
using codeBase.infrastructure.constants;
using codeBase.infrastructure.SaveLoadSystem;
using codeBase.infrastructure.structures;
using UnityEngine;
using UnityEngine.UI;

namespace codeBase.menu
{
    public partial class SettingsMenu : MonoBehaviour
    {
        [SerializeField] private AudioButtonsGroup _musicGroup;
        [SerializeField] private AudioButtonsGroup _soundGroup;
        [SerializeField] private VibrationButton _vibration;
        [SerializeField] private LanguageButton _languageButton;
        [SerializeField] private WindowGroup _infoGroup;

        private GameSettings _gameSettings;

        private void Start()
        {
            _gameSettings = Game.instance.settings;

            initAudioButtons();
            initVibrationToggle();
            _infoGroup.init();
            _languageButton.init(_gameSettings.getLanguage());
            _languageButton.onLanguageChanged += _gameSettings.setLanguage;
        }

        private void OnDestroy()
        {
            _gameSettings.saveData();
            _musicGroup.changeValue -= changeAudioVolume;
            _soundGroup.changeValue -= changeAudioVolume;
            _vibration.isVibrationActive -= vibration;
            _languageButton.onLanguageChanged -= _gameSettings.setLanguage;
        }

        private void initVibrationToggle()
        {
            _vibration.init(_gameSettings.getVibration());
            _vibration.isVibrationActive += vibration;
        }

        private void initAudioButtons()
        {
            float musicVolum = _gameSettings.getMixerVolume(Constants.AUDIO_MUSIC);
            float soundVolum = _gameSettings.getMixerVolume(Constants.AUDIO_SOUND);

            _musicGroup.init(Constants.AUDIO_MUSIC, musicVolum);
            _soundGroup.init(Constants.AUDIO_SOUND, soundVolum);

            _musicGroup.changeValue += changeAudioVolume;
            _soundGroup.changeValue += changeAudioVolume;
        }

        private void changeAudioVolume(string mixerName, float value) => _gameSettings.setMixerVolume(mixerName, value);

        private void vibration(bool active) => _gameSettings.setVibrationOn(active);
    }
}