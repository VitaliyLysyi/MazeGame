using codeBase.infrastructure.Coroutines;
using codeBase.infrastructure.States;
using codeBase.Logic;

namespace codeBase.infrastructure
{
    public class Game
    {
        public GameStateMachine stateMachine;
        public GameSettings settings;

        public static Game instance;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain, GameSettings gameSettings)
        {
            instance = this;
            settings = gameSettings;
            stateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), curtain);
        }
    }
}