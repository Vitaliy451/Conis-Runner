using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicCheck : MonoBehaviour
{
    public static MusicCheck instance;

    public Toggle musicCheck;

    public Toggle sfxCheck;

    public AudioSource musicSource;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void Start()
    {
        
        musicCheck.onValueChanged.AddListener(delegate
        {
            Control(musicCheck);
        });
    }
    public void Control(Toggle musicCheck)
    {
        if (musicCheck.isOn == true 
            && SceneManager.GetActiveScene().buildIndex == 0)
        {
            musicSource.Play();
        }
        else if(musicCheck.isOn == false
            && SceneManager.GetActiveScene().buildIndex == 0)
        {
            musicSource.Stop();
        }
    }
}
