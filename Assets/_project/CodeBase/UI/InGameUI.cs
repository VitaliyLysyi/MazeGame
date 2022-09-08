using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace codeBase.UI
{
    public class InGameUI : MonoBehaviour
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Button _mainButton;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _timerText;

        public Joystick getJoystick => _joystick;
        public Button getMainButton => _mainButton;
        public TextMeshProUGUI getScoreText => _scoreText;
        public TextMeshProUGUI getTimerText => _timerText;
    }
}