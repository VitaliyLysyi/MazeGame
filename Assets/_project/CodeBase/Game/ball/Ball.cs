using System.Collections.Generic;
using codeBase.game.linkedPlatform;
using codeBase.game.player;
using UnityEngine;

namespace codeBase.game.ball
{
    public class Ball : MonoBehaviour, IPlayerControlable
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private BallSettings _ballSettings;
        [SerializeField] private List<Collider> _ignoreColiders;

        private Player _player;

        private void Start()
        {
            setUpIgnoreColiders();
        }

        private void setUpIgnoreColiders()
        {
            if (_ignoreColiders == null)
            {
                return;
            }

            Collider collider = GetComponent<Collider>();
            foreach (Collider ignoreCollider in _ignoreColiders)
            {
                Physics.IgnoreCollision(collider, ignoreCollider);
            }
        }

        public void beginControl(Player player)
        {
            _player = player;
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
            _player = null;
        }

        private void OnTriggerEnter(Collider other)
        {
            IBallInteractable interactableObject = other.GetComponent<IBallInteractable>();
            if (interactableObject != null)
            {
                interactableObject.interact(this);
            }
        }

        public Player player => _player;

        public bool isControled() => _player != null ? true : false;
    }
}