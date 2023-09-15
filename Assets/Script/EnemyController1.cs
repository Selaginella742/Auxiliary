using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyStates {GUARD,PATROL,CHASE,DEAD}
[RequireComponent(typeof(NavMeshAgent))]


public class EnemyController : MonoBehaviour
{
    private EnemyStates enemyStates;

    private NavMeshAgent agent;

    private Animator anim; //For enemy's animation

    [Header("Basic Settings")]
    public bool isGuard;
    bool isWalk;
    bool isChase;
    bool isFollow; //To determine if attack or continue chasing. Be careful when we make animation.
    public float lookAtTime; //The time enemy will wait in each patrol movement 
    private float remainLookAtTime;


    public float sightRadius;
    private float speed;
    private GameObject attackTarget;

    [Header("Patrol State")]
    public float patrolRange;
    private Vector3 wayPoint;
    private Vector3 guardPos; //Initial position of enemy.




    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        speed = agent.speed;
        guardPos = transform.position;
        remainLookAtTime = lookAtTime;
    }

    void Start()
    {
        if (isGuard)
        {
            enemyStates = EnemyStates.GUARD;
        }
        else
        {
            enemyStates = EnemyStates.PATROL;
            GetNewWayPoint();
        }
    }

    void Update()
    {
        SwitchStates();
        SwitchAnimation();
    }

    void SwitchAnimation()
    {
        anim.SetBool("Walk", isWalk);
        anim.SetBool("Chase", isChase);
        anim.SetBool("Follow", isFollow);
    }

    void SwitchStates()
    {
        //if find player, switch to CHASE
        if (FoundPlayer())
        {
            enemyStates = EnemyStates.CHASE;
        }


        switch (enemyStates)
        {
            case EnemyStates.GUARD:
                break;
            case EnemyStates.PATROL:
                isChase = false;
                agent.speed = speed * 0.5f;


                if(Vector3.Distance(wayPoint, transform.position) <= agent.stoppingDistance)
                {
                    isWalk = false;
                    if (remainLookAtTime > 0) // Check if the time is 0
                        remainLookAtTime -= Time.deltaTime;
                    else
                        GetNewWayPoint();
                }
                else
                {
                    isWalk=true;
                    agent.destination = wayPoint;
                }

                break;
            case EnemyStates.CHASE:
                //TODO:Chase player

                //TODO:Attack in range
                //TODO:Animation

                isWalk = false;
                isChase = true;
                agent.speed = speed;
                if (!FoundPlayer())
                {
                   
                    isFollow = false;
                    if (remainLookAtTime > 0) //Back to last state
                    {
                        agent.destination = transform.position;
                        remainLookAtTime -= Time.deltaTime;
                    }

                    else if (isGuard)
                        enemyStates = EnemyStates.GUARD;
                    else
                        enemyStates = EnemyStates.PATROL;
                }
                else
                {
                    isFollow = true;
                    agent.destination = attackTarget.transform.position;
                }

                break;
            case EnemyStates.DEAD:
                break;
        }
    }

    bool FoundPlayer()
    {
        var colliders = Physics.OverlapSphere(transform.position, sightRadius);

        foreach (var target in colliders)
        {
            if (target.CompareTag("Player"))
            {
                attackTarget = target.gameObject;
                return true;
            }
        }

        attackTarget = null;
        return false;

    }

    void GetNewWayPoint()
    {
        remainLookAtTime = lookAtTime;

        float randomX = Random.Range(-patrolRange, patrolRange);
        float randomZ = Random.Range(-patrolRange, patrolRange);

        Vector3 randomPoint = new Vector3(guardPos.x + randomX, transform.position.y, guardPos.z + randomZ);
        NavMeshHit hit;
        wayPoint = NavMesh.SamplePosition(randomPoint, out hit, patrolRange, 1) ? hit.position: transform.position ; // Scan obstacle in front of enemy.
    }


    void OnDrawGizmosSelected() //Show the range that enemy see you with a yellow line sphere
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRadius);
    }
}

