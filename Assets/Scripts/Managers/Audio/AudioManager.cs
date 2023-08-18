using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Independent Sources")]
    [SerializeField] private AudioSource audioSource, effectsSource;


    //Makes AudioManager Object not destroyed on scene changes
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
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
        effectsSource.PlayOneShot(clip);
    }

    //For playing music for once
    public void PlayMusic(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    //Mute-Unmute continuous sounds or musics
    public void ToggleMusic()
    {
        audioSource.mute = !audioSource.mute;
    }

    //Mute-Unmute sounds of effects
    public void ToggleEffects()
    {
        effectsSource.mute = !effectsSource.mute;
    }
}
