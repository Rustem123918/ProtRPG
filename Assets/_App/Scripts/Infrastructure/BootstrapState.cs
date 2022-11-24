using _App.Scripts.Services.Input;
using UnityEngine;

namespace _App.Scripts.Infrastructure
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private const string MainSceneName = "Main";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            RegisterServices();
            _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
        }

        private void EnterLoadLevel()
        {
            _gameStateMachine.Enter<LoadLevelState, string>(MainSceneName);
        }

        private void RegisterServices()
        {
            Game.InputService = RegisterInputService();
        }

        public void Exit()
        {

        }

        private IInputService RegisterInputService()
        {
            if (Application.isEditor)
                return new StandaloneInputService();
            else
                return new MobileInputService();
        }
    }
}
