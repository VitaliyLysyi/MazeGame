using UnityEngine;

namespace CodeBase
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private ActivationArea _activationObject;
        private Vector3 _closePosition;
        private Vector3 _openPosition;

        private void OnDrawGizmos()
        {
            if (_activationObject == null)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawSphere(transform.position + Vector3.up, 0.5f);
            }
        }

        private void Start()
        {
            _closePosition = transform.position;
            _openPosition = transform.position + Vector3.up;

            _activationObject.onAreaEnter += Open;
            _activationObject.onAreaExit += Close;
        }

        private void Open()
        {
            transform.position = _openPosition;
        }

        private void Close()
        {
            transform.position = _closePosition;
        }
    }
}