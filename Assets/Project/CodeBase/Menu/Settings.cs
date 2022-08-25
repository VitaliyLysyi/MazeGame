using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace CodeBase.Menu
{
    public class Settings : MonoBehaviour
    {
        [SerializeField] private AudioMixer _mainMixer;
        [SerializeField] private AudioSettings _musicSettings;
        [SerializeField] private AudioSettings _soundSettings;
        [SerializeField] private Toggle _vibrationToggle;
        [SerializeField] private ButtonGroup _infoGroup;

        private void Start()
        {
            _vibrationToggle.onValueChanged.AddListener(Vibration);
            _infoGroup.Init();
            _musicSettings.Init(_mainMixer, "MusicVolume");
            _soundSettings.Init(_mainMixer, "SiundVolume");
        }

        private void Vibration(bool active) => Taptic.tapticOn = active;

        [Serializable]
        private class AudioSettings
        {
            public TextMeshProUGUI volumeValue;
            public Slider slider;
            public Image image;
            
            private AudioMixer _audioMixer;
            private string _mixerName;

            public const float minVolume = 0.000001f;
            public const float maxVolume = 1f;

            public void Init(AudioMixer audioMixer, string mixerName)
            {
                _audioMixer = audioMixer;
                _mixerName = mixerName;

                slider.maxValue = maxVolume;
                slider.minValue = minVolume;
                slider.normalizedValue = 1f;
                slider.onValueChanged.AddListener(updateValue);
            }

            private void updateValue(float value)
            {
                _audioMixer.SetFloat(_mixerName, Mathf.Log10(value) * 20);
                volumeValue.text = Mathf.Round((value/slider.maxValue) * 100).ToString();
            }
        }
    }
}