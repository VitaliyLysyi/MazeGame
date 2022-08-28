using codeBase.infrastructure;
using codeBase.infrastructure.constants;
using codeBase.infrastructure.States;
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
            _game.stateMachine.Enter<LoadLevelState, string>(Constants.SCENE_PRELOADER);
        }
    }

    private static bool isPreloaderScene() => SceneManager.GetActiveScene().name == Constants.SCENE_PRELOADER;
}
