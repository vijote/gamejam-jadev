using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPlayer : MonoBehaviour
{
    // Speed constants
    public float forwardSpeed = 10f;
    public float turnSpeed = 35f;

    // User input
    protected float horizontalInput;
    protected float verticalInput;

    //Animator
    public Animator playerAnimator;
    public bool isAlive = true;
    public Size size;


    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) return;

        HandlePlayerInput();

        // Calculate the boundaries of the playable area
        Vector3 minBound = PlayableArea.playableAreaCenter - PlayableArea.playableAreaSize / 2f;
        Vector3 maxBound = PlayableArea.playableAreaCenter + PlayableArea.playableAreaSize / 2f;

        // Clamp the player's position to the playable area boundaries
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minBound.x, maxBound.x),
            Mathf.Clamp(transform.position.y, minBound.y, maxBound.y),
            Mathf.Clamp(transform.position.z, minBound.z, maxBound.z)
        );

         
    }

    protected void HandlePlayerInput()
    {
        // User input variables get their values from the user input
        this.verticalInput = Input.GetAxis("Vertical");
        this.horizontalInput = Input.GetAxis("Horizontal");

        PlayAnimation();
        MovePlayer();
    }

    protected void PlayAnimation()
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

    protected void MovePlayer()
    {
        // Player moves forward
        this.transform.Translate(this.forwardSpeed * Time.deltaTime * this.verticalInput * Vector3.forward);


        // Player rotates sideways
        this.transform.Rotate(this.horizontalInput * this.turnSpeed * Time.deltaTime * Vector3.up);
    }

    public bool IsAbleToEvolve()
    {
        //despues hay q ponerse a fusionar esto con bichi
        return true;
    }
}
