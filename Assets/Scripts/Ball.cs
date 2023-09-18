using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] AudioClip paddleSound;
    [SerializeField] AudioClip blockSound;
    [SerializeField] AudioClip wallSound;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void PlaySound(AudioClip soundToPlay)
    {
        audioSource.clip = soundToPlay;
        audioSource.Play();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            PlaySound(blockSound);
        }
        else if (other.gameObject.CompareTag("Paddle"))
        {
            PlaySound(paddleSound);
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            PlaySound(wallSound);
        }
    }
}
