using codeBase.game.ball;
using codeBase.game.player;
using UnityEngine;

namespace codeBase.game.linkedPlatform
{
    public class LinkedPlatform : MonoBehaviour, IBallInteractable
    {
        [SerializeField] private GameObject _linkedObject;

        private void OnDrawGizmos()
        {
            if (_linkedObject == null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawCube(transform.position + Vector3.up, Vector3.one * 0.2f);
            }
        }

        public void interact(Ball ball)
        {
            bool ballNotInControl = !ball.isControled();
            if (ballNotInControl)
            {
                return;
            }

            IPlayerControlable controlable = _linkedObject.GetComponent<IPlayerControlable>();
            if (controlable != null)
            {
                Player player = ball.player;
                player.setNewControlable(controlable);
            }
        }
    }
}