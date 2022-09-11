using System;
using UnityEngine;
using UnityEngine.UI;

namespace codeBase
{
    public class AudioButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _image;
        [SerializeField] private Sprite _audioOnIcon;
        [SerializeField] private Sprite _audioOffIcon;

        private bool _isAudioOn;

        public event Action<bool> audioOn;

        public void init(float audioVolume)
        {
            _isAudioOn = audioVolume > 0.5f;

            updataImageSprite();
            _button.onClick.AddListener(onClick);
        }

        private void updataImageSprite() => _image.sprite = _isAudioOn ? _audioOnIcon : _audioOffIcon;

        private void onClick()
        {
            _isAudioOn = !_isAudioOn;
            updataImageSprite();
            audioOn?.Invoke(_isAudioOn);
        }
    }
}