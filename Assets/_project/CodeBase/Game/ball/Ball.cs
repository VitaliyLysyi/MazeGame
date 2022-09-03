using System;
using codeBase.game.linkedPlatform;
using codeBase.game.player;
using UnityEngine;

namespace codeBase.game.ball
{
    public class Ball : MonoBehaviour, IControlable
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private BallSettings _ballSettings;

        public event Action<IInteractable> onBeginInteract;

        public void beginControl(Player player)
        {
            onBeginInteract += player.beginInteraction;
        }

        public void control(float horizontalAxis, float verticalAxis)
        {
            float sensitivity = _ballSettings.controlSensitivity;
            Vector3 direction = new Vector3(horizontalAxis, 0f, verticalAxis) * sensitivity;
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