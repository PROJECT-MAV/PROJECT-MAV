using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required for UI elements interaction

public class PlaySoundOnClick : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource

    void Start()
    {
        // Get the button component and add a listener to its onClick event
        Button button = GetComponent<Button>();
        if (button != null && audioSource != null)
        {
            button.onClick.AddListener(PlaySound);
        }
    }

    // Method to play the sound
    void PlaySound()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play(); // Play the audio clip attached to the AudioSource
        }
    }
}
