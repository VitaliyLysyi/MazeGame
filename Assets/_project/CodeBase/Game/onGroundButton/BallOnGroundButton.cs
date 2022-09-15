using codeBase.game.ball;
using codeBase.game.player;
using UnityEngine;

namespace codeBase.game.onGroundButton
{
    public class BallOnGroundButton : OnGroundButton
    {
        [SerializeField] private Ball _ball;

        private void OnDrawGizmos()
        {
            if (_ball == null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawCube(transform.position + Vector3.up, Vector3.one * 0.2f);
            }
        }

        protected override void triggerEnter(Collider otherCollider)
        {
            Ball ball = otherCollider.GetComponent<Ball>();
            bool isBall = ball != null;
            if (isBall && ball.isControled())
            {
                Player player = ball.player;
                player.setNewControlable(_ball);
            }
        }
    }
}