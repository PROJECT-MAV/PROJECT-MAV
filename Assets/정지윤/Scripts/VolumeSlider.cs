using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private Slider volumeslider;

    void Start()
    {
        volumeslider = GetComponent<Slider>();
        volumeslider.value = AudioManager.instance.GetComponent<AudioSource>().volume;
        volumeslider.onValueChanged.AddListener(SetVolume);
    }

    void SetVolume(float volume)
    {
        AudioManager.instance.SetVolume(volume);
    }
}