using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public Transform Player;
    public float chaseRange;
    public float attackRange;
    private NavMeshAgent agent;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (Player == null)
        {
            Debug.LogError("chưa gán player!");
        }
    }
    private void Update()
    {
        if (Player == null)return;
        float distance = Vector3.Distance(transform.position, Player.position);
        if (distance <= chaseRange )
        {
            agent.SetDestination(Player.position);
            if (distance <= attackRange)
            {
                Attack();
            }
        }
    }
    private void Attack()
    {
        agent.isStopped = true;
        Debug.Log("zombie đang tấn công!");
    }
}
