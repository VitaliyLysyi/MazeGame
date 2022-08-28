using System;
using codeBase.infrastructure;
using codeBase.infrastructure.Coroutines;
using codeBase.infrastructure.SaveLoadSystem;
using codeBase.Logic;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace codeBase.infrastructure.zenjectInstaller
{
    public class PreloadInstaller : MonoInstaller
    {
        [SerializeField] private LoadingCurtain _loadingCurtain;
        [SerializeField] private AudioMixer _audioMixer;

        private CoroutineRunner _coroutineRunner;
        private LoadingCurtain _curtain;

        public override void InstallBindings()
        {
            initCoroutinRuner();
            initCurtain();

            audioMixer();
            loadingCurtain();
            coroutinneRunner();
            gameSettings();
            game();
        }



        private void initCurtain()
        {
            _curtain = Instantiate(_loadingCurtain);
            DontDestroyOnLoad(_curtain.gameObject);
        }

        private void initCoroutinRuner()
        {
            GameObject coroutineRunner = Instantiate(new GameObject());
            coroutineRunner.name = "CoroutinRunner";

            _coroutineRunner = coroutineRunner.AddComponent<CoroutineRunner>();

            DontDestroyOnLoad(coroutineRunner);
        }

        private void game()
        {
            Container
                .Bind<Game>()
                .AsSingle();
        }

        private void coroutinneRunner()
        {
            Container
                .Bind<ICoroutineRunner>()
                .FromInstance(_coroutineRunner)
                .AsSingle()
                .NonLazy();
        }

        private void loadingCurtain()
        {
            Container
                .Bind<LoadingCurtain>()
                .FromInstance(_curtain)
                .AsSingle();
        }

        private void gameSettings()
        {
            Container
                .Bind<GameSettings>()
                .AsSingle()
                .NonLazy();
        }

        private void audioMixer()
        {
            Container
                .Bind<AudioMixer>()
                .FromInstance(_audioMixer)
                .AsSingle()
                .NonLazy();
        }

    }
}