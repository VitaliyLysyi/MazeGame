using UnityEngine;

namespace codeBase
{
    public class StartPoint : MonoBehaviour
    {
        [SerializeField] private GameUI _gameUI;
        [SerializeField] private Player _player;
        [SerializeField] private Ball _mainBall;
        [SerializeField] private DebugInput _debugInput;
        [SerializeField] private bool _debugInputMode;

        private void Start()
        {
            IGameInput gameInput = _debugInputMode ? _debugInput : new AndroidInput(_gameUI);
            _player.init(gameInput, _mainBall);
        }
    }
}