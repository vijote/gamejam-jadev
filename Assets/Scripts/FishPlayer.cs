using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPlayer : MonoBehaviour
{
    // Speed constants
    public float forwardSpeed = 10f;
    public float turnSpeed = 35f;

    // User input
    private float horizontalInput;
    private float verticalInput;

    //Animator
    public Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HandlePlayerInput();
    }

    private void HandlePlayerInput()
    {
        // User input variables get their values from the user input
        this.verticalInput = Input.GetAxis("Vertical");
        this.horizontalInput = Input.GetAxis("Horizontal");

        PlayAnimation();
        MovePlayer();
    }

    private void PlayAnimation()
    {
        if (this.verticalInput != 0)
        {
            this.playerAnimator.Play("Swim");
        }
        else
        {
            this.playerAnimator.Play("Idle_A");
        }
    }

    private void MovePlayer()
    {
        // Player moves forward
        this.transform.Translate(this.forwardSpeed * Time.deltaTime * this.verticalInput * Vector3.forward);


        // Player rotates sideways
        this.transform.Rotate(this.horizontalInput * this.turnSpeed * Time.deltaTime * Vector3.up);
    }
}
