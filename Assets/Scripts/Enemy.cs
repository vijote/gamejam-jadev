using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private FieldOfView visibility;
    private NavMeshAgent agent;
    private GameObject player;
    private FishPlayer playerData;
    private Animator animator;

    private Size size;
    private string state = State.Idle;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.visibility = GetComponent<FieldOfView>();
        this.player = GameObject.Find("Player");
        this.agent = GetComponent<NavMeshAgent>();
        this.playerData = player.GetComponent<FishPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        // The current animation is "Attack" and the game is finishing
        if(this.state == State.Attack) return;

        // Follow the player if it's visible
        if (this.visibility.canSeePlayer)
        {
            this.state = State.Running;

            if (this.size > this.playerData.size)
            {
                this.agent.SetDestination(player.transform.position);
            } else
            {
                RunAway();
            }
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

    public void SetSize(Size newSize)
    {
        this.size = newSize;
    }

    private void RunAway()
    {
        Vector3 direction = transform.position - player.transform.position;
        Vector3 runToPosition = transform.position + direction.normalized * 5f; // Adjust the distance as needed

        agent.SetDestination(runToPosition);
    }

    private void EatPlayer()
    {
        FishPlayer player = GameObject.Find("Player").GetComponent<FishPlayer>();

        this.animator.Play(AnimationDictionary.States[this.state]);

        player.isAlive = false;
        player.playerAnimator.Play("Death");
    }

    private void PlayAnimation()
    {
        this.animator.Play(AnimationDictionary.States[this.state]);
    }
}
