using UniRx;

namespace PetProject.Player
{
    public class PlayerController
    {
        public PlayerView PlayerView => _playerView;
        private PlayerView.Factory _playerFactory;
        private PlayerMovement _playerMovement;
        private PlayerView _playerView;

        public PlayerController(
            PlayerView.Factory playerFactory,
            PlayerMovement playerMovement)
        {
            _playerFactory = playerFactory;
            _playerMovement = playerMovement;

            Spawn();
        }

        public PlayerView Spawn()
        {
            _playerView = _playerFactory.Create();
            _playerMovement.Init(_playerView);

            return _playerView;
        }
    }
}