using System.Collections.Generic;
using UnityEngine;

namespace codeBase.game.level
{
    [CreateAssetMenu(fileName = "LevelRegister", menuName = "Game Data/LevelRegister")]
    public class LevelRegister : ScriptableObject
    {
        [SerializeField] private List<Level> _levelPrefabs;

        public Level getLevel(int index) => _levelPrefabs[index];

        public int count => _levelPrefabs.Count;
    }
}
