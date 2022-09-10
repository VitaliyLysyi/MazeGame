using System;
using UnityEngine;
using UnityEngine.UI;

namespace codeBase.game.input
{
    public class AndroidInputService : MonoBehaviour, IGameInput
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Button _mainButton;

        public event Action onMainButtonClick;

        private void Start()
        {
            _mainButton.onClick.AddListener(onClickInvoke);
        }

        private void onClickInvoke() => onMainButtonClick?.Invoke();

        public float horizontalAxis() => _joystick.Horizontal;

        public float verticalAxis() => _joystick.Vertical;
    }
}