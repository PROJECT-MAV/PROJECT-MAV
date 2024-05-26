using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    public static AudioManager instance;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }

        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
    
}
