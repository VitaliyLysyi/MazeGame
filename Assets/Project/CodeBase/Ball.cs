using UnityEngine;

namespace CodeBase
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        private void Update()
        {
            float AxisX = Input.GetAxis("Horizontal");
            float AxisZ = Input.GetAxis("Vertical");

            Move(new Vector3(AxisX, 0f, AxisZ));
        }

        public void Move(Vector3 direction)
        {
            _rigidbody.AddForce(direction);
        }
    }
}