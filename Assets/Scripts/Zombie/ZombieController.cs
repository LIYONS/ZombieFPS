using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using ZombieFPS.Services;

namespace ZombieFPS.Enemy
{
    public class ZombieController : MonoBehaviour
    {
        [Header("Attack")]
        [SerializeField] private float damageToDeliver;
        [SerializeField] private float timeBtwAttack=1f;

        private NavMeshAgent navAgent;
        private ZombieAnimationManager animationManager;
        private bool isAttacking;
        private float attackTimer;
        private Transform target;

        private void Awake()
        {
            navAgent = GetComponent<NavMeshAgent>();
            animationManager = GetComponent<ZombieAnimationManager>();
        }
        private void Start()
        {
            attackTimer = timeBtwAttack;
            target = PlayerService.Instance.playerTransform;
            if (target)
            {
                navAgent.SetDestination(target.position);
            }
        }
        private void Update()
        {
            animationManager.SetVelocity(Mathf.Abs(navAgent.velocity.magnitude));
            if(Vector3.Distance(transform.position,target.position)<2f && attackTimer<Time.time )
            {
                isAttacking = true;
                Attack();
            }
            else if(Vector3.Distance(transform.position, target.position) > 2f && isAttacking)
            {
                animationManager.SetCanAttack(false);
            }
        }
        private void Attack()
        {
            attackTimer = Time.time + timeBtwAttack;
            animationManager.SetCanAttack(true);
            isAttacking = false; ;
        }
    }
}