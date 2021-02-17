using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;//how close enemy to player to chase
    private Animator animator;
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity; //initialized to a infinitely large number, measures the distance to the target
    bool isProvoked;
    EnemyHealth health;

    [SerializeField] float turnSpeed = 5f;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
    }

    
    void Update()
    {
        
        if(health.GetIsDead())
        {
            this.enabled = false;
            navMeshAgent.enabled = false;
            isProvoked = false;
        }
        distanceToTarget = Vector3.Distance(target.position, transform.position); //gets distance to target
        if(isProvoked)
        {
            EngageTarget();
        }
        else if(distanceToTarget <= chaseRange)
        {
            isProvoked = true;
            
        }
        else if(distanceToTarget > chaseRange)
        {
            isProvoked = false;
        }

    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void EngageTarget()
    {
        FaceTarget();
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
        animator.SetBool("attack", false);
        animator.SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }
    private void AttackTarget()
    {
        animator.SetBool("attack", true);
        Debug.Log("attacking target: " + target.name );
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, chaseRange);
    }
    private void FaceTarget()
    {
        //rotates towards the target
        //tranform.rotation = our rotation -> target rotation(target position) -> at a speed
        Vector3 direction = (target.position - transform.position).normalized; //gives back direction only basically
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z)); //creates rotation that is towards the player
        transform.rotation = Quaternion.Slerp(this.transform.rotation, lookRotation, Time.deltaTime * turnSpeed); //spherical interpeerlation between the current rotation and the 
        //target rotation
    }
}
