using System;
using UnityEngine;

namespace codeBase.game.input
{
    public interface IGameInput
    {
        public event Action onMainButtonClick;
        public Vector2 axisVector();
        public float horizontalAxis();
        public float verticalAxis();
    }
}