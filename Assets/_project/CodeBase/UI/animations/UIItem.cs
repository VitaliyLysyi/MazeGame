using Sirenix.OdinInspector;
using UnityEngine;

namespace codeBase.ui.animations
{
    public class UIItem : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;

        public Vector3 _startPosition;
        public Vector3 _endPosition;

        private void OnValidate()
        {
            if (_rectTransform == null) {
                _rectTransform = GetComponent<RectTransform>();
            }
        }

        [Button]
        private void initStartPosition() => _startPosition = _rectTransform.localPosition;

        [Button]
        private void initEndPosition() => _endPosition = _rectTransform.localPosition;

        [Button]
        public void restartPositionStart() => _rectTransform.localPosition = _startPosition;

        [Button]
        public void restartPositionEnd() => _rectTransform.localPosition = _endPosition;
    }
}