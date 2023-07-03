using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Speed constants
    [SerializeField]
    public float forwardSpeed = 10f;
    public float turnSpeed = 35f;

    private int score = 0;

    // User input
    private float horizontalInput;
    private float verticalInput;

    //Animator
    public Animator playerAnimator;
    public bool isAlive = true;
    public Size size = Size.Small;

    public static Player instance;


    [SerializeField] private int food;
    [SerializeField] private int goalFood;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        HandleSceneReload();

        if (!isAlive) return;

        HandlePlayerInput();

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
        // User input variables get their values from the user input
        this.verticalInput = Input.GetAxis("Vertical");
        this.horizontalInput = Input.GetAxis("Horizontal");

        PlayAnimation();
        MovePlayer();
    }

    private void HandleSceneReload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadScene();
            return;
        }
    }

    public void ReloadScene()
    {
        // Get the index of the current active scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Reload the scene by loading it using its index
        SceneManager.LoadScene(currentSceneIndex);
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

    public void IncrementScore(int newScore)
    {
        this.score += newScore;

        if (this.score > (int)SizeMaxScore.Large)
        {
            // Level clear
        }
        else if (this.score > (int)SizeMaxScore.Medium)
        {
            this.size = Size.Large;
            this.transform.localScale = new Vector3(2f, 2f, 2f);
            return;
        }
        else if (this.score > (int)SizeMaxScore.Small)
        {
            this.size = Size.Medium;
            this.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            return;
        }
    }

    public bool IsAbleToEvolve()
    {
        //despues hay q ponerse a fusionar esto con bichi
        return true;
    }
}
