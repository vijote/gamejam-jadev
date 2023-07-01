using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public FieldOfView EnemyVisibility;
    public NavMeshAgent agent;
    public Transform player;
    private bool eating = false;

    // Animator
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(eating) return;

        // Follow the player if it's visible
        if (this.EnemyVisibility.canSeePlayer)
        {
            agent.SetDestination(player.position);
        }
        this.PlayAnimation();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.eating = true;
            // Player has entered the enemy's trigger, perform the "eating" action
            EatPlayer();
        }
    }

    private void EatPlayer()
    {
        FishPlayer player = GameObject.Find("Player").GetComponent<FishPlayer>();
        Debug.Log("player eaten!!");
        animator.Play("Attack");

        player.isAlive = false;
        player.playerAnimator.Play("Death");
        // do some logic with the player
    }

    private void PlayAnimation()
    {
        if (this.EnemyVisibility.canSeePlayer)
        {
            this.animator.Play("Run");
        }
        else
        {
            this.animator.Play("Idle_A");
        }
    }
}
