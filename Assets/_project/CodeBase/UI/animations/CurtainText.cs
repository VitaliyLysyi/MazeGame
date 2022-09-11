using System.Collections;
using TMPro;
using UnityEngine;

namespace codeBase.ui.animations
{
    public class CurtainText : MonoBehaviour
    {
        private const string LOADING = "LOADING";
        private const string LOADING_DOT = "...";
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private float _characterUpdateDuration;

        private Coroutine _textUpdateRoutine;
        private string _textForUpdate;

        private void OnEnable()
        {
            _textForUpdate = "";
            _textUpdateRoutine = StartCoroutine(updataTextRoutine());
        }

        private void OnDisable()
        {
            if(_textUpdateRoutine != null)
                StopCoroutine(_textUpdateRoutine);
        }

        private IEnumerator updataTextRoutine()
        {
            if (_textForUpdate.Length < LOADING_DOT.Length)
                _textForUpdate += LOADING_DOT[0];
            else
                _textForUpdate = "";

            _text.text = LOADING + _textForUpdate;

            yield return new WaitForSeconds(_characterUpdateDuration);

            _textUpdateRoutine = StartCoroutine(updataTextRoutine());
        }
    }
}
