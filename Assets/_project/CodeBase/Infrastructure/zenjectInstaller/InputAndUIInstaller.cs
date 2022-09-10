using codeBase.game.input;
using UnityEngine;
using Zenject;

namespace codeBase.infrastructure.zenjectInstaller
{
    public class InputAndUIInstaller : MonoInstaller
    {
#if UNITY_EDITOR
        [Header("---------------------------------------------")]
        [SerializeField] private bool _debugInputMode;
        [SerializeField] private DebugInput _debugInputPrefab;
        [Header("---------------------------------------------")]
#endif
        [SerializeField] private Canvas _canvas;
        [SerializeField] private AndroidInputService _androidInputPrefab;
        [SerializeField] private Timer _timerPrefab;
        [SerializeField] private ScoreCounter _scoreCounterPrefab;

        public override void InstallBindings()
        {
#if UNITY_EDITOR
            editorInput();
#else
            input();
#endif

            timer();
            scoreCounter();
        }

#if UNITY_EDITOR
        private void editorInput()
        {
            IGameInput input;
            if (_debugInputMode)
            {
                input = Container.InstantiatePrefabForComponent<IGameInput>(_debugInputPrefab, _canvas.transform);
            }
            else
            {
                input = Container.InstantiatePrefabForComponent<IGameInput>(_androidInputPrefab, _canvas.transform);
            }

            Container
                .Bind<IGameInput>()
                .FromInstance(input)
                .AsSingle()
                .NonLazy();
        }
#endif

        private void input()
        {
            IGameInput input = Container.InstantiatePrefabForComponent<IGameInput>(_androidInputPrefab, _canvas.transform);

            Container
                .Bind<IGameInput>()
                .FromInstance(input)
                .AsSingle()
                .NonLazy();
        }

        private void timer()
        {
            Timer timer = Container.InstantiatePrefabForComponent<Timer>(_timerPrefab, _canvas.transform);

            Container
                .Bind<Timer>()
                .FromInstance(timer)
                .AsSingle()
                .NonLazy();
        }

        private void scoreCounter()
        {
            ScoreCounter timer = Container.InstantiatePrefabForComponent<ScoreCounter>(_scoreCounterPrefab, _canvas.transform);

            Container
                .Bind<ScoreCounter>()
                .FromInstance(timer)
                .AsSingle()
                .NonLazy();
        }
    }
}