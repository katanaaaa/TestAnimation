using PetProject.Player;
using UnityEngine;
using Zenject;

namespace PetProject.Camera
{
    public class CameraController : ILateTickable
    {
        private TickableManager _tickableManager;
        private CameraView.Factory _cameraFactory;
        private PlayerController _playerController;
        private CameraView _cameraView;
        private PlayerView _playerView;
        private float _speed = 10f;
        private Vector3 _offset = new Vector3(0f, 3.3f, -3f);

        public CameraController(
            TickableManager tickableManager,
            CameraView.Factory cameraFactory,
            PlayerController playerController)
        {
            _tickableManager = tickableManager;
            _cameraFactory = cameraFactory;
            _playerController = playerController;
            _playerView = _playerController.PlayerView;

            Create();
            _tickableManager.AddLate(this);
        }

        public void LateTick()
        {
            var step = _speed * Time.deltaTime;
            var target = _playerView.transform.position + _offset;
            _cameraView.transform.position = Vector3.Lerp(_cameraView.transform.position, target, 0.25f);
        }

        private void Create()
        {
            _cameraView = _cameraFactory.Create();
        }
    }
}