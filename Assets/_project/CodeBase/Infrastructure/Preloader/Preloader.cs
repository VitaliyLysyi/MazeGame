﻿using codeBase.infrastructure.States;
using UnityEngine;
using Zenject;

namespace codeBase.infrastructure.Preloader
{
    public class Preloader : MonoBehaviour
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