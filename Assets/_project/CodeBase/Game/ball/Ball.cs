using System.Collections.Generic;
using codeBase.game.player;
using DG.Tweening;
using UnityEngine;

namespace codeBase.game.ball
{
    public class Ball : MonoBehaviour, IPlayerControlable
    {
        [SerializeField] private Collider _collider;
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

            foreach (Collider ignoreCollider in _ignoreColiders)
            {
                Physics.IgnoreCollision(_collider, ignoreCollider);
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
            _rigidbody.AddForce(direction);
        }

        public void endControl(Player player)
        {
            _player = null;
        }

        public void destroy()
        {
            _rigidbody.isKinematic = true;
            _rigidbody.useGravity = false;
            _collider.enabled = false;

            if (isControled())
            {
                _player.setNewControlable(null);
            }

            Vector3 endPosition = transform.position + Vector3.up * 3f;
            Vector3 endScale = transform.localScale + Vector3.one;
            DOTween.Sequence()
                .Append(transform.DOScale(endScale, 2f))
                .Join(transform.DOMove(endPosition, 2f))
                .Join(transform.DOShakeRotation(2f, 1f))
                .AppendCallback(() => Destroy(gameObject));
        }

        public Player player => _player;

        public bool isControled() => _player != null ? true : false;
    }
}