using TMPro;
using UnityEngine;

namespace codeBase
{
    public class FPSCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _FPSText;

        void Update()
        {
            update();
        }

        private void update()
        {
            float fps = Mathf.Round(1 / Time.deltaTime);
            _FPSText.text = fps.ToString();
        }
    }
}