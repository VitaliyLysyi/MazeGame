using UnityEngine;

namespace CodeBase
{
    public class Player : MonoBehaviour
    {
        private Joystick _joystick;
        private Ball _ball;

        public void init(Joystick joystick, Ball ball)
        {
            _joystick = joystick;
            _ball = ball;
        }

        private void Update()
        {
            //ballControll();
            tempBallControll();
        }

        private void tempBallControll()
        {
            float AxisX = Input.GetAxis("Horizontal");
            float AxisZ = Input.GetAxis("Vertical");
            Vector3 direction = new Vector3(AxisX, 0f, AxisZ);
            _ball.move(direction);
        }

        private void ballControll()
        {
            float AxisX = _joystick.Horizontal;
            float AxisZ = _joystick.Vertical;
            Vector3 direction = new Vector3(AxisX, 0f, AxisZ);
            _ball.move(direction);
        }
    }
}