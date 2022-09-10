using codeBase.game.level;
using codeBase.game.player;
using UnityEngine;
using Zenject;

namespace codeBase.infrastructure
{
    public class GameObserver : MonoBehaviour
    {
        [SerializeField] private int _startLevel = 0;

        private LevelLoader _levelLoader;
        private Level _currentLevelLoaded;
        private Player _player;
        private Timer _timer;
        private ScoreCounter _scoreCounter;

        [Inject]
        private void construct(LevelLoader levelLoader, Player player, Timer timer, ScoreCounter scoreCounter)
        {
            _levelLoader = levelLoader;
            _player = player;
            _timer = timer;
            _scoreCounter = scoreCounter;
        }

        private void Start()
        {
            _levelLoader.onLevelLoaded += reset;
            _timer.onTimeIsUp += onLevelFailed;

            startAtLevel(_startLevel);
        }

        public void startAtLevel(int index)
        {
            _levelLoader.loadLevel(index);
        }

        private void reset(Level level)
        {
            _player.reset(level.mainBall);

            _timer.reset(level.secondsForComplete);
            _timer.run();

            _scoreCounter.reset();

            if (_currentLevelLoaded != null)
            {
                _currentLevelLoaded.onLevelCommplete -= onLevelComplete;
            }
            _currentLevelLoaded = level;
            _currentLevelLoaded.onLevelCommplete += onLevelComplete;
        }

        private void onLevelComplete()
        {
            _levelLoader.nextLevel();
        }

        private void onLevelFailed()
        {
            Debug.Log("Level Failed");
        }
    }
}