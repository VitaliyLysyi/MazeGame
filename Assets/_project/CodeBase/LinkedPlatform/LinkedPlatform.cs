using UnityEngine;

namespace codeBase
{
    public class LinkedPlatform : MonoBehaviour, IInteractable
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

        public void interact(Player player)
        {
            IControlable controlable = _linkedObject.GetComponent<IControlable>();
            if (controlable != null)
            {
                player.setNewControlable(controlable);
            }
        }
    }
}
