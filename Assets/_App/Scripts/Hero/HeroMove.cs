using _App.Scripts.Data;
using _App.Scripts.Infrastructure.Services;
using _App.Scripts.Infrastructure.Services.Input;
using _App.Scripts.Infrastructure.Services.PersistentProgress;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _App.Scripts.Hero
{
    public class HeroMove : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _movementSpeed;

        private IInputService _inputService;
        private Camera _camera;

        private void Awake()
        {
            _inputService = AllServices.Container.Single<IInputService>();
        }

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            Vector3 movementVector = Vector3.zero;

            if(_inputService.Axis.sqrMagnitude > Constants.Epsilon)
            {
                movementVector = _camera.transform.TransformDirection(_inputService.Axis);
                movementVector.y = 0;
                movementVector.Normalize();

                transform.forward = movementVector;
            }

            movementVector += Physics.gravity;

            _characterController.Move(_movementSpeed * movementVector * Time.deltaTime);
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.WorldData.PositionOnLevel = new PositionOnLevel(CurrentLevel(),
                transform.position.AsVectorData());
        }

        public void LoadProgress(PlayerProgress progress)
        {
            if(CurrentLevel() == progress.WorldData.PositionOnLevel.Level)
            {
                var savedPosition = progress.WorldData.PositionOnLevel.Position;
                if(savedPosition != null)
                    Warp(to: savedPosition);
            }
        }

        private void Warp(Vector3Data to)
        {
            _characterController.enabled = false;
            transform.position = to.AsUnityVector().AddY(_characterController.height);
            _characterController.enabled = true;
        }

        private string CurrentLevel()
        {
            return SceneManager.GetActiveScene().name;
        }
    }
}