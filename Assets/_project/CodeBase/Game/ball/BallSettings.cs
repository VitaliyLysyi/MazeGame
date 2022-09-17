using UnityEngine;

namespace codeBase.game.ball
{
    [CreateAssetMenu(fileName = "BallSettings", menuName = "Game Data/BallSettings")]
    public class BallSettings : ScriptableObject
    {
        [SerializeField, Range(100f, 1000f)] private float _controlSensitivity = 1f;

        public float controlSensitivity => _controlSensitivity;
    }
}
