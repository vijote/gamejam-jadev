using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip backgroundMusic;

    private AudioSource audioSource;

    public static BackgroundMusic instance;

    private void Start()
    {
        instance = this;

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void StopPlaying()
    {
        audioSource.Stop();
    }
}
