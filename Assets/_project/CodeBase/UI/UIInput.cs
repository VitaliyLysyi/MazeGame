using System;
using UnityEngine;
using UnityEngine.UI;

namespace codeBase
{
    public class UIInput : MonoBehaviour
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Button _button;

        private bool _debugMode = false;

        public event Action onButtonClick;

        private void Start()
        {
            _button.onClick.AddListener(onClickInvoke);
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