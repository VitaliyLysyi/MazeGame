using System;

namespace codeBase
{
    public interface IGameInput
    {
        public event Action onMainButtonClick;
        public float horizontalAxis();
        public float verticalAxis();
    }
}