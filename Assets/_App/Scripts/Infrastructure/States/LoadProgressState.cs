using _App.Scripts.Data;
using _App.Scripts.Infrastructure.Services.PersistentProgress;
using _App.Scripts.Infrastructure.Services.SaveLoad;

namespace _App.Scripts.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;

        public LoadProgressState(GameStateMachine stateMachine, IPersistentProgressService persistentProgressService, ISaveLoadService saveLoadService)
        {
            _stateMachine = stateMachine;
            _progressService = persistentProgressService;
            _saveLoadService = saveLoadService;
        }
        public void Enter()
        {
            LoadProgressOrInitNew();
            _stateMachine.Enter<LoadLevelState, string>(_progressService.Progress.WorldData.PositionOnLevel.Level);
        }

        public void Exit()
        {
        }

        private void LoadProgressOrInitNew()
        {
            _progressService.Progress = _saveLoadService.LoadProgress() ?? NewProgress();
        }

        private PlayerProgress NewProgress()
        {
            return new PlayerProgress(initialLevel: "Main");
        }
    }
}
