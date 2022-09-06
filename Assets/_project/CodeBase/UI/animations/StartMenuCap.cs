using System.Collections;
using System.Collections.Generic;
using codeBase.ui.animations;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
namespace codeBase.ui.animations
{
    public class StartMenuCap : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _fallCurve;
        [SerializeField] private float _averageFallDuration;
        [SerializeField] private Ease _ease;
        [SerializeField] private List<UIItem> _uIItems;

        private void Start()
        {
            resetCapPosition();

            Invoke(nameof(startAnimation), 0.75f);
        }

        [Button("test Animation")]
        private void startAnimation()
        {
            killTweens();

            float step = _fallCurve.keys[_fallCurve.keys.Length - 1].time / _uIItems.Count;

            for (int i = 0; i < _uIItems.Count; i++)
            {
                UIItem item = _uIItems[i];
                float duration = _fallCurve.Evaluate(step * i) * _averageFallDuration;
                item.transform.DOLocalMove(item._endPosition, duration).SetEase(_ease).SetLink(item.gameObject);
            }
        }

        private void resetCapPosition()
        {
            foreach (UIItem item in _uIItems)
            {
                item.restartPositionStart();
            }
        }

        private void killTweens()
        {
            foreach (UIItem item in _uIItems)
            {
                DOTween.Kill(item.gameObject);
                item.restartPositionStart();
            }
        }
    }
}