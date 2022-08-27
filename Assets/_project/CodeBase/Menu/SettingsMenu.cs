using System;
using CodeBase.Infrastructure.SaveLoadSystem;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Zenject;
using static UnityEngine.Rendering.DebugUI;

namespace CodeBase.Menu
{
    public partial class SettingsMenu : MonoBehaviour
    {
        [SerializeField] private AudioMixer _mainMixer;
        [SerializeField] private AudioSettings _musicSettings;
        [SerializeField] private AudioSettings _soundSettings;
        [SerializeField] private Toggle _vibrationToggle;
        [SerializeField] private ButtonGroup _infoGroup;

        private SettingsData _settingsData;

        [Inject]
        private void Constructor(SettingsData settingsData)
        {
            _settingsData = settingsData;
        }

        private void Start()
        {
            _vibrationToggle.onValueChanged.AddListener(Vibration);
            _infoGroup.Init();
            _musicSettings.Init(_mainMixer, "MusicVolume");
            _soundSettings.Init(_mainMixer, "SiundVolume");

            updateSettings(_settingsData);
        }

        private void OnEnable()
        {
            _musicSettings.changeValue += updateMusicValue;
            _soundSettings.changeValue += updateSoundValue;
        }


        private void OnDisable()
        {
            _musicSettings.changeValue -= updateMusicValue;
            _soundSettings.changeValue -= updateSoundValue;
        }

        private void updateSettings(SettingsData settingsData)
        {
            _vibrationToggle.isOn = settingsData.vibration;
            _musicSettings.SetVolume(settingsData.musicVolume);
            _soundSettings.SetVolume(settingsData.soundVolume);
        }


        private void Vibration(bool active)
        {
            Taptic.tapticOn = active;
            _settingsData.vibration = active;
            saveSettings();
        }

        private void updateSoundValue(float value)
        {
            _settingsData.soundVolume = value;
            saveSettings();
        }

        private void updateMusicValue(float value)
        {
            _settingsData.musicVolume = value;
            saveSettings();
        }

        private void saveSettings() => DataHolder.Save(_settingsData);
    }
}