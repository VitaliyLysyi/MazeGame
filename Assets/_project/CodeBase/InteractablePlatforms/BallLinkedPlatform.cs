using UnityEngine;

namespace codeBase
{
    public class BallLinkedPlatform : MonoBehaviour, IInteractable
    {
        [SerializeField] private Ball _linkedBall;

        private void OnDrawGizmos()
        {
            if (_linkedBall == null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawCube(transform.position + Vector3.up, Vector3.one * 0.2f);
            }
        }

        public void interact(Player player)
        {
            player.setNewMovable(_linkedBall);
        }
    }
}