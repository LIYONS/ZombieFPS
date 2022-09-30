using UnityEngine;
using ZombieFPS.Enemy;

namespace ZombieFPS.Player
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private Transform mainCam;
        [SerializeField] private float weaponDamage;
        [SerializeField] private float timeBtwFire;
        [SerializeField] private float weaponRange;
        [SerializeField] private LayerMask enemyLayer;
        [SerializeField] private float fireAnimTime = 0.3f;
        [Header("Audio")]
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip fireAudio;

        private PlayerAnimationManager playerAnimation;
        private float fireTimer;
        private RaycastHit rayCast;
        private float fireAnimTimer;
        private bool isFiring;
        private bool isGamePaused;

        private void Start()
        {
            fireTimer = 0;
            playerAnimation = GetComponent<PlayerAnimationManager>();
        }

        private void Update()
        {
            if(isFiring && fireAnimTimer<Time.time)
            {
                StopFireAnimation();
            }
        }
        public void Fire()
        {
            if(fireTimer<Time.time && !isGamePaused)
            {
                audioSource.PlayOneShot(fireAudio);
                playerAnimation.SetIsFiring(true);
                isFiring = true;
                fireAnimTimer = Time.time + fireAnimTime;
                fireTimer = Time.time + timeBtwFire;
                if(Physics.Raycast(mainCam.position,mainCam.transform.forward,out rayCast,weaponRange,enemyLayer))
                {
                    ZombieHealth zombieHealth= rayCast.transform.GetComponent<ZombieHealth>();
                    if(zombieHealth)
                    {
                        zombieHealth.TakeDamage(weaponDamage,rayCast.point);
                    }
                }
                Invoke(nameof(StopFireAnimation),.5f);
            }
        }

        private void StopFireAnimation()
        {
            playerAnimation.SetIsFiring(false);
        }

        private void OnGamePaused()
        {
            isGamePaused = true;
        }
        private void OnGameResumed()
        {
            isGamePaused = false;
        }
    }
}
