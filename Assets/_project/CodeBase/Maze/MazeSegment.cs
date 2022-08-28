using UnityEngine;

namespace codeBase
{
    public class MazeSegment : MonoBehaviour, IMovable
    {
        private const float ROTATION_SPEED = 25f;

        public void move(float horizontal, float vertical)
        {
            Vector3 rotation = horizontal * ROTATION_SPEED * Time.deltaTime * Vector3.forward;
            transform.Rotate(rotation);
        }
    }
}