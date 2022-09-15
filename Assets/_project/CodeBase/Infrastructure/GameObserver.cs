using codeBase.game.level;
using codeBase.game.player;
using codeBase.menu;
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
        private SummaryWindow _summaryWindow;

        [Inject]
        private void construct(
            LevelLoader levelLoader, 
            Player player, 
            Timer timer, 
            ScoreCounter scoreCounter, 
            SummaryWindow summary)
        {
            _levelLoader = levelLoader;
            _player = player;
            _timer = timer;
            _scoreCounter = scoreCounter;
            _summaryWindow = summary;
        }

        private void Start()
        {
            _levelLoader.onLevelLoaded += resetAll;

            _summaryWindow.onNextLevelClick += nextLevel;
            _summaryWindow.onRestartClick += restartLevel;
            _summaryWindow.onToMenuClick += toMenu;

            startFromLevel(_startLevel);
        }

        public void startFromLevel(int index)
        {
            _levelLoader.loadLevel(index);
        }

        private void resetAll(Level level)
        {
            _player.reset(level.mainBall);

            _timer.reset();
            _timer.run();

            _scoreCounter.reset();

            if (_currentLevelLoaded != null)
            {
                _currentLevelLoaded.onLevelCommplete -= onLevelComplete;
                _currentLevelLoaded.onLevelFailed -= onLevelFailed;
            }
            _currentLevelLoaded = level;
            _currentLevelLoaded.onLevelCommplete += onLevelComplete;
            _currentLevelLoaded.onLevelFailed += onLevelFailed;
        }

        private void onLevelComplete() => _summaryWindow.showWin();

        private void onLevelFailed() => _summaryWindow.showFailed();

        private void restartLevel() => _levelLoader.reload();

        private void nextLevel() => _levelLoader.nextLevel();

        private void toMenu() => Debug.LogWarning("Return to Menu need realization!");
    }
}