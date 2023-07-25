using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Independent Sources")]
    [SerializeField] private AudioSource _audioSource, _effectsSource;


    //Makes AudioManager Object not destroyed on scene changes
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        else
        {
            Destroy(gameObject);
        }

        ChangeMasterVolume(0.3f);
    }

    //For Changing Volume
    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }

    //For playing effects just once
    public void PlaySound(AudioClip clip)
    {
        _effectsSource.PlayOneShot(clip);
    }

    //For playing music for once
    public void PlayMusic(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }

    //Mute-Unmute continuous sounds or musics
    public void ToggleMusic()
    {
        _audioSource.mute = !_audioSource.mute;
    }

    //Mute-Unmute sounds of effects
    public void ToggleEffects()
    {
        _effectsSource.mute = !_effectsSource.mute;
    }
}
