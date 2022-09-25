using System;
using UnityEngine;

namespace codeBase.game.input
{
    public class DebugInput : MonoBehaviour, IGameInput
    {
        public event Action onMainButtonClick;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                onMainButtonClick?.Invoke();
            }
        }

        public float horizontalAxis() => Input.GetAxis("Horizontal");

        public float verticalAxis() => Input.GetAxis("Vertical");

        public Vector2 axisVector() => new Vector2(verticalAxis(), horizontalAxis());
    }
}