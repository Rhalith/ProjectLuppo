using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicOnStart : MonoBehaviour
{
    [Header("Main Menu Music")]
    [SerializeField] private AudioClip clip;
    void Start()
    {
       AudioManager.instance.PlayMusic(clip);
    }
}
