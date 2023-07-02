using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private FieldOfView visibility;
    private NavMeshAgent agent;
    private GameObject player;
    private Size size;
    private State state;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.visibility = GetComponent<FieldOfView>();
        this.player = GameObject.Find("Player");
        this.agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // The current animation is "Attack" and the game is finishing
        if(this.state == State.Attack) return;

        // Follow the player if it's visible
        if (this.visibility.canSeePlayer)
        {
            this.agent.SetDestination(player.transform.position);
        }
        this.PlayAnimation();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.state = State.Attack;
            // Player has entered the enemy's trigger, perform the "eating" action
            EatPlayer();
        }
    }

    private void EatPlayer()
    {
        FishPlayer player = GameObject.Find("Player").GetComponent<FishPlayer>();

        this.animator.Play("Attack");

        player.isAlive = false;
        player.playerAnimator.Play("Death");
    }

    private void PlayAnimation()
    {
        if (this.visibility.canSeePlayer)
        {
            this.animator.Play("Run");
        }
        else
        {
            this.animator.Play("Idle_A");
        }
    }
}
