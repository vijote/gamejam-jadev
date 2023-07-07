using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardPlayer : MonoBehaviour
{
    // Speed constants
    [SerializeField]
    private float forwardSpeed = 10f;
    public float turnSpeed = 35f;



    // User input
    private float horizontalInput;
    private float verticalInput;


    private string state = State.Idle;
    public Animator playerAnimator;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        //override original Update
        HandlePlayerInput();

        MovePlayer();
        PlayAnimation();
    }


    private void HandlePlayerInput()
    { 
        // User input variables get their values from the user input
        this.verticalInput = Input.GetAxis("Vertical");
        this.horizontalInput = Input.GetAxis("Horizontal");

        if (this.horizontalInput != 0 || this.verticalInput != 0) this.state = State.Running;
        else this.state = State.Idle;
    }


    private void MovePlayer()
    {
        this.transform.Translate(verticalInput * Vector3.forward * forwardSpeed*Time.deltaTime);
        this.transform.Rotate(horizontalInput * Vector3.up*turnSpeed*Time.deltaTime);

    }


    protected void PlayAnimation()
    {
        this.playerAnimator.Play(AnimationDictionary.States[this.state]);
    }
}
