using System;
using UnityEngine;
using UnityEngine.UI;

namespace codeBase
{
    public class GameInput : MonoBehaviour
    {
        private GameUI _gameUI;
        private Joystick _joystick;
        private bool _debugMode = false;

        public event Action onButtonClick;

        public void init(GameUI gameUI)
        {
            _gameUI = gameUI;
            _joystick = _gameUI.getJoystick;
            Button mainButton = _gameUI.getMainButton;
            mainButton.onClick.AddListener(onClickInvoke);
        }

        private void Update()
        {
            if (_debugMode)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    onButtonClick?.Invoke();
                }
            }
        }

        private void onClickInvoke() => onButtonClick?.Invoke();

        public float horizontal => _debugMode ? Input.GetAxis("Horizontal") : _joystick.Horizontal;

        public float vertical => _debugMode ? Input.GetAxis("Vertical") : _joystick.Vertical;

        public void switchDebugMode(bool value) => _debugMode = value;
    }
}