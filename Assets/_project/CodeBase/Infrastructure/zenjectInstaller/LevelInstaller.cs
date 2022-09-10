using codeBase.game.level;
using codeBase.game.player;
using UnityEngine;
using Zenject;

namespace codeBase.infrastructure.zenjectInstaller
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private LevelRegister _levelRegister;
        [SerializeField] private Player _playerPrefab;

        public override void InstallBindings()
        {
            levelRegister();
            levelLoader();
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