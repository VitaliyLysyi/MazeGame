using System;
using UnityEngine;
using UnityEngine.UI;

namespace codeBase.game.input
{
    public class AndroidInputService : MonoBehaviour, IGameInput
    {
        [SerializeField] private Joystick _allAxisJoystick;
        [SerializeField] private Joystick _horizontalAxisJoystick;
        [SerializeField] private Button _mainButton;

        private Joystick _joystick;

        public event Action onMainButtonClick;

        private void Start()
        {
            setJoystickToAllAxis();
            _mainButton.onClick.AddListener(onClickInvoke);
        }

        private void onClickInvoke() => onMainButtonClick?.Invoke();

        public float horizontalAxis()
        {
            setJoystickToHorizontalAxis();
            return _joystick.Horizontal;
        }

        public float verticalAxis()
        {
            setJoystickToAllAxis();
            return _joystick.Vertical;
        }

        public Vector2 axisVector()
        {
            setJoystickToAllAxis();
            return new Vector2(_joystick.Horizontal, _joystick.Vertical);
        }

        private void setJoystickToAllAxis()
        {
            _joystick?.gameObject.SetActive(false);
            _joystick = _allAxisJoystick;
            _joystick.gameObject.SetActive(true);
        }

        private void setJoystickToHorizontalAxis()
        {
            _joystick?.gameObject.SetActive(false);
            _joystick = _horizontalAxisJoystick;
            _joystick.gameObject.SetActive(true);
        }
    }
}