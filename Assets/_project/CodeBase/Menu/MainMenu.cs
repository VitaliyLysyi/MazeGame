using codeBase.infrastructure;
using codeBase.infrastructure.constants;
using codeBase.infrastructure.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace codeBase.Menu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private WindowGroup _buttonSettings;

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
        }

        private void enterPlayScene()
        {
            _game.stateMachine.Enter<LoadLevelState, string>(Constants.SCENE_GAMEPLAY);
        }
    }
}