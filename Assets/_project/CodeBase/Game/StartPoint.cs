using UnityEngine;

namespace codeBase
{
    public class StartPoint : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Ball _mainBall;
        [SerializeField] private Joystick _joystick;

        private void Start()
        {
            _player.init(_joystick, _mainBall);
        }
    }
}