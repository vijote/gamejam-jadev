using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    public float fieldOfViewAngle = 90f;
    public float detectionRange = 10f;


    private void Awake()
    {
        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate direction to the player
        Vector3 direction = player.position - transform.position;
        float angle = Vector3.Angle(transform.forward, direction);

        // Check if player is within the field of view and within detection range
        if (angle < fieldOfViewAngle * 0.5f && direction.magnitude < detectionRange)
        {
            // Check if there are no obstacles blocking the line of sight
            if (Physics.Raycast(transform.position, direction, out RaycastHit hit, detectionRange))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    // Player is within FOV and line of sight, move towards the player
                    enemy.SetDestination(player.position);
                }
            }
        }
    }
}
