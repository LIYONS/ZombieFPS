using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using ZombieFPS.Services;
using ZombieFPS.Player;

namespace ZombieFPS.Enemy
{
    public class ZombieController : MonoBehaviour
    {
        [Header("Attack")]
        [SerializeField] private float damageToDeliver;
        [SerializeField] private float timeBtwAttack=1f;

        private NavMeshAgent navAgent;
        private ZombieAnimationManager animationManager;
        private PlayerHealth playerHealth;
        private bool isAttacking;
        private float attackTimer;
        private Transform target;
        private float distanceToTarget;

        private void Awake()
        {
            navAgent = GetComponent<NavMeshAgent>();
            animationManager = GetComponent<ZombieAnimationManager>();
        }
        private void Start()
        {
            attackTimer = timeBtwAttack;
            target = PlayerService.Instance.playerTransform;
            playerHealth = target.GetComponent<PlayerHealth>();
        }
        private void Update()
        {
            distanceToTarget = Vector3.Distance(transform.position, target.position);
            if (target)
            {
                navAgent.SetDestination(target.position);
            }
            animationManager.SetVelocity(Mathf.Abs(navAgent.velocity.magnitude));
            if(distanceToTarget<2f &&!isAttacking )
            {
                isAttacking = true;
                animationManager.SetCanAttack(true);
            }
            else if(distanceToTarget > 2f && isAttacking)
            {
                isAttacking = false;
                animationManager.SetCanAttack(false);
            }
            if(isAttacking && attackTimer<Time.time)
            {
                Damage();
            }
        }
        private void Damage()
        {
            attackTimer = Time.time + timeBtwAttack;
            playerHealth.TakeDamage(damageToDeliver);
        }
    }
}