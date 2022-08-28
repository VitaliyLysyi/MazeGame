using System;
using codeBase.infrastructure;
using codeBase.infrastructure.constants;
using codeBase.infrastructure.SaveLoadSystem;
using codeBase.infrastructure.structures;
using UnityEngine;
using UnityEngine.UI;

namespace codeBase.Menu
{
    public partial class SettingsMenu : MonoBehaviour
    {
        [SerializeField] private AudioButtonsGroup _musicGroup;
        [SerializeField] private AudioButtonsGroup _soundGroup;
        [SerializeField] private Toggle _vibrationToggle;
        [SerializeField] private WindowGroup _infoGroup;

        private GameSettings _gameSettings;

        private void Start()
        {
            _gameSettings = Game.instance.settings;

            initAudioButtons();
            initVibrationToggle();
            _infoGroup.init();
        }

        private void OnDestroy()
        {
            _gameSettings.saveData();
            _musicGroup.changeValue -= changeAudioVolume;
            _soundGroup.changeValue -= changeAudioVolume;
            _vibrationToggle.onValueChanged.RemoveAllListeners();
        }

        private void initVibrationToggle()
        {
            _vibrationToggle.isOn = _gameSettings.getVibration();
            _vibrationToggle.onValueChanged.AddListener(Vibration);
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

        private void Vibration(bool active) => _gameSettings.setVibrationOn(active);
    }
}