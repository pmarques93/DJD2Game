﻿using UnityEngine;

/// <summary>
/// Class for SoundManager
/// </summary>
sealed public class SoundManager : MonoBehaviour
{
    // Sound Clips
    private static AudioClip[] sounds;

    // Variable to control audiosource
    private static AudioSource audioSource;

    /// <summary>
    /// Property for audiosource
    /// </summary>
    public AudioSource AudioSource { get => audioSource; 
                                    private set => audioSource = value; }

    /// <summary>
    /// Propert for SoundVolume. Controls volume
    /// </summary>
    public float SoundVolume { get; set; }

    /// <summary>
    /// Start method for sound manager
    /// </summary>
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();

        sounds = new AudioClip[4];

        sounds[0] = Resources.Load<AudioClip>("Sounds/footstep");
        sounds[1] = Resources.Load<AudioClip>("Sounds/walkmanAudio");
        sounds[2] = Resources.Load<AudioClip>("Sounds/flashlightClick");
        sounds[3] = Resources.Load<AudioClip>("Sounds/wallSlide");
    }

    /// <summary>
    /// Update method for sound manager
    /// </summary>
    private void Update()
    {
        AudioSource.volume = SoundVolume;
    }

    /// <summary>
    /// Plays a sound depending on the clip parameter
    /// </summary>
    /// <param name="clip">Sound to play</param>
    public static void PlaySound(SoundClip clip)
    {
        switch (clip)
        {
            case SoundClip.footstep:
                audioSource.PlayOneShot(sounds[0], 1f);
                break;
            case SoundClip.walkmanAudio:
                audioSource.PlayOneShot(sounds[1], 1f);
                break;
            case SoundClip.flashlightClick:
                audioSource.PlayOneShot(sounds[2], 1f);
                break;
            case SoundClip.wallSlide:
                audioSource.PlayOneShot(sounds[3], 1f);
                break;
        }
    }
}