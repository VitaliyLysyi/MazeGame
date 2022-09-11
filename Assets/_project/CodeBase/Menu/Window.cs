using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace codeBase.menu
{
    public class Window : MonoBehaviour
    {
        [SerializeField] private bool _hasParentWindow;
        [SerializeField, ShowIf("_hasParentWindow")] private Button _returnButton;

        private Window _previoueWindow = null;

        private void Start()
        {
            if (!_hasParentWindow)
                return;

            _returnButton.onClick.AddListener(EnterPreviousWindow);
        }

        private void EnterPreviousWindow()
        {
            _previoueWindow.gameObject.SetActive(true);
            Destroy(gameObject);
        }

        public void enterNew(Window previoueWindow)
        {
            if(_previoueWindow == null)
                _previoueWindow = previoueWindow;

            previoueWindow.close();
        }

        public void close() => gameObject.SetActive(false);
    }

    [Serializable]
    public class WindowGroup
    {
        public Button buttonForOpenWindow;
        public Window openWindowPrefab;
        public Window currentWindow;

        public void init()
        {
            buttonForOpenWindow.onClick.AddListener(enterWindow);
        }

        private void enterWindow()
        {
            Window window = UnityEngine.Object.Instantiate(openWindowPrefab, currentWindow.transform.parent);

            window.enterNew(currentWindow);
        }
    }

}