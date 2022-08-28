using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

namespace codeBase.Menu
{
    [Serializable]
    public class AudioButtonsGroup
    {
        private const float MIN_VOLUME = 0.000001f;
        private const float MAX_VOLUME = 1f;
        
        public TextMeshProUGUI volumeValue;
        public Slider slider;
        public Image image;

        private string _mixerName;

        public event Action<string, float> changeValue;
        
        public void init(string mixerName, float currentSliderValue)
        {
            _mixerName = mixerName;
            initSlider(currentSliderValue);
        }

        private void initSlider(float currentSliderValue)
        {
            slider.maxValue = MAX_VOLUME;
            slider.minValue = MIN_VOLUME;
            slider.normalizedValue = currentSliderValue;
            slider.onValueChanged.AddListener(updateValue);
        }

        private void updateValue(float value)
        {
            volumeValue.text = Mathf.Round((value / slider.maxValue) * 100).ToString();
            
            changeValue?.Invoke(_mixerName ,value);
        }
    }
}