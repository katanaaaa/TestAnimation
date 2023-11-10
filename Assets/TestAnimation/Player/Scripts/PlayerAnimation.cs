using System;
using UnityEngine;

namespace PetProject.Player
{
    public class PlayerAnimation
    {
        private Animator _playerAnimator;

        public PlayerAnimation()
        {

        }

        public void Init(Animator playerAnimator)
        {
            _playerAnimator = playerAnimator;
        }

        public void Move(string animationName, float speed)
        {
            _playerAnimator.SetFloat(animationName, speed);
        }
    }
}