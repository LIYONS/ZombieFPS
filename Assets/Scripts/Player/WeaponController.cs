using System;
using System.Collections;
using System.Collections.Generic;
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

        private PlayerAnimationManager playerAnimation;
        private float fireTimer;
        private RaycastHit rayCast;
        private float fireAnimTimer;
        private bool isFiring;

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
            if(fireTimer<Time.time)
            {
                playerAnimation.SetIsFiring(true);
                isFiring = true;
                fireAnimTimer = Time.time + fireAnimTime;
                fireTimer = Time.time + timeBtwFire;
                if(Physics.Raycast(mainCam.position,transform.forward,out rayCast,weaponRange,enemyLayer))
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
    }
}
