using UnityEngine;
using UnityEngine.UI;

namespace codeBase.ui.particles
{
    public class Particle : MonoBehaviour
    {
        public Image image;
        public Vector2 sizeRange;
        
        [SerializeField] private Color _startColor;
        
        public void active()
        {
            gameObject.SetActive(true);

            image.color = _startColor;
        }
    }
}
