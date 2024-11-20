using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource bgmSource;
    public AudioClip[] bgmClips;
    public AudioMixerGroup bgmMixerGroup;
    public AudioClip[] sfxClips;
    public int poolSize = 10; //풀의 크기
    private List<AudioSource> audioSourcePool; 
    public AudioMixerGroup sfxMixerGroup;
    public AudioMixer audioMixer;
    
    /*오디오소스 풀 리스트 << 해당 풀링 방식으로 
    인게임 내에서 여러 효과음들이 겹칠 때 하나의 오디오소스에 몰아넣어 생기는 잡음 등을 없애고 
    더 효율적인 메모리 사용을 위함*/
    
    //오디오믹서 변수 추가
    
    

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
        bgmSource.outputAudioMixerGroup = bgmMixerGroup;

        audioSourcePool = new List<AudioSource>();

        for (int i = 0; i < poolSize; i++)
        {
            AudioSource newSource = gameObject.AddComponent<AudioSource>();
            newSource.outputAudioMixerGroup = sfxMixerGroup;
            audioSourcePool.Add(newSource);
        }

        
    }

    public void PlayBgm(int index)
    {
        if(index >= 0 && index < bgmClips.Length)
        {
            bgmSource.clip = bgmClips[index];
            bgmSource.Play();
        }
    }

    public void StopBgm()
    {
        bgmSource.Stop();
    }

    private AudioSource GetAvailableAudioSource()
    {
        foreach(var source in audioSourcePool)
        {
            if(!source.isPlaying) return source;
        }

        return null;
    }

    public void PlaySfx(int index)
    {
        if(index >= 0 && index < sfxClips.Length)
        {
            AudioSource availableSource = GetAvailableAudioSource();
            if(availableSource != null) availableSource.PlayOneShot(sfxClips[index]);
            
            else Debug.LogWarning("No available AudioSource in Pool");
        }
    }
   
}

