using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;

namespace codeBase.infrastructure
{
    public class LocalizationText : LocalizeStringEvent
    {
        [SerializeField] private TextMeshProUGUI _text;

        private void OnValidate()
        {
            if (_text == null)
                _text = gameObject.GetComponent<TextMeshProUGUI>();
        }

        protected override void UpdateString(string value)
        {
            base.UpdateString(value);
            _text.text = value;
        }

    }
}