using UnityEngine;

namespace codeBase
{
    public class MazeRing : MonoBehaviour, IControlable
    {
        private const float ROTATION_SPEED = 30f;

        public void beginControl(Player player)
        {
            throw new System.NotImplementedException();
        }

        public void control(float horizontalAxis, float verticalAxis)
        {
            rotate(horizontalAxis);
        }

        private void rotate(float angle)
        {
            Vector3 rotation = angle * ROTATION_SPEED * Time.deltaTime * Vector3.up;
            transform.Rotate(rotation);
        }

        public void endControl(Player player)
        {
            throw new System.NotImplementedException();
        }
    }
}