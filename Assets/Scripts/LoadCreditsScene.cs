using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCreditsScene : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("Credits");
    }
}
