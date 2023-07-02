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

    public Size size;
    private string state = State.Idle;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.visibility = GetComponent<FieldOfView>();
        this.player = GameObject.Find("Player");
        this.visibility.playerRef = player;
        this.agent = GetComponent<NavMeshAgent>();
        this.playerData = player.GetComponent<FishPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        // The current animation is "Attack" and the game is finishing
        if(this.state == State.Attacking) return;

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
        } else
        {
            this.state = State.Idle;
        }

        this.PlayAnimation();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision!!");
        if (other.CompareTag("Player"))
        {
            this.state = State.Attacking;
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

        player.isAlive = false;
        player.playerAnimator.Play("Death");
    }

    private void PlayAnimation()
    {
        this.animator.Play(AnimationDictionary.States[this.state]);
    }
}
