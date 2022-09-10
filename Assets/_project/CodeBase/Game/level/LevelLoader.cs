using System;
using UnityEngine;

namespace codeBase.game.level
{
    public class LevelLoader 
    {
        private LevelRegister _levelRegister;
        private Level _currentLevelLoaded;
        private int _currentLevelIndex;

        public event Action<Level> onLevelLoaded;

        public LevelLoader(LevelRegister levelRegister)
        {
            _levelRegister = levelRegister;
        }

        public void loadLevel(int index)
        {
            Level level = _levelRegister.getLevel(index);
            if (level != null)
            {
                destroyCurrentLevel();
                _currentLevelLoaded = GameObject.Instantiate(level);
                onLevelLoaded?.Invoke(_currentLevelLoaded);
            }
        }

        private void destroyCurrentLevel()
        {
            if (_currentLevelLoaded == null)
            {
                return;
            }

            GameObject.Destroy(_currentLevelLoaded.gameObject);
        }

        public void nextLevel()
        {
            _currentLevelIndex++;
            _currentLevelIndex = _currentLevelIndex < _levelRegister.count ? _currentLevelIndex : 0;
            loadLevel(_currentLevelIndex);
        }

        public Level currentLevelLoaded => _currentLevelLoaded;
    }
}