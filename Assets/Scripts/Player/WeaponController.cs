using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieFPS
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private Transform mainCam;
        [SerializeField] private float weaponDamage;
        [SerializeField] private float timeBtwFire;
        [SerializeField] private float weaponRange;
        [SerializeField] private LayerMask enemyLayer;

        private float fireTimer;
        private RaycastHit rayCast;

        private void Start()
        {
            fireTimer = 0;
        }

        public void Fire()
        {
            if(fireTimer<Time.time)
            {
                fireTimer = Time.time + timeBtwFire;
                if(Physics.Raycast(mainCam.position,transform.forward,out rayCast,weaponRange,enemyLayer))
                {
                    Debug.Log("Hit");
                }
            }
        }
    }
}
