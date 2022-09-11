using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace codeBase.menu
{
    public class VibrationButton : MonoBehaviour
    {
        [SerializeField] private Button _vibrationButton;
        [SerializeField] private Image _vibrationImage;
        [SerializeField] private Image _iconBackground;
        [SerializeField] private Image _icon;
        [SerializeField] private Transform _activetTransform;
        [SerializeField] private Transform _deactiveTransform;
        [SerializeField] private Sprite _activeIcon;
        [SerializeField] private Sprite _deactiveIcon;
        [SerializeField] private Sprite _activeBackground;
        [SerializeField] private Sprite _deactiveBeckground;

        private bool _isVibrationActive = true;
        
        public event Action<bool> isVibrationActive;

        public void init(bool isVibrationActive)
        {
            _isVibrationActive = isVibrationActive;
        }

        private void Start()
        {
            _vibrationButton.onClick.AddListener(changeVibrationState);
            vibrationState(_isVibrationActive);
        }

        private void changeVibrationState()
        {
            _isVibrationActive = !_isVibrationActive;

            vibrationState(_isVibrationActive, 0.5f);
            
            isVibrationActive?.Invoke(_isVibrationActive);
        }

        private void vibrationState(bool isActive, float duration = 0)
        {
            _vibrationImage.DOFade(isActive ? 1f : 0.3f, duration);
            _iconBackground.transform.DOMove(isActive ? _activetTransform.position : _deactiveTransform.position, duration).OnComplete(() => {
                _icon.sprite = isActive ? _activeIcon : _deactiveIcon;
                _iconBackground.sprite = isActive ? _activeBackground : _deactiveBeckground;
            });
        }
    }
}
