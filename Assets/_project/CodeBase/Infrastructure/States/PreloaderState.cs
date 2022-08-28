namespace codeBase.infrastructure.States
{
    public class PreloaderState : IState
    {
        private const string Initial = "Preloader";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public PreloaderState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
        }

        public void Exit()
        {
        }

        private void EnterLoadLevel() =>
          _stateMachine.Enter<LoadLevelState, string>("StartMenu");

    }
}