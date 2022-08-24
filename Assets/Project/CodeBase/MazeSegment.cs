using UnityEngine;

namespace CodeBase
{
    public class MazeSegment : MonoBehaviour
    {
        private void Update()
        {
            float TempAxis = Input.GetAxis("Horizontal");

            if (TempAxis != 0)
            {
                Rotate(TempAxis);
            }
        }

        public void Rotate(float angle)
        {
            float tempSpeed = 25f;
            Vector3 rotation = angle * tempSpeed * Time.deltaTime * Vector3.up;
            transform.Rotate(rotation);
        }
    }
}