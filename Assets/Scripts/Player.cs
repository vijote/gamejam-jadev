using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Speed constants
    [SerializeField]
    private float forwardSpeed = 10f;
    public float turnSpeed = 35f;

    private int score = 0;

    // User input
    private float horizontalInput;
    private float verticalInput;

    public Animator playerAnimator;
    private string state = State.Idle;
    public Size size = Size.Small;

    public static Player instance;

    [SerializeField] private int food;
    [SerializeField] private int goalFood;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        instance = this;
        ProgressBar.instance.SetMaxProgress((int)SizeMaxScore.Small);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStateManager.state == GameState.Over) return;

        HandlePause();

        HandlePlayerInput();

        MovePlayer();

        CheckPlayableMovement();

        PlayAnimation();
    }

    private void CheckPlayableMovement()
    {
        // Calculate the boundaries of the playable area
        Vector3 minBound = PlayableArea.playableAreaCenter - PlayableArea.playableAreaSize / 2f;
        Vector3 maxBound = PlayableArea.playableAreaCenter + PlayableArea.playableAreaSize / 2f;

        // Clamp the player's position to the playable area boundaries
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minBound.x, maxBound.x),
            transform.position.y,
            Mathf.Clamp(transform.position.z, minBound.z, maxBound.z)
        );
    }

    private void HandlePlayerInput()
    {
        if (this.state == State.Dead) return;

        // User input variables get their values from the user input
        this.verticalInput = Input.GetAxis("Vertical");
        this.horizontalInput = Input.GetAxis("Horizontal");

        if (this.horizontalInput != 0 || this.verticalInput != 0) this.state = State.Running;
        else this.state = State.Idle;
    }

    private void HandlePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameStateManager.Pause();
        }
    }

    private void PlayAnimation()
    {
        this.playerAnimator.Play(AnimationDictionary.States[this.state]);
    }

    public static void Kill()
    {
        instance.state = State.Dead;
        instance.PlayAnimation();
    }

    private void MovePlayer()
    {
        // Calculate the movement direction based on input
        Vector3 inputDirection = new Vector3(this.horizontalInput, 0f, this.verticalInput).normalized;

        // Transform the input direction from local space to world space based on the camera's orientation
        Vector3 movementDirection = Camera.main.transform.TransformDirection(inputDirection);
        movementDirection.y = 0f; // Ignore any vertical component

        // Rotate the player to face the movement direction
        if (movementDirection.magnitude > 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            this.transform.rotation = targetRotation;
        }

        // Player moves forward relative to the camera's point of view
        this.transform.Translate(movementDirection * this.forwardSpeed * Time.deltaTime, Space.World);
    }


    public void IncrementScore(int newScore)
    {
        this.score += newScore;
        ProgressBar.instance.SetProgress(this.score);

        if (this.score > (int)SizeMaxScore.Large)
        {
            // Level clear
        }
        else if (this.size == Size.Medium && this.score > (int)SizeMaxScore.Medium)
        {
            this.size = Size.Large;
            PlayerSound.instance.PlayLevelUpSound();
            this.transform.localScale = new Vector3(2f, 2f, 2f);
            ProgressBar.instance.SetMaxProgress((int)SizeMaxScore.Large);
            return;
        }
        else if (this.size == Size.Small && this.score > (int)SizeMaxScore.Small)
        {
            this.size = Size.Medium;
            PlayerSound.instance.PlayLevelUpSound();
            this.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            ProgressBar.instance.SetMaxProgress((int)SizeMaxScore.Medium);
            return;
        }
    }

    public bool IsAbleToEvolve()
    {
        //despues hay q ponerse a fusionar esto con bichi
        return true;
    }
}
