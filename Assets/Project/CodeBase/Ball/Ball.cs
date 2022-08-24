using UnityEngine;

namespace CodeBase
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        public void move(Vector3 direction)
        {
            _rigidbody.AddForce(direction);
        }
    }
}