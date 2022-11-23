using _App.Scripts.CameraLogic;
using UnityEngine;

namespace _App.Scripts.Infrastructure
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            var hero = Instantiate("Hero/Hero");
            Instantiate("Hud/Hud");

            CameraFollow(hero);
        }

        private GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        private void CameraFollow(GameObject target) =>
            Camera.main.GetComponent<CameraFollow>().Follow(target);
    }
}
