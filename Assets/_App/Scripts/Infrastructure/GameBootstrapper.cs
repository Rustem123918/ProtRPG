using _App.Scripts.Infrastructure.States;
using _App.Scripts.Logic;
using UnityEngine;

namespace _App.Scripts.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private LoadingCurtain _curtainPrefab;
        private Game _game;

        private void Awake()
        {
            _game = new Game(this, Instantiate(_curtainPrefab));
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}