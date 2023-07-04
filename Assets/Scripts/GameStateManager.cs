using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu = null;

    public static GameStateManager instance;

    public static GameState state;

    public static void Pause()
    {
        state = GameState.Paused;

        if (instance.pauseMenu == null) return;

        Time.timeScale = 0f;
        instance.pauseMenu.SetActive(true);
        BackgroundMusic.instance.Pause();
    }

    public static void Resume()
    {
        state = GameState.Playing;

        if (instance.pauseMenu == null) return;

        Time.timeScale = 1f;
        instance.pauseMenu.SetActive(false);
        BackgroundMusic.instance.Resume();
    }

    public static void Reset()
    {
        // Get the index of the current active scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Reload the scene by loading it using its index
        SceneManager.LoadScene(currentSceneIndex);
    }

    public static void GameOver()
    {
        Debug.Log("started!!");
        state = GameState.Over;
        if (instance.pauseMenu == null) return;

        Time.timeScale = 0f;
        instance.pauseMenu.SetActive(true);
    }

    //[SerializeField]
    //private GameOverMenu gameOverMenu = null;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
