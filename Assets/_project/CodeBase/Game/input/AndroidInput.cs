using System;
using codeBase.UI;
using UnityEngine.UI;
using Zenject;

namespace codeBase.game.input
{
    public class AndroidInput : IGameInput
    {
        private Joystick _joystick;
        public event Action onMainButtonClick;

        //public AndroidInput(GameUI gameUI)
        //{
        //    _joystick = gameUI.getJoystick;
        //    Button mainButton = gameUI.getMainButton;
        //    mainButton.onClick.AddListener(onClickInvoke);
        //}

        [Inject]
        private void constructor(GameUI gameUI)
        {
            _joystick = gameUI.getJoystick;
            Button mainButton = gameUI.getMainButton;
            mainButton.onClick.AddListener(onClickInvoke);
        }

        private void onClickInvoke() => onMainButtonClick?.Invoke();

        public float horizontalAxis() => _joystick.Horizontal;

        public float verticalAxis() => _joystick.Vertical;
    }
}