using codeBase.game.ball;
using codeBase.game.onGroundButton;
using codeBase.game.player;
using UnityEngine;

namespace codeBase
{
    public class ScoreOnGroundButton : OnGroundButton
    {
        [SerializeField] private GameObject _scoreGameObject;

        private bool _activated;

        protected override void triggerEnter(Collider otherCollider)
        {
            if (_activated)
            {
                return;
            }

            Ball ball = otherCollider.GetComponent<Ball>();
            bool isBall = ball != null;
            if (isBall && ball.isControled())
            {
                Player player = ball.player;
                player.scorePick();

                _scoreGameObject.SetActive(false);
                _activated = true;
            }
        }
    }
}