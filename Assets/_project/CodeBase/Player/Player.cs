using UnityEngine;

namespace codeBase
{
    public class Player : MonoBehaviour
    {
        private IControlable _currentControlable;
        private IGameInput _gameInput;
        private Ball _mainBall;

        public void init(IGameInput gameInput, Ball ball)
        {
            _mainBall = ball;
            setNewControlable(_mainBall);
            _gameInput = gameInput;
            _gameInput.onMainButtonClick += () => setNewControlable(_mainBall);
        }

        private void Update()
        {
            if (_currentControlable != null)
            {
                controllCharacter();
            }
        }

        private void controllCharacter()
        {
            float horixontalAxis = _gameInput.horizontalAxis();
            float verticalAxis = _gameInput.verticalAxis();
            _currentControlable.control(horixontalAxis, verticalAxis);
        }

        public void setNewControlable(IControlable controlable)
        {
            if (controlable == _currentControlable)
            {
                return;
            }

            _currentControlable?.endControl(this);
            _currentControlable = controlable;
            _currentControlable.beginControl(this);
        }

        public void beginInteraction(IInteractable interactable) => interactable.interact(this);
    }
}