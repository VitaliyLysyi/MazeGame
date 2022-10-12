using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace codeBase
{
    public class ItemEffect : MonoBehaviour
    {
        [SerializeField] private Ease _ease;
        [SerializeField] private float _duretion;
        [SerializeField] private Vector2 _initDirection;
        [SerializeField] private RectTransform _canvas;

        private Vector3 _startPosition;

        [Button]
        private void Start()
        {
            Debug.Log(0);
            _startPosition = transform.localPosition;
            transform.localPosition += getInitPosition();
            Debug.Log(transform.localPosition);
            transform.DOLocalMove(_startPosition, _duretion).SetEase(_ease).SetLink(gameObject);
        }

        private Vector3 getInitPosition()
        {
            Vector3 currentPos = transform.localPosition;
            Vector3 sideSize = _initDirection * (_canvas.rect.size - (Vector2)currentPos);
            Vector3 mySize = ((transform as RectTransform).rect.size / 2) * _initDirection;
            return sideSize + mySize;
        }
    }
}
