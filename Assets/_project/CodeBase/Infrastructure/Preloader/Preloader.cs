using codeBase.infrastructure.Coroutines;
using codeBase.infrastructure.States;
using codeBase.Logic;
using UnityEngine;
using Zenject;

namespace codeBase.infrastructure.Preloader
{
    public class Preloader : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;

        [Inject]
        public void Constructor(Game game)
        {
            _game = game;
        }

        private void Start()
        {
            _game.settings.enableSettings();
            _game.stateMachine.Enter<PreloaderState>();
            StartFromPreloader.isStartFromPreloader = true;
        }
    }
}