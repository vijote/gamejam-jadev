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
    private Animator animator;

    public Size size;
    private string state = State.Idle;
    private bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.visibility = GetComponent<FieldOfView>();
        this.player = GameObject.Find("Player");
        this.visibility.playerRef = player;
        this.agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Enemy is dead
        if (!this.isAlive) {
            return;
        }

        // The current animation is "Attack" and the game is finishing
        if (this.state == State.Attacking)
        {
            this.PlayAnimation();
            return;
        };

        // Follow the player if it's visible
        if (this.visibility.canSeePlayer)
        {
            this.state = State.Running;

            if (this.size > Player.instance.size)
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
        if (other.CompareTag("Limits"))
        {
            DestroySelf();
            return;
        }
        if (!other.CompareTag("Player")) return;

        if(this.size > Player.instance.size && Player.instance.isAlive)
        {
            EatPlayer();
        } else
        {
            RemoveSelf();
        }
    }

    public void SetSize(Size newSize)
    {
        this.size = newSize;
    }

    private void RemoveSelf()
    {
        // Stop other events from happening
        this.state = State.Dead;
        this.isAlive = false;

        // Play animation
        PlayerSound.instance.PlayEatSound();
        animator.Play(AnimationDictionary.States[this.state]);
        AnimationClip deathAnimation = animator.GetCurrentAnimatorClipInfo(0)[0].clip;
        float deathAnimationDuration = deathAnimation.length;

        // Add points to the enemy score
        Player.instance.IncrementScore((int)ScoreDictionary.Scores[this.size]);

        // Remove entity after the animation is done
        StopAllCoroutines();
        Invoke(nameof(DestroySelf), deathAnimationDuration);
    }

    private void DestroySelf()
    {
        EnemyManager.instance.RemoveEnemy(this);
        Destroy(this.gameObject);
    }

    private void RunAway()
    {
        Vector3 direction = transform.position - player.transform.position;
        Vector3 runToPosition = transform.position + direction.normalized * 5f; // Adjust the distance as needed

        agent.SetDestination(runToPosition);
    }

    private void EatPlayer()
    {

        this.state = State.Attacking;
        Player.instance.isAlive = false;
        Player.instance.playerAnimator.Play("Death");
        BackgroundMusic.instance.StopPlaying();
        PlayerSound.instance.PlayGameOverSound();
    }

    private void PlayAnimation()
    {
        this.animator.Play(AnimationDictionary.States[this.state]);
    }
}
