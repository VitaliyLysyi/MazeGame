using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace codeBase.menu
{
    [Serializable]
    public class AudioButtonsGroup
    {
        private const float MIN_VOLUME = 0.000001f;
        private const float MAX_VOLUME = 1f;

        public Slider slider;
        public Image image;
        public List<ImageDictionary> imageDictionary;

        private string _mixerName;

        public event Action<string, float> changeValue;
        
        public void init(string mixerName, float currentSliderValue)
        {
            imageDictionary.Sort();
            _mixerName = mixerName;
            initSlider(currentSliderValue);
        }

        private void initSlider(float currentSliderValue)
        {
            slider.maxValue = MAX_VOLUME;
            slider.minValue = MIN_VOLUME;
            slider.normalizedValue = currentSliderValue;
            slider.onValueChanged.AddListener(updateValue);
            updataImage(slider.normalizedValue);
        }

        private void updateValue(float value)
        {
            updataImage(slider.normalizedValue);
            changeValue?.Invoke(_mixerName ,value);
        }

        private void updataImage(float normalizedValue)
        {
            foreach (ImageDictionary dictionary in imageDictionary)
            {
                if(dictionary.normalizedValue <= normalizedValue)
                {
                    image.sprite = dictionary.sprite;
                }
            }
        }

        [Serializable]
        public struct ImageDictionary : IComparable<ImageDictionary>
        {
            [HorizontalGroup("Group 1", LabelWidth = 100)]
            public Sprite sprite;
            [HorizontalGroup("Group 1")]
            public float normalizedValue;

            public int CompareTo(ImageDictionary other)
            {
                if (this.normalizedValue > other.normalizedValue)
                    return 1;
                else if (this.normalizedValue < other.normalizedValue)
                    return -1;
                else
                    return 0;
            }
        }
    }
}