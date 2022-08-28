using UnityEngine;

namespace codeBase
{
    public class RingLinkedPlatform : MonoBehaviour, IInteractable
    {
        [SerializeField] private MazeRing _linkedMazeSegment;

        private void OnDrawGizmos()
        {
            if (_linkedMazeSegment == null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawCube(transform.position + Vector3.up, Vector3.one * 0.2f);
            }
        }

        public void interact(Player player)
        {
            player.setNewMovable(_linkedMazeSegment);
        }
    }
}