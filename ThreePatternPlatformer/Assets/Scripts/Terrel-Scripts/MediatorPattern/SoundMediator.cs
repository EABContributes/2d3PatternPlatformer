//Written By Terrel
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SoundMediator : MonoBehaviour
{
    public static SoundMediator Instance;

    [Header("Audio Sources")]
    public AudioSource jumpSound;
    public AudioSource deathSound;
    public AudioSource alarmSound;
    public AudioSource StompSound;
    void Awake()
    {
        if (Instance  == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayJumpSound()
    {
        if (jumpSound != null) jumpSound.Play();
    }
    public void PlayDeathSound()
    {
        if (deathSound != null) deathSound.Play();
    }
    public void PlayAlarmSound()
    {
        if (alarmSound != null) alarmSound.Play();
    }
    public void PlayStompSound()
    {
        if(StompSound != null) StompSound.Play();
    }
}
