using System;
using codeBase.game.ball;
using UnityEngine;

namespace codeBase.game.level
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Ball _mainBall;
        [SerializeField] private float _secondsForComplete;

        public event Action onLevelCommplete;

        public Ball mainBall => _mainBall;

        public float secondsForComplete => _secondsForComplete;

        private void OnTriggerExit(Collider other)
        {
            onLevelCommplete?.Invoke();
        }
    }
}