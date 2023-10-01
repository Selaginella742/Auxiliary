using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyStates { GUARD, PATROL, CHASE, DEAD }
[RequireComponent(typeof(NavMeshAgent))]


public class EnemyController : MonoBehaviour
{
    private EnemyStates enemyStates;

    private NavMeshAgent agent;

    //private Animator anim; //For enemy's animation

    private Collider coll;

    private CharacterStats characterStats;

    [Header("Basic Settings")]
    public bool isGuard;
    bool isWalk;
    bool isChase;
    bool isFollow; //To determine if attack or continue chasing. Be careful when we make animation.
    bool isDeath;
    public GameObject bulletPrefab;
    public GameObject gunModel;
    public float lookAtTime; //The time enemy will wait in each patrol movement 
    private float remainLookAtTime;
    private float lastAttackTime;
    private Quaternion guardRotation;


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
        //anim = GetComponent<Animator>();
        characterStats = GetComponent<CharacterStats>();
        speed = agent.speed;
        guardPos = transform.position;
        guardRotation = transform.rotation;
        remainLookAtTime = lookAtTime;
        coll = GetComponent<Collider>();
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
        if (characterStats.CurrentHealth == 0)
        {
            isDeath = true;
        }

        SwitchStates();
        //SwitchAnimation();
        lastAttackTime -= Time.deltaTime;// Enemy attack CD

    }

    void SwitchAnimation()
    {
        //anim.SetBool("Walk", isWalk);
        //anim.SetBool("Chase", isChase);
        //anim.SetBool("Follow", isFollow);
        //anim.SetBool("Death", isDeath);
    }

    void SwitchStates()
    {
        if (isDeath)
        {
            enemyStates = EnemyStates.DEAD;
        }

        //if find player, switch to CHASE
        else if (FoundPlayer())
        {
            enemyStates = EnemyStates.CHASE;
        }


        switch (enemyStates)
        {
            case EnemyStates.GUARD:
                isChase = false;


                if (transform.position != guardPos)
                {
                    isWalk = true;
                    agent.isStopped = false;
                    agent.destination = guardPos;

                    if (Vector3.Distance(transform.position, guardPos) <= 5f)
                    {
                        isWalk = false;
                        transform.rotation = Quaternion.Lerp(transform.rotation, guardRotation, 0.01f);
                    }
                }

                break;
            case EnemyStates.PATROL:
                isChase = false;
                agent.speed = speed * 0.5f;


                if (Vector3.Distance(wayPoint, transform.position) <= agent.stoppingDistance)
                {
                    isWalk = false;
                    if (remainLookAtTime > 0) // Check if the time is 0
                        remainLookAtTime -= Time.deltaTime;
                    else
                        GetNewWayPoint();
                }
                else
                {
                    isWalk = true;
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
                    agent.isStopped = false;
                    agent.destination = attackTarget.transform.position;
                }

                if (TargetInAttackRange() || TargetInShootRange()) //Attack in their range
                {
                    isFollow = false;
                    agent.isStopped = true;

                    if (lastAttackTime < 0)
                    {
                        lastAttackTime = characterStats.attackData.coolDown;

                        characterStats.isCritical = Random.value < characterStats.attackData.criticalChance;
                        Attack();
                    }
                }

                break;
            case EnemyStates.DEAD:

                coll.enabled = false;
                agent.enabled = false;

                Destroy(gameObject, 1f);
                break;
        }
    }

    void Attack()
    {
        transform.LookAt(attackTarget.transform);
        if (TargetInAttackRange())
        {

        }
        if (TargetInShootRange())
        {
            Shoot();
            //anim.SetTrigger("Shoot");//Éä»÷¶¯»­
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

    bool TargetInAttackRange()
    {
        if (attackTarget != null)
            return Vector3.Distance(attackTarget.transform.position, transform.position) <= characterStats.attackData.attackRange;
        else
            return false;
    }

    bool TargetInShootRange()
    {
        if (attackTarget != null)
            return Vector3.Distance(attackTarget.transform.position, transform.position) <= characterStats.attackData.shootRange;
        else
            return false;
    }

    void GetNewWayPoint()
    {
        remainLookAtTime = lookAtTime;

        float randomX = Random.Range(-patrolRange, patrolRange);
        float randomZ = Random.Range(-patrolRange, patrolRange);

        Vector3 randomPoint = new Vector3(guardPos.x + randomX, transform.position.y, guardPos.z + randomZ);
        NavMeshHit hit;
        wayPoint = NavMesh.SamplePosition(randomPoint, out hit, patrolRange, 1) ? hit.position : transform.position; // Scan obstacle in front of enemy.
    }

    void Shoot()
    {
        GameObject shot = Instantiate(bulletPrefab, gunModel.transform.position, transform.rotation);
        var shotData = shot.GetComponent<IBullet>();

        if (shotData != null)
        {
            shotData.launchSource = LaunchSource.enemy;
            shotData.affectDamage = characterStats.attackData.damage;
        }
    }


    void OnDrawGizmosSelected() //Show the range that enemy see you with a yellow line sphere
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRadius);
    }
}

