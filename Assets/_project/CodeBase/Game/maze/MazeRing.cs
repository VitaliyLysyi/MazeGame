using codeBase.game.ball;
using codeBase.game.player;
using UnityEngine;

namespace codeBase.game.maze
{
    public class MazeRing : MonoBehaviour, IControlable
    {
        [SerializeField] private MazeRingSettings _mazeRingSettings;

        public void beginControl(Player player)
        {

        }

        public void control(float horizontalAxis, float verticalAxis)
        {
            rotate(horizontalAxis);
        }

        private void rotate(float angle)
        {
            float rotationSpeed = _mazeRingSettings.rotationSpeed;
            Vector3 rotation = angle * rotationSpeed * Time.deltaTime * Vector3.up;
            transform.Rotate(rotation);
        }

        public void endControl(Player player)
        {

        }
    }
}