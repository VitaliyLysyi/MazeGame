using System.Collections;
using TMPro;
using UnityEngine;

namespace codeBase
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timerText;

        private const float SECONDS_TO_UPDATE = 1f;

        private IEnumerator _timerRunRoutine;
        private float _seconds;  

        private IEnumerator timerRunRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(SECONDS_TO_UPDATE);
                _seconds += SECONDS_TO_UPDATE;
                updateText();
            }
        }

        public void run() => StartCoroutine(_timerRunRoutine);

        public void reset()
        {
            resetRoutine();
            _seconds = 0;
            updateText();
        }

        private void updateText() => _timerText.text = _seconds.ToString();

        private void resetRoutine()
        {
            if (_timerRunRoutine != null)
            {
                StopCoroutine(_timerRunRoutine);
            }
            _timerRunRoutine = timerRunRoutine();
        }
    }
}