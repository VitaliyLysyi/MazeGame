using System;
using codeBase.game.ball;
using codeBase.game.input;
using UnityEngine;
using Zenject;

namespace codeBase.game.player
{
    public class Player : MonoBehaviour
    {
        private IPlayerControlable _currentControlable;
        private IGameInput _gameInput;
        private Ball _mainBall;

        public event Action onScorePick;
        public event Action onBallDestroyed;

        [Inject]
        private void constructor(IGameInput gameInput)
        {
            _gameInput = gameInput;
        }

        private void Start()
        {
            _gameInput.onMainButtonClick += setControllableToMainBall;
        }

        private void Update()
        {
            controllCharacter();
        }

        private void controllCharacter()
        {
            if (_currentControlable == null)
            {
                return;
            }

            float horixontalAxis = _gameInput.horizontalAxis();
            float verticalAxis = _gameInput.verticalAxis();
            _currentControlable.control(horixontalAxis, verticalAxis);
        }

        public void setNewControlable(IPlayerControlable controlable)
        {
            if (controlable == _currentControlable)
            {
                return;
            }

            _currentControlable?.endControl(this);
            _currentControlable = controlable;
            _currentControlable?.beginControl(this);
        }

        public void reset(Ball mainBall)
        {
            _mainBall = mainBall;
            setControllableToMainBall();
        }

        public void scorePick() => onScorePick?.Invoke();

        public void ballDestroyed() => onBallDestroyed?.Invoke();

        private void setControllableToMainBall() => setNewControlable(_mainBall);
    }
}