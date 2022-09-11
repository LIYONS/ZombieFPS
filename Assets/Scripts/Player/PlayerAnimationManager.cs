using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieFPS.Player
{
    public class PlayerAnimationManager : MonoBehaviour
    {
        [SerializeField] private Animator playerAnimator;

        private const string IS_FIRING = "isFiring";

        public void SetIsFiring(bool status)
        {
            playerAnimator.SetBool(IS_FIRING, status);
        }

        public bool IsFiring { get { return playerAnimator.GetBool(IS_FIRING); } }
    }
}
