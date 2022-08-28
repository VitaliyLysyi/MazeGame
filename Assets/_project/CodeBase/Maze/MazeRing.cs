using UnityEngine;

namespace codeBase
{
    public class MazeRing : MonoBehaviour, IMovable
    {
        private const float ROTATION_SPEED = 30f;

        public void move(float horizontal, float vertical)
        {
            Vector3 rotation = horizontal * ROTATION_SPEED * Time.deltaTime * Vector3.up;
            transform.Rotate(rotation);
        }
    }
}