using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace codeBase
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timerText;

        private const float UPDATE_TIME = 1f;

        private IEnumerator _timerRunCoroutine;
        private float _secondsLeft;

        public event Action onTimeIsUp;

        private void Start()
        {
            _timerRunCoroutine = timerRunCoroutine();
        }

        private IEnumerator timerRunCoroutine()
        {
            while (_secondsLeft > 0)
            {
                yield return new WaitForSeconds(UPDATE_TIME);
                _secondsLeft -= UPDATE_TIME;
                updateTimerText();
            }
            onTimeIsUp?.Invoke();
        }

        private void updateTimerText() => _timerText.text = _secondsLeft.ToString();

        public void run() => StartCoroutine(_timerRunCoroutine);

        public void reset(float seconds)
        {
            StopCoroutine(_timerRunCoroutine);
            _secondsLeft = seconds;
            updateTimerText();
        }
    }
}