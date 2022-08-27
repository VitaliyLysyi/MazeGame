using UnityEngine;

namespace CodeBase
{
    public class Ball : MonoBehaviour, IMovable
    {
        [SerializeField] private Rigidbody _rigidbody;

        public delegate void BallAction(IInteractable interactable);
        public event BallAction onBeginInteract;

        public void move(float horizontal, float vertical)
        {
            Vector3 direction = new Vector3(horizontal, 0f, vertical);
            _rigidbody.AddForce(direction);
        }

        private void OnTriggerEnter(Collider other)
        {
            IInteractable interacteble = other.GetComponent<IInteractable>();
            if (interacteble != null)
            {
                onBeginInteract?.Invoke(interacteble);
            }
        }
    }
}