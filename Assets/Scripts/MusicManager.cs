using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    AudioSource mainThemeMusic;


    void Start()
    {
        mainThemeMusic = GetComponent<AudioSource>();
        if (MusicCheck.instance.musicCheck.isOn)
        {
            mainThemeMusic.Play();
        }
    }

    void Update()
    {
        
    }
}
