using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public FieldOfView EnemyVisibility;
    public NavMeshAgent agent;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Follow the player if it's visible
        if (EnemyVisibility.canSeePlayer)
        {
            agent.SetDestination(player.position);
        }
    }
}
