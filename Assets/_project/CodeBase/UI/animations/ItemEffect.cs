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
            _startPosition = transform.position;
            transform.position = getInitPosition();
            transform.DOMove(_startPosition, _duretion).SetEase(_ease).SetLink(gameObject);
        }

        private Vector3 getInitPosition()
        {
            Vector3 sideSize = _initDirection * _canvas.rect.size;
            Vector3 mySize = (transform as RectTransform).rect.size;
            return sideSize + mySize;
        }
    }
}
