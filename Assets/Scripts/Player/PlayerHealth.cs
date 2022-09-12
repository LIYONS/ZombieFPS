using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieFPS.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private float maxHealth;

        private float currentHealth;
        private bool isDead;

        private void Start()
        {
            currentHealth = maxHealth;
            isDead = false;
        }
        public void TakeDamage(float amount)
        {
            if (!isDead)
            {
                currentHealth -= amount;
                if (currentHealth <= 0)
                {
                    isDead = true;
                    Death();
                }
                EventHandler.Instance.InvokePlayerDamaged(amount);
            }
        }

        private void Death()
        {
            EventHandler.Instance.InvokeOnGameOver();
        }
    }
}
