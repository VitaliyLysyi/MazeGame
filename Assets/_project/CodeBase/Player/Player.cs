using UnityEngine;

namespace codeBase
{
    public class Player : MonoBehaviour
    {
        private IControlable _currentControlable;
        private GameInput _input;
        private Ball _mainBall;

        public void init(GameInput input, Ball ball)
        {
            _input = input;
            _mainBall = ball;
            setNewControlable(_mainBall);
            _input.onButtonClick += () => setNewControlable(_mainBall);
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
            float horixontalAxis = _input.horizontal;
            float verticalAxis = _input.vertical;
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