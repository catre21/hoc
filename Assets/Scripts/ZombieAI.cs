using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    [Header("Player")]
    public Transform player;

    [Header("Range")]
    public float detectRange = 15f;
    public float attackRange = 2f;

    [Header("Patrol")]
    public float patrolRadius = 10f;
    public float patrolWaitTime = 3f;

    private NavMeshAgent agent;
    private Animator anim;

    private Vector3 spawnPoint;
    private Vector3 patrolPoint;

    private float patrolTimer;
    private float nextAttackTime;

    public float attackCooldown = 1f;
    public int damage = 10;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();

        spawnPoint = transform.position;

        GameObject p = GameObject.FindGameObjectWithTag("Player");

        if (p != null)
        {
            player = p.transform;
        }

        SetNewPatrolPoint();
    }

    void Update()
    {
        if (player == null)
        {
            Patrol();
            return;
        }

        float distance =
            Vector3.Distance(transform.position, player.position);

        // Phát hiện người chơi
        if (distance <= detectRange)
        {
            ChasePlayer(distance);
        }
        else
        {
            Patrol();
        }
    }

    void ChasePlayer(float distance)
    {
        agent.isStopped = false;
        agent.SetDestination(player.position);

        anim.SetBool("isWalking", true);

        if (distance <= attackRange)
        {
            Attack();
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
    }

    void Attack()
    {
        agent.isStopped = true;

        anim.SetBool("isAttacking", true);

        if (Time.time < nextAttackTime)
            return;

        nextAttackTime = Time.time + attackCooldown;

        PlayerHealth hp = player.GetComponent<PlayerHealth>();

        if (hp != null)
        {
            hp.TakeDamage(damage);
        }

        Debug.Log("Zombie đang tấn công!");
    }

    void Patrol()
    {
        anim.SetBool("isAttacking", false);

        patrolTimer += Time.deltaTime;

        if (patrolTimer >= patrolWaitTime ||
            Vector3.Distance(transform.position, patrolPoint) < 1f)
        {
            SetNewPatrolPoint();
            patrolTimer = 0f;
        }

        agent.isStopped = false;
        agent.SetDestination(patrolPoint);

        anim.SetBool("isWalking", true);
    }

    void SetNewPatrolPoint()
    {
        Vector3 randomPoint =
            spawnPoint +
            new Vector3(
                Random.Range(-patrolRadius, patrolRadius),
                0,
                Random.Range(-patrolRadius, patrolRadius)
            );

        NavMeshHit hit;

        if (NavMesh.SamplePosition(
            randomPoint,
            out hit,
            patrolRadius,
            NavMesh.AllAreas))
        {
            patrolPoint = hit.position;
        }
    }
}