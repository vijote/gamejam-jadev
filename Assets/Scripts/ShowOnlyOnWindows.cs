using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnlyOnWindows : MonoBehaviour
{
    private void Start()
    {
        #if UNITY_STANDALONE_WIN
            // Code specific to the Windows platform
            // Enable or configure the component here
            GetComponent<Renderer>().enabled = true;

        #else
            // Code for other platforms
            // Disable or skip the component here
            gameObject.SetActive(false);
        #endif
    }
}
