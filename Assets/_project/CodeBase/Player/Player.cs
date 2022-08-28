using UnityEngine;

namespace codeBase
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private bool _debugInput;

        private IMovable _currentMovable;
        private Joystick _joystick;
        private Ball _mainBall;

        public void init(Joystick joystick, Ball ball)
        {
            _joystick = joystick;
            _mainBall = ball;
            setNewMovable(_mainBall);
        }

        private void Update()
        {
            moveCharacter();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                setNewMovable(_mainBall);
            }
        }

        private void moveCharacter()
        {
            float horixontalAxis;
            float verticalAxis;

            if (_debugInput)
            {
                horixontalAxis = Input.GetAxis("Horizontal");
                verticalAxis = Input.GetAxis("Vertical");
            }
            else
            {
                horixontalAxis = _joystick.Horizontal;
                verticalAxis = _joystick.Vertical;
            }
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
        private void beginInteraction(IInteractable interactable)
        {
            interactable.interact(this);
        }
    }
}