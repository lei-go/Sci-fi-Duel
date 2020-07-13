using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    NavMeshAgent navMeshAgent;
    bool isProvoked;
    float distanceToTarget = Mathf.Infinity;
    
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
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
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            chaseTarget();
        }
        else
        {
            attackTarget();
        }
    }

    private void attackTarget()
    {
        Debug.Log(name + " is attacking " + target.name);
    }

    private void chaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
