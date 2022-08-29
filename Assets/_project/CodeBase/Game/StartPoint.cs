using UnityEngine;

namespace codeBase
{
    public class StartPoint : MonoBehaviour
    {
        [SerializeField] private DebugWindow _debugWindow;
        [SerializeField] private GameUI _gameUI;
        [SerializeField] private GameInput _gameInput;
        [SerializeField] private Player _player;
        [SerializeField] private Ball _mainBall;

        private void Start()
        {
            _gameInput.init(_gameUI);
            _debugWindow.init(_gameInput);
            _player.init(_gameInput, _mainBall);
        }
    }
}