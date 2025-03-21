using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{   
    public static UIManager instance;
    public AudioMixer audioMixer;
    public Slider bgmVolumeSlider;
    public Slider sfxVolumeSlider;

    public TalkManager talkManager;
    public TextMeshProUGUI talkText;
    public GameObject talkSet;
    public Image portraitImage;
    public bool isTalking;

    public GameObject optionPanel;
    public bool isOptionPanelOn;
    public SceneLoadManager sceneLoadManager;
    public int talkIndex;

    

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        float bgmVolume;
        audioMixer.GetFloat("BgmVolume", out bgmVolume);
        bgmVolumeSlider.value = Mathf.Pow(10, bgmVolume / 20);

        float sfxVolume;
        audioMixer.GetFloat("SfxVolume", out sfxVolume);
        sfxVolumeSlider.value = Mathf.Pow(10, sfxVolume / 20);

        bgmVolumeSlider.onValueChanged.AddListener(SetBgmVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSfxVolume);
        
        isTalking = false;
        isOptionPanelOn = false;
        optionPanel.SetActive(isOptionPanelOn);

    }

    public void SetOptionPanelOn()
    {
        if(isOptionPanelOn == false)
            {
                isOptionPanelOn = true;
                optionPanel.SetActive(isOptionPanelOn);
            }

            else
            {
                isOptionPanelOn = false;
                optionPanel.SetActive(isOptionPanelOn);
            }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isOptionPanelOn == false)
            {
                isOptionPanelOn = true;
                optionPanel.SetActive(isOptionPanelOn);
            }

            else
            {
                isOptionPanelOn = false;
                optionPanel.SetActive(isOptionPanelOn);
            }
        }
    }

    public void SetBgmVolume(float volume)
    {
        if(volume == 0)
        {
            audioMixer.SetFloat("BgmVolume", -80f);
        }
        else audioMixer.SetFloat("BgmVolume", Mathf.Log10(volume) * 20);
    }
    
    public void SetSfxVolume(float volume)
    {
        if(volume == 0)
        {
            audioMixer.SetFloat("SfxVolume", -80f);
        }
        audioMixer.SetFloat("SfxVolume", Mathf.Log10(volume) * 20);
    }

}
