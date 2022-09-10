using UnityEngine;

namespace ZombieFPS.Enemy
{
    public class ZombieAnimationManager : MonoBehaviour
    {
        [SerializeField] private Animator zombieAnimator;

        private const string VELOCITY = "velocity";
        private const string IS_DEAD = "isDead";
        private const string CAN_ATTACK = "canAttack";
        public void SetVelocity(float amount)
        {
            zombieAnimator.SetFloat(VELOCITY, amount);
        }
        public void SetCanAttack(bool status)
        {
            zombieAnimator.SetBool(CAN_ATTACK, status);
        }
        public void SetIsDead(bool status)
        {
            zombieAnimator.SetBool(IS_DEAD, status);
        }
    }
}
