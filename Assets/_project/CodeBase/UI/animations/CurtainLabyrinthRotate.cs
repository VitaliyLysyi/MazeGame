using System;
using System.Collections;
using System.Collections.Generic;
using codeBase.extansionMethods;
using UnityEngine;

namespace codeBase
{
    public class CurtainLabyrinthRotate : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _rateteCurve;
        [SerializeField] private float _retateSpeed;
        [SerializeField] private Transform[] _rotateElements;

        private Coroutine _rotateRoutine;

        private void OnEnable()
        {
            resetLabyrinth();

            _rotateRoutine = StartCoroutine(rotateRoutine());
        }

        private void OnDisable()
        {
            if(_rotateRoutine != null)
                StopCoroutine(_rotateRoutine);
        }

        private void resetLabyrinth()
        {
            foreach (Transform circle in _rotateElements)
            {
                circle.rotation = Quaternion.identity;
            }
        }

        private IEnumerator rotateRoutine()
        {
            float step = _rateteCurve.keys.getLastElement().time / _rotateElements.Length;
            float rotateSpeed;

            while (true)
            {
                for (int i = 0; i < _rotateElements.Length; i++)
                {
                    rotateSpeed = (_retateSpeed * _rateteCurve.Evaluate(step * i)) * Time.deltaTime;

                    if ((i % 2) == 0)
                        rotateSpeed *= -1;

                    _rotateElements[i].Rotate(Vector3.forward * rotateSpeed);
                }
                yield return null;
            }
        }
    }
}
