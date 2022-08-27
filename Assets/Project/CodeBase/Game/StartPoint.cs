using UnityEngine;

namespace CodeBase
{
    public class StartPoint : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Ball _ball;
        [SerializeField] private Joystick _joystick;

        private void Start()
        {
            _player.init(_joystick, _ball);
        }
    }
}