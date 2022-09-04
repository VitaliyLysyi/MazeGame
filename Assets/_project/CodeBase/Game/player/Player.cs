using codeBase.game.ball;
using codeBase.game.input;
using codeBase.game.level;
using codeBase.game.linkedPlatform;
using UnityEngine;
using Zenject;

namespace codeBase.game.player
{
    public class Player : MonoBehaviour
    {
        private LevelLoader _levelLoader;
        private IControlable _currentControlable;
        private IGameInput _gameInput;
        private Ball _mainBall;

        [Inject]
        private void constructor(IGameInput gameInput, LevelLoader levelLoader)
        {
            _gameInput = gameInput;
            _levelLoader = levelLoader;
        }

        private void Start()
        {
            _levelLoader.onLevelLoad += resetMainBall;
            _gameInput.onMainButtonClick += setControllableToMainBall;
        }

        private void Update()
        {
            if (_currentControlable != null)
            {
                controllCharacter();
            }
        }

        private void controllCharacter()
        {
            float horixontalAxis = _gameInput.horizontalAxis();
            float verticalAxis = _gameInput.verticalAxis();
            _currentControlable.control(horixontalAxis, verticalAxis);
        }

        private void resetMainBall(Level level)
        {
            _mainBall = level.mainBall;
            setNewControlable(_mainBall);
        }

        private void setControllableToMainBall() => setNewControlable(_mainBall);

        public void setNewControlable(IControlable controlable)
        {
            if (controlable == _currentControlable)
            {
                return;
            }

            _currentControlable?.endControl(this);
            _currentControlable = controlable;
            _currentControlable.beginControl(this);
        }

        public void beginInteraction(IInteractable interactable) => interactable.interact(this);
    }
}