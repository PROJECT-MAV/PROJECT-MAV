using UnityEngine;
using UnityEngine.EventSystems; // Required for event handling

public class HoverSound : MonoBehaviour, IPointerEnterHandler // Implement this interface to detect mouse hover
{
    public AudioSource audioSource; // Reference to the AudioSource

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play(); // Play the sound when the mouse hovers over the button
        }
    }
}