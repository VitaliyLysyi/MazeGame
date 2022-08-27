using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace CodeBase.Menu
{
    [Serializable]
    public class AudioSettings
    {
        public TextMeshProUGUI volumeValue;
        public Slider slider;
        public Image image;

        private AudioMixer _audioMixer;
        private string _mixerName;

        public const float minVolume = 0.000001f;
        public const float maxVolume = 1f;

        public event Action<float> changeValue;

        public void Init(AudioMixer audioMixer, string mixerName)
        {
            _audioMixer = audioMixer;
            _mixerName = mixerName;

            slider.maxValue = maxVolume;
            slider.minValue = minVolume;
            slider.normalizedValue = 1f;
            slider.onValueChanged.AddListener(updateValue);
        }

        public void SetVolume(float value) => slider.value = value;

        private void updateValue(float value)
        {
            _audioMixer.SetFloat(_mixerName, Mathf.Log10(value) * 20);
            volumeValue.text = Mathf.Round((value / slider.maxValue) * 100).ToString();
            
            changeValue?.Invoke((float)Math.Round(value, 2));
        }
    }
}