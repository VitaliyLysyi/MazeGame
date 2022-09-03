using UnityEngine;

namespace codeBase.game.maze
{
    [CreateAssetMenu(fileName = "MazeRingSettings", menuName = "Game Data/MazeRingSettings")]
    public class MazeRingSettings : ScriptableObject
    {
        [SerializeField, Range(1f, 100f)] private float _rotationSpeed = 30f;

        public float rotationSpeed => _rotationSpeed;
    }
}
