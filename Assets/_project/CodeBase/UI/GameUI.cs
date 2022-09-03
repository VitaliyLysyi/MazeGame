using UnityEngine;
using UnityEngine.UI;

namespace codeBase.UI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Button _mainButton;
        [SerializeField] private Text _scoreText;
        [SerializeField] private Text _timer;

        public Joystick getJoystick => _joystick;
        public Button getMainButton => _mainButton;
    }
}