using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip eatEnemySound;
    [SerializeField]
    private AudioClip gameOverSound;
    [SerializeField]
    private AudioClip levelUpSound;

    private AudioSource audioSource;

    public static PlayerSound instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayEatSound()
    {
        this.audioSource.PlayOneShot(this.eatEnemySound);
    }

    public void PlayGameOverSound()
    {
        this.audioSource.PlayOneShot(this.gameOverSound);
    }

    public void PlayLevelUpSound()
    {
        this.audioSource.PlayOneShot(this.levelUpSound);
    }
}
