using TMPro;
using UnityEngine;

namespace codeBase
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        private int _currentScore;

        public void increase()
        {
            _currentScore++;
            updateText();
        }

        public void reset()
        {
            _currentScore = 0;
            updateText();
        }

        private void updateText() => _scoreText.text = _currentScore.ToString();
    }
}