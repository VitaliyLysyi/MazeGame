using System;
using codeBase.infrastructure;
using codeBase.infrastructure.constants;
using codeBase.infrastructure.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace codeBase.menu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private WindowGroup _buttonSettings;
        [SerializeField] private AudioButton _audioButton;

        private Game _game;

        [Inject]
        private void constructor(Game game)
        {
            _game = game;
        }

        private void Start()
        {
            _playButton.onClick.AddListener(enterPlayScene);
            _buttonSettings.init();
            _audioButton.init(_game.settings.getMixerVolume(Constants.AUDIO_MAIN));
        }

        private void OnEnable() => _audioButton.audioOn += audioOn;

        private void OnDisable() => _audioButton.audioOn -= audioOn;
        
        private void audioOn(bool audioOn)
        {
            float value = audioOn ? 1f : 0.000001f;
            _game.settings.setMixerVolume(Constants.AUDIO_MAIN, value);
            _game.settings.saveData();
        }

        private void enterPlayScene()
        {
            _game.stateMachine.Enter<LoadLevelState, string>(Constants.SCENE_GAMEPLAY);
        }
    }
}