using System.Collections;
using System.Collections.Generic;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.States;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class StartFromPreloader : MonoBehaviour
{
    public static bool isStartFromPreloader = false;

    private Game _game;

    [Inject]
    private void Constructor(Game game)
    {
        _game = game;
    }

    private void Start()
    {
        if (!isStartFromPreloader && !isPreloaderScene())
        {
            _game.StateMachine.Enter<LoadLevelState, string>(SceneName.PRELOADER);
        }
    }

    private static bool isPreloaderScene() => SceneManager.GetActiveScene().name == SceneName.PRELOADER;
}
