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

        sounds = new AudioClip[10];

        sounds[0] = Resources.Load<AudioClip>("Sounds/footstep");
        sounds[1] = Resources.Load<AudioClip>("Sounds/walkmanAudio");
        sounds[2] = Resources.Load<AudioClip>("Sounds/flashlightClick");
        sounds[3] = Resources.Load<AudioClip>("Sounds/wallSlide");
        sounds[4] = Resources.Load<AudioClip>("Sounds/MajorAKeyNote");
        sounds[5] = Resources.Load<AudioClip>("Sounds/MajorCKeyNote");
        sounds[6] = Resources.Load<AudioClip>("Sounds/MajorEKeyNote");
        sounds[7] = Resources.Load<AudioClip>("Sounds/doorOpen");
        sounds[8] = Resources.Load<AudioClip>("Sounds/drawerOpen");
        sounds[9] = Resources.Load<AudioClip>("Sounds/drawerClosing");

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
            case SoundClip.Footstep:
                audioSource.PlayOneShot(sounds[0], 1f);
                break;
            case SoundClip.WalkmanAudio:
                audioSource.PlayOneShot(sounds[1], 1f);
                break;
            case SoundClip.FlashlightClick:
                audioSource.PlayOneShot(sounds[2], 1f);
                break;
            case SoundClip.WallSlide:
                audioSource.PlayOneShot(sounds[3], 1f);
                break;
            case SoundClip.MajorAKeyNote:
                audioSource.PlayOneShot(sounds[4], 0.4f);
                break;
            case SoundClip.MajorCKeyNote:
                audioSource.PlayOneShot(sounds[5], 0.4f);
                break;
            case SoundClip.MajorEKeyNote:
                audioSource.PlayOneShot(sounds[6], 0.4f);
                break;
            case SoundClip.DoorOpen:
                audioSource.PlayOneShot(sounds[7], 0.4f);
                break;
            case SoundClip.DrawerOpen:
                audioSource.PlayOneShot(sounds[8], 0.4f);
                break;

            case SoundClip.DrawerClosing:
                audioSource.PlayOneShot(sounds[9], 0.4f);
                break;
        }
    }
}
