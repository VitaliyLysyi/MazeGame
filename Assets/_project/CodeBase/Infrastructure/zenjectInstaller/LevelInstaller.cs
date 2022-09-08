using codeBase.game.input;
using codeBase.game.level;
using codeBase.game.player;
using codeBase.UI;
using UnityEngine;
using Zenject;

namespace codeBase.infrastructure.zenjectInstaller
{
    public class LevelInstaller : MonoInstaller
    {
#if UNITY_EDITOR
        [Header("---------------------------------------------")]
        [SerializeField] private bool _debugInputMode;
        [SerializeField] private DebugInput _debugInputPrefab;
        [Header("---------------------------------------------")]
#endif
        [SerializeField] private LevelRegister _levelRegister;
        [SerializeField] private InGameUI _inGameUI;
        [SerializeField] private Player _playerPrefab;

        public override void InstallBindings()
        {
            levelRegister();
            levelLoader();
            inGameUI();
            gameInput();
            player();
        }

        private void levelRegister()
        {
            Container
                .Bind<LevelRegister>()
                .FromInstance(_levelRegister)
                .AsSingle()
                .NonLazy();
        }

        private void levelLoader()
        {
            Container
                .Bind<LevelLoader>()
                .AsSingle()
                .NonLazy();
        }

        private void inGameUI()
        {
            Container
                .Bind<InGameUI>()
                .FromInstance(_inGameUI)
                .AsSingle()
                .NonLazy();
        }

        private void gameInput()
        {
            IGameInput input;
#if UNITY_EDITOR
            if (_debugInputMode)
            {
                input = Container.InstantiatePrefabForComponent<IGameInput>(_debugInputPrefab);
            }
            else
            {
                input = new AndroidInputService(_inGameUI);
            }
#else
            input = new AndroidInputService(_inGameUI);
#endif
            Container
                .Bind<IGameInput>()
                .FromInstance(input)
                .AsSingle()
                .NonLazy();
        }

        private void player()
        {
            Player player = Container.InstantiatePrefabForComponent<Player>(_playerPrefab);

            Container
                .Bind<Player>()
                .FromInstance(player)
                .AsSingle()
                .NonLazy();
        }
    }
}