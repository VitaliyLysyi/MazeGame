using System.Collections;
using codeBase.game.ball;
using codeBase.game.onGroundButton;
using Sirenix.OdinInspector;
using UnityEngine;

namespace codeBase
{
    public class SpikeOnGroundButton : OnGroundButton
    {
        [SerializeField] private GameObject _spikes;
        [SerializeField] private bool _nonStatic;
        [SerializeField, ShowIf("_nonStatic")] private float _secondsInterval = 1f;
        [SerializeField, ShowIf("_nonStatic")] private float _secondsDelay = 1f;


        private bool _spikesEnabled = true;

        protected override void triggerStay(Collider otherCollider)
        {
            if (_spikesEnabled)
            {
                Ball ball = otherCollider.GetComponent<Ball>();
                if (ball != null)
                {
                    ball.destroy();
                }
            }
        }

        private void Start()
        {
            if (_nonStatic)
            {
                StartCoroutine(spikeIntervalRoutine());
            }
        }

        private IEnumerator spikeIntervalRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(_secondsDelay);
                switchSpikes();
                yield return new WaitForSeconds(_secondsInterval);
                switchSpikes();
            }
        }

        private void switchSpikes()
        {
            _spikesEnabled = !_spikesEnabled;
            _spikes.gameObject.SetActive(_spikesEnabled);
        }
    }
}