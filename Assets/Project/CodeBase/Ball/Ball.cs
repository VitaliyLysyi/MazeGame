using UnityEngine;

namespace CodeBase
{
    public class Ball : MonoBehaviour, IMovable
    {
        [SerializeField] private Rigidbody _rigidbody;

        public void move(float horizontal, float vertical)
        {
            Vector3 direction = new Vector3(horizontal, 0f, vertical);
            _rigidbody.AddForce(direction);
        }
    }
}