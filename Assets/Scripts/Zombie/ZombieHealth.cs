using UnityEngine;

namespace ZombieFPS.Enemy
{
    public class ZombieHealth : MonoBehaviour
    {
        [SerializeField] private float maxHealth;
        [SerializeField] ParticleSystem bloodPS;

        private float currentHealth;

        private void OnEnable()
        {
            currentHealth = maxHealth;
        }
        public void TakeDamage(float amount)
        {
            bloodPS.Play();
            currentHealth -= amount;
            if(currentHealth<=0)
            {
                Death();
            }
        }

        private void Death()
        {
            EventHandler.Instance.InvokeOnEnemyDead();
            ZombiePoolService.Instance.ReturnItem(GetComponent<ZombieController>());
            gameObject.SetActive(false);
        }
    }
}
