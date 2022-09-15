using System;
using codeBase.game.ball;
using UnityEngine;

namespace codeBase.game.level
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Ball _mainBall;
        [SerializeField] private float _secondsForGold;
        [SerializeField] private float _secondsForSilver;
        [SerializeField] private float _secondsForBronze;

        public event Action onLevelCommplete;
        public event Action onLevelFailed;

        public Ball mainBall => _mainBall;

        public float secondsForGold => _secondsForGold;

        public float secondsForSilver => _secondsForSilver;

        public float secondsForBronze => _secondsForBronze;

        private void OnTriggerExit(Collider other)
        {
            onLevelCommplete?.Invoke();
        }
    }
}