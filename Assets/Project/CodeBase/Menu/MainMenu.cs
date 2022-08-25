using System;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Menu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private ButtonGroup _buttonSettings;

        private Game _game;

        [Inject]
        private void constructor(Game game)
        {
            _game = game;
        }

        private void Start()
        {
            _playButton.onClick.AddListener(enterPlayScene);
            _buttonSettings.Init();
        }

        private void enterPlayScene()
        {
            _game.StateMachine.Enter<LoadLevelState, string>(SceneName.GAMEPLAY);
        }
    }
}