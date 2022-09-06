using codeBase.game.level;
using UnityEngine;
using Zenject;

namespace codeBase
{
    public class TempStart : MonoBehaviour
    {
        [SerializeField] private int _startLevel;
        private LevelLoader _levelLoader;

        [Inject]
        private void construct(LevelLoader levelLoader)
        {
            _levelLoader = levelLoader;
        }

        private void Start()
        {
            _levelLoader.tempStart(_startLevel);
        }
    }
}