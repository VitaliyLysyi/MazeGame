using UnityEngine;

namespace codeBase.game.onGroundButton
{
    public class OnGroundButton : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            triggerEnter(other);
        }

        private void OnTriggerStay(Collider other)
        {
            triggerStay(other);
        }

        private void OnTriggerExit(Collider other)
        {
            triggerExit(other);
        }

        protected virtual void triggerEnter(Collider otherCollider) { }

        protected virtual void triggerStay(Collider otherCollider) { }

        protected virtual void triggerExit(Collider otherCollider) { }
    }
}