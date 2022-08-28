using codeBase.infrastructure;
using UnityEngine;
using UnityEngine.UIElements;

namespace codeBase
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private bool _debugInput;

        private IMovable _currentMovable;
        private UIInput _input;
        private Ball _mainBall;

        public void init(UIInput input, Ball ball)
        {
            _input = input;
            _mainBall = ball;
            _input.onButtonClick += () => setNewMovable(_mainBall);
            setNewMovable(_mainBall);
        }

        private void Update()
        {
            moveCharacter();
        }

        private void moveCharacter()
        {
            float horixontalAxis = _input.horizontal;
            float verticalAxis = _input.vertical;
            _currentMovable.move(horixontalAxis, verticalAxis);
        }

        public void setNewMovable(IMovable movable)
        {
            if (movable == _currentMovable)
            {
                return;
            }

            if (_currentMovable is Ball)
            {
                Ball ball = _currentMovable as Ball;
                ball.onBeginInteract -= beginInteraction;
            }

            _currentMovable = movable;
            if (_currentMovable is Ball)
            {
                Ball ball = _currentMovable as Ball;
                ball.onBeginInteract += beginInteraction;
            }
        }
        private void beginInteraction(IInteractable interactable) => interactable.interact(this);
    }
}