using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnPlayButtonClick()
    {
        SceneManager.LoadScene("FishLevel");
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
}
