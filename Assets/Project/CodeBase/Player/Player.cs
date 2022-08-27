using UnityEngine;

namespace CodeBase
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private MazeSegment _mazeSegment;

        private Joystick _joystick;
        private Ball _mainBall;
        private IMovable _currentMovable;

        public void init(Joystick joystick, Ball ball)
        {
            _joystick = joystick;
            _mainBall = ball;
            //_currentMovable = _mazeSegment;
            _currentMovable = _mainBall;
        }

        private void Update()
        {
            moveCharacter();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _currentMovable = _mainBall;
            }
        }

        private void moveCharacter()
        {
            //float horixontalAxis = _joystick.Horizontal;
            //float verticalAxis = _joystick.Vertical;
            float horixontalAxis = Input.GetAxis("Horizontal");
            float verticalAxis = Input.GetAxis("Vertical");
            _currentMovable.move(horixontalAxis, verticalAxis);
        }
    }
}