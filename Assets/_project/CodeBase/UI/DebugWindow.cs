using UnityEngine;
using UnityEngine.UI;

namespace codeBase
{
    public class DebugWindow : MonoBehaviour
    {
        [SerializeField] private Button _openButton;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Toggle _debugInputToggle;

        private GameInput _input;

        public void init(GameInput input)
        {
            gameObject.SetActive(false);
            _openButton.onClick.AddListener(() => gameObject.SetActive(true));
            _closeButton.onClick.AddListener(() => gameObject.SetActive(false));

            _input = input;
            _debugInputToggle.onValueChanged.AddListener(_input.switchDebugMode);
        }
    }
}