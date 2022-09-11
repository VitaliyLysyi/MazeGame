using System;
using codeBase.infrastructure;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace codeBase.menu
{
    public class LanguageButton : MonoBehaviour
    {
        [SerializeField] private Button _leftButton;
        [SerializeField] private Button _rightButton;
        [SerializeField] private TextMeshProUGUI _labguageLable;

        private LanguageType _currentLanguage;

        public event Action<LanguageType> onLanguageChanged;

        public void init(LanguageType language)
        {
            _currentLanguage = language;
            updateLanguageLable();
        }

        private void Start()
        {
            _leftButton.onClick.AddListener(changeLanguage);
            _rightButton.onClick.AddListener(changeLanguage);
        }


        private void changeLanguage()
        {
            int index = Array.IndexOf(Enum.GetValues(typeof(LanguageType)), _currentLanguage);
            index += 1;

            if (index >= Enum.GetValues(typeof(LanguageType)).Length)
                index = 0;

            Debug.Log("index = " + index);
            _currentLanguage = (LanguageType)Enum.GetValues(typeof(LanguageType)).GetValue(index);
            updateLanguageLable();
            onLanguageChanged?.Invoke(_currentLanguage);
        }

        private void updateLanguageLable() => _labguageLable.text = _currentLanguage.ToString();
    }
}
