using UnityEngine;
using Zenject;

namespace PetProject.Player
{
    public class PlayerMovement : ITickable
    {
        private PlayerView _playerView;
        private Animator _playerAnimator;
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
            _playerAnimator = _playerView.GetComponentInChildren<Animator>();
            _tickableManager.Add(this);
            //_playerAnimation.Init(_playerAnimator);
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

            if (z != 0 || x != 0)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    _playerAnimator.SetBool("Idle", false);
                    _playerAnimator.SetBool("Walking", false);
                    _playerAnimator.SetBool("Running", true);
                    _playerView.transform.Translate(target);
                }
                else
                {
                    _playerAnimator.SetBool("Idle", false);
                    _playerAnimator.SetBool("Running", false);
                    _playerAnimator.SetBool("Walking", true);
                    _playerView.transform.Translate(target);
                }
            }
            else
            {
                _playerAnimator.SetBool("Walking", false);
                _playerAnimator.SetBool("Running", false);
                _playerAnimator.SetBool("Idle", true);
            }
        }
    }
}