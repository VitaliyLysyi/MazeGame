using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Menu
{
    public class Window : MonoBehaviour
    {
        [SerializeField] private bool _hasParentWindow;
        [SerializeField, ShowIf("_hasParentWindow")] private Button _returnButton;

        private Window _previoueWindow;

        private void Start()
        {
            if (!_hasParentWindow)
                return;

            _returnButton.onClick.AddListener(EnterPreviousWindow);
        }

        private void EnterPreviousWindow()
        {
            _previoueWindow.Enter(this);
        }

        public void Enter(Window previoueWindow)
        {
            previoueWindow.Close();
            if(_previoueWindow == null)
                _previoueWindow = previoueWindow;
            
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

    }

    [Serializable]
    public class ButtonGroup
    {
        public Button button;
        public Window openWindow;
        public Window currentWindow;

        public void Init()
        {
            button.onClick.AddListener(EnterWindow);
        }

        private void EnterWindow()
        {
            openWindow.Enter(currentWindow);
        }
    }

}