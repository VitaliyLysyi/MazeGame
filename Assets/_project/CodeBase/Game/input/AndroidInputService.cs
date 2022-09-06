using System;
using codeBase.UI;
using UnityEngine.UI;
using Zenject;

namespace codeBase.game.input
{
    public class AndroidInputService : IGameInput
    {
        private Joystick _joystick;
        public event Action onMainButtonClick;

        public AndroidInputService(GameUI gameUI)
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