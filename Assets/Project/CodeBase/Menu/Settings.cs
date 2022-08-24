using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace CodeBase.Menu
{
    public class Settings : MonoBehaviour
    {
        [SerializeField] private AudioSettings _musicSettings;
        [SerializeField] private AudioSettings _soundSettings;
        [SerializeField] private Toggle _vibrationToggle;
        [SerializeField] private AudioMixer _mainMixer;

        private void Start()
        {

        }


        [Serializable]
        private struct AudioSettings
        {
            public TextMeshProUGUI volumeValue;
            public Slider slider;
            public Image image;
        }
    }
}