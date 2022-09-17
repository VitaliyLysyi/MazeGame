using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace codeBase.menu
{
    public class SummaryWindow : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _summaryText;
        [SerializeField] private Button _nextLevel;
        [SerializeField] private Button _restart;
        [SerializeField] private Button _toMenu;

        public event Action onRestartClick;
        public event Action onToMenuClick;
        public event Action onNextLevelClick;

        private void Start()
        {
            hide();

            _nextLevel.onClick.AddListener(onNextLevelClickInvoke);
            _restart.onClick.AddListener(onRestartClickInvoke);
            _toMenu.onClick.AddListener(onToMenuClickInvoke);
        }

        public void showWin()
        {
            gameObject.SetActive(true);
            _nextLevel.gameObject.SetActive(true);
            _summaryText.text = "LEVEL PASSED!";

        }

        public void showFailed()
        {
            gameObject.SetActive(true);
            _nextLevel.gameObject.SetActive(false);
            _summaryText.text = "LEVEL FAILED!";
        }

        private void onRestartClickInvoke()
        {
            hide();
            onRestartClick?.Invoke();
        }

        private void onNextLevelClickInvoke()
        {
            hide();
            onNextLevelClick?.Invoke();
        }

        private void onToMenuClickInvoke()
        {
            //hide();
            onToMenuClick?.Invoke();
        }

        private void hide() => gameObject.SetActive(false);
    }
}