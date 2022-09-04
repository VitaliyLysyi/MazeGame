using System;
using UnityEngine;

namespace codeBase.game.level
{
    public class LevelLoader 
    {
        private LevelRegister _levelRegister;
        private Level _currentLevelLoaded;
        private int _currentLevelIndex;

        public event Action<Level> onLevelLoad;

        public LevelLoader(LevelRegister levelRegister)
        {
            _levelRegister = levelRegister;
        }

        public void tempStart(int index)
        {
            bool levelIndexInRange = index >= 0 && index < _levelRegister.count;
            _currentLevelIndex = levelIndexInRange ? index : 0;
            loadLevel(_currentLevelIndex);
        }

        private void loadLevel(int index)
        {
            Level level = _levelRegister.getLevel(index);

            if (level != null)
            {
                _currentLevelLoaded = GameObject.Instantiate(level);

                _currentLevelLoaded.onLevelCommplete += tempGoToNextLevel;

                onLevelLoad?.Invoke(_currentLevelLoaded);
            }
        }

        private void tempGoToNextLevel()
        {
            destroyCurrentLevel();

            _currentLevelIndex++;
            _currentLevelIndex = _currentLevelIndex < _levelRegister.count ? _currentLevelIndex : 0;
            loadLevel(_currentLevelIndex);
        }

        private void destroyCurrentLevel()
        {
            _currentLevelLoaded.onLevelCommplete -= tempGoToNextLevel;

            GameObject.Destroy(_currentLevelLoaded.gameObject);
        }
    }
}