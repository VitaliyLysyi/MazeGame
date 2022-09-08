using System;
using System.Collections;
using codeBase.UI;
using TMPro;
using UnityEngine;

namespace codeBase
{
    public class Timer : MonoBehaviour
    {
        private const float UPDATE_TIME = 1f;

        private IEnumerator _timerRunCoroutine;
        private TextMeshProUGUI _timerText;
        private InGameUI _inGameUI;
        private float _secondsLeft;

        public event Action onTimeHasPassed;

        private void construct(InGameUI inGameUI)
        {
            _inGameUI = inGameUI;
        }

        private void Start()
        {
            _timerText = _inGameUI.getTimerText;
            _timerRunCoroutine = timerRunCoroutine();
        }

        private IEnumerator timerRunCoroutine()
        {
            while (_secondsLeft > 0)
            {
                yield return new WaitForSeconds(UPDATE_TIME);
                _secondsLeft = _secondsLeft - UPDATE_TIME;
                updateTimerText();
            }
            onTimeHasPassed?.Invoke();
        }

        private void updateTimerText() => _timerText.text = _secondsLeft.ToString();

        public void run() => StartCoroutine(_timerRunCoroutine);

        public void reset(float seconds)
        {
            StopCoroutine(_timerRunCoroutine);
            _secondsLeft = seconds;
        }
    }
}
