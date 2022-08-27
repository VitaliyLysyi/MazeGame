using CodeBase.Infrastructure.Coroutines;
using CodeBase.Infrastructure.States;
using CodeBase.Logic;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Preloader
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
            _game.StateMachine.Enter<PreloaderState>();
            StartFromPreloader.isStartFromPreloader = true;
        }
    }
}