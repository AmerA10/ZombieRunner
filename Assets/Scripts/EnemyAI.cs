using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;//how close enemy to player to chase

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity; //initialized to a infinitely large number, measures the distance to the target
    bool isProvoked;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        
        distanceToTarget = Vector3.Distance(target.position, transform.position); //gets distance to target
        if(isProvoked)
        {
            EngageTarget();
        }
        else if(distanceToTarget <= chaseRange)
        {
            isProvoked = true;
            
        }

    }

    private void EngageTarget()
    {
        if(distanceToTarget > navMeshAgent.stoppingDistance)   
        {
            ChaseTarget();
        }
        if(distanceToTarget <= navMeshAgent.stoppingDistance)
        { 
            AttackTarget();
        }
    }
    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }
    private void AttackTarget()
    {
        Debug.Log("attacking target: " + target.name );
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, chaseRange);
    }
}
