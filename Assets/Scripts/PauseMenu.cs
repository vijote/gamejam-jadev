using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private void Update()
    {
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
