using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class Window : MonoBehaviour
{
    [SerializeField] private bool _hasParentWindow;
    [SerializeField, ShowIf("_hasParentWindow")] private Button _returnButton;

    private Window _previoueWindow;

    private void Start()
    {
        if(_returnButton == null)
            return;

        _returnButton.onClick.AddListener(EnterPreviousWindow);
    }

    private void EnterPreviousWindow()
    {
        _previoueWindow.Enter(this);
    }

    public void Enter(Window currentWindow)
    {
        currentWindow.Exit();
        _previoueWindow = currentWindow;
        gameObject.SetActive(true);
    }

    public void Exit()
    {
        gameObject.SetActive(false);
    }

}
