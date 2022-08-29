using UnityEngine;

namespace codeBase
{
    public class StartPoint : MonoBehaviour
    {
        [SerializeField] private DebugWindow _debugWindow;
        [SerializeField] private Player _player;
        [SerializeField] private Ball _mainBall;
        [SerializeField] private UIInput _input;

        private void Start()
        {
            _debugWindow.init(_input);
            _player.init(_input, _mainBall);
        }
    }
}