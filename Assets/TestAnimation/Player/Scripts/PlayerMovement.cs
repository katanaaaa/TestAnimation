using UnityEngine;
using Zenject;

namespace PetProject.Player
{
    public class PlayerMovement : ITickable
    {
        private PlayerView _playerView;
        private TickableManager _tickableManager;
        private PlayerAnimation _playerAnimation;
        private float _speed = 3f;

        public PlayerMovement(
            TickableManager tickableManager,
            PlayerAnimation playerAnimation)
        {
            _tickableManager = tickableManager;
            _playerAnimation = playerAnimation;
        }

        public void Init(PlayerView playerView)
        {
            _playerView = playerView;
            var playerAnimator = _playerView.GetComponentInChildren<Animator>();
            _tickableManager.Add(this);
            _playerAnimation.Init(playerAnimator);
        }

        public void StopTick()
        {
            _tickableManager.Remove(this);
        }

        public void Tick()
        {
            var z = Input.GetAxis("Vertical");
            var x = Input.GetAxis("Horizontal");
            var target = new Vector3(x, 0, z) * _speed * Time.deltaTime;

            _playerAnimation.Move("Horizontal", z);
            _playerAnimation.Move("Vertical", x);
            _playerView.transform.Translate(target);
        }
    }
}