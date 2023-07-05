using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject resumeButton;
    [SerializeField]
    private GameObject gameOverText;

    private void OnEnable()
    {
        resumeButton.SetActive(GameStateManager.state == GameState.Paused);
        gameOverText.SetActive(GameStateManager.state == GameState.Over);
    }

    private void Update()
    {
        if (GameStateManager.state == GameState.Over) return;

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            OnResumeButtonClick();
        }
    }

    public void OnResumeButtonClick()
    {
        GameStateManager.Resume();
    }

    public void OnResetButtonClick()
    {
        GameStateManager.Reset();
        GameStateManager.Resume();
    }


    public void OnMainMenuButtonClick()
    {
        GameStateManager.Resume();
        SceneManager.LoadScene("MainMenu");
    }
}
