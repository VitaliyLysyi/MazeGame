using System;

namespace codeBase.game.input
{
    public interface IGameInput
    {
        public event Action onMainButtonClick;
        public float horizontalAxis();
        public float verticalAxis();
    }
}