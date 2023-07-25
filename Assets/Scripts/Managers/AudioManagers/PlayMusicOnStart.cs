using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicOnStart : MonoBehaviour
{
    [Header("Main Menu Music")]
    [SerializeField] private AudioClip clip;

    //Makes Music Starts When Game is Launched
    void Start()
    {
       AudioManager.instance.PlayMusic(clip);
    }
}
