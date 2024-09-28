using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class StalkerScript : MonoBehaviour
{

    [Header("Enemy Settings")]
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private float _detectRadius = 20f;
    [SerializeField] private float _attackRange = 2f;
    [SerializeField] private LayerMask _targetLayerMask;

    [Header("Attack")]
    [SerializeField] private float _attackCooldown = 3f;
    [SerializeField] private int _damage = 10;

    private Transform player;
    private NavMeshAgent agent;  // NavMesh agent for pathfinding
    private bool isPlayerDetected = false;
    private float lastAttackTime;

    void Start()
    {
        // Locate the player object by tag or reference
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = _moveSpeed; // Set movement speed
    }

    void Update()
    {
        DetectPlayer();

        if (isPlayerDetected)
        {
            ChasePlayer();
            if (Vector3.Distance(transform.position, player.position) <= _attackRange)
            {
                AttackPlayer();
            }
        }
    }

    // Detect the player within a radius and line of sight
    private void DetectPlayer()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _detectRadius, _targetLayerMask);

        foreach (var hit in hits)
        {
            if (hit.transform.CompareTag("Player"))
            {
                isPlayerDetected = true;
                return;
            }
        }

        isPlayerDetected = false;
    }

    // Chase the player using NavMeshAgent pathfinding
    private void ChasePlayer()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
        }
    }

    // Handle attacking the player when in range
    private void AttackPlayer()
    {
        if (Time.time - lastAttackTime >= _attackCooldown)
        {
            // Inflict damage or trigger a scare event
            ////PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            //if (playerHealth != null)
            //{
            //    playerHealth.TakeDamage(_damage);
            //}

            lastAttackTime = Time.time;  // Reset attack timer
        }
    }

    // Draw gizmos to visualize detection radius in the editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = UnityEngine.Color.red;
        Gizmos.DrawWireSphere(transform.position, _detectRadius);
    }
}
