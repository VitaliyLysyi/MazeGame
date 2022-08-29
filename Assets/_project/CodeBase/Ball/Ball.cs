using UnityEngine;

namespace codeBase
{
    public class Ball : MonoBehaviour, IControlable
    {
        [SerializeField] private Rigidbody _rigidbody;

        public delegate void BallAction(IInteractable interactable);
        public event BallAction onBeginInteract;

        public void beginControl(Player player)
        {
            onBeginInteract += player.beginInteraction;
        }

        public void control(float horizontalAxis, float verticalAxis)
        {
            Vector3 direction = new Vector3(horizontalAxis, 0f, verticalAxis);
            move(direction);
        }

        private void move(Vector3 direction)
        {
            _rigidbody.AddForce(direction);
        }

        public void endControl(Player player)
        {
            onBeginInteract -= player.beginInteraction;
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