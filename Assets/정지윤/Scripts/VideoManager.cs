using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class VideoManager : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Assign in inspector

    //videoPlayer.Play(); << 영상 재생
    //videoPlayer.Pause(); << 영상 멈춤
    // float volume = video.GetDirectAudioVolume(); << 영상 볼륨 가져오기
    
    public VideoClip[] videoClips;  // Assign video clips in the inspector

    private int currentVideoIndex = 0;

    void Start()
    {
        SetupVideoPlayer();
        videoPlayer.loopPointReached += onVideoEnd;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SkipToNextVideo();
        }

        // 영상 하나 끝나면 자동으로 다음거로 넘어가기 && 마지막 영상 이후 타이틀 화면으로 전환되도록 << 시간?
        
    }

    void SetupVideoPlayer()
    {
        if (videoClips.Length > 0)
        {
            videoPlayer.clip = videoClips[currentVideoIndex]; 
            videoPlayer.Play(); // 0번 인덱스 비디오 클립부터 재생
        }
    }

    void SkipToNextVideo()
    {
        if(currentVideoIndex == 4)
        {
            SceneManager.LoadScene("Title");
        }
        
        if (videoClips.Length > 0)
        {
            currentVideoIndex = (currentVideoIndex + 1) % videoClips.Length;
            videoPlayer.clip = videoClips[currentVideoIndex];
            videoPlayer.Play();
        }
    }

    void onVideoEnd(VideoPlayer vp)
    {
       if(currentVideoIndex == 4)
       {
            SceneManager.LoadScene("Title");
       }
       
       SkipToNextVideo();
    }
}