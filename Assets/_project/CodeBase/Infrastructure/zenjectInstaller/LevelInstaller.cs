using codeBase.game.ball;
using codeBase.game.input;
using codeBase.game.level;
using codeBase.game.player;
using codeBase.UI;
using UnityEngine;
using Zenject;
using AndroidInput = codeBase.game.input.AndroidInput;

namespace codeBase.infrastructure.zenjectInstaller
{
    public class LevelInstaller : MonoInstaller
    {
#if UNITY_EDITOR
        [SerializeField] private bool _debugInputMode;
        [SerializeField] private DebugInput _debugInputPrefab;
#endif
        [SerializeField] private LevelRegister _levelRegister;
        [SerializeField] private GameUI _gameUI;
        [SerializeField] private Player _playerPrefab;

        [SerializeField] private Ball _mainBall;

        private IGameInput _gameInput;
        private Player _player;

        public override void InstallBindings()
        {
            initGameInput();
            initPlayer();

            gameUI();
            levelRegister();
            gameInput();
            player();

            Debug.Log("LevelInstaller: input - " + _gameInput);
        }

        private void initPlayer()
        {
            //GameObject player = Instantiate(new GameObject());
            //player.name = "Player";
            //_player = player.AddComponent<Player>();

            _player = Instantiate(_playerPrefab);

            //_player.init(_gameInput, _mainBall);
        }

        private void initGameInput()
        {
#if UNITY_EDITOR
            if (_debugInputMode)
            {
                DebugInput debugInput = Instantiate(_debugInputPrefab);
                _gameInput = debugInput;
                return;
            }
#endif
            _gameInput = new AndroidInput();
        }

        private void gameUI()
        {
            Container
                .Bind<GameUI>()
                .FromInstance(_gameUI)
                .AsSingle();
        }

        private void levelRegister()
        {
            Container
                .Bind<LevelRegister>()
                .FromInstance(_levelRegister)
                .AsSingle();
        }

        private void gameInput()
        {
            Container
                .Bind<IGameInput>()
                .FromInstance(_gameInput)
                .AsSingle();
        }

        private void player()
        {
            Container
                .Bind<Player>()
                .FromInstance(_player)
                .AsSingle();
        }
    }
}