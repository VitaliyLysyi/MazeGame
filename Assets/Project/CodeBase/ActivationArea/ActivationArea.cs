using System;
using UnityEngine;

namespace CodeBase
{
    public class ActivationArea : MonoBehaviour
    {
        public event Action onAreaEnter;
        public event Action onAreaExit;

        private void OnTriggerEnter(Collider other)
        {
            IMovable movable = other.GetComponent<IMovable>();
            if (movable != null)
            {
                onAreaEnter?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            IMovable movable = other.GetComponent<IMovable>();
            if (movable != null)
            {
                onAreaExit?.Invoke();
            }
        }
    }
}