using System;
using codeBase.game.ball;
using UnityEngine;

namespace codeBase.game.level
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Ball _mainBall;

        public event Action onLevelCommplete;

        public Ball mainBall => _mainBall;

        private void OnTriggerExit(Collider other)
        {
            onLevelCommplete?.Invoke();
        }
    }
}