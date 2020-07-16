using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float attackRange = 3f;
    NavMeshAgent navMeshAgent;
    bool isProvoked;
    float distanceToTarget = Mathf.Infinity;
    
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.stoppingDistance = attackRange;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position,transform.position);
        if (isProvoked)
        {
            //once engage, the enemy is not going to stop chasing the target
            EngageWithTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
            navMeshAgent.SetDestination(target.position);
        }
        
    }

    private void EngageWithTarget()
    {
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
        else
        {
            ChaseTarget();
        }
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack",true);
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("Attack",false);
        GetComponent<Animator>().SetTrigger("Move");
        navMeshAgent.SetDestination(target.position);
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
