using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;    //how close to the enemy do we get before the enemy start chasing
    [SerializeField] float turnSpeed = 5f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;    //player' and enemy' start distance
    bool isProvoked = false;
    EnemyHealth health;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
    }


    void Update()
    {
        if (health.IsDead()) //am i dead?
        {
            enabled = false; //turns off this enemy component, it can't attack but it doesn't stop the navMeshAgent
            navMeshAgent.enabled = false; //the navMeshAgent doesn't know it's death
        }

        else
        {
            distanceToTarget = Vector3.Distance(target.position, transform.position); //enemy position
        }

        if (isProvoked)
        {
            EngageTarget();
        }

        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    void EngageTarget()
    {
        FaceTarget();

        if (distanceToTarget >= navMeshAgent.stoppingDistance) //look at the inspector window, it s set to 3.5
        {
            ChaseTarget();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
    }

    //Delete animator's rotation in Enemy otherwise it's not working
     void FaceTarget()  //rotate dalek's weapon to target
     {
        // When normalized, a vector keeps the same direction but its length is 1.0.
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        // transform.rotation = where the target is, we need to rotate at a certain speed; our rotation, target rotation, speed
        // Slerp: Interpolates between a and b by amount t. The parameter t is clamped to the range [0, 1].
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);     //rotate nice and smoothly between two vectors; (current location, look rotation, time or speed)
     }

    // it shows chaseRange
    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
