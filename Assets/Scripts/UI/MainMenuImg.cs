using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MainMenuImg : MonoBehaviour
{
    public Image img;
    public Sprite[]  Sprites;
     private int currentImageIndex = 0;

     
     

     [SerializeField] float timer;
     [SerializeField] float waitingTime;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        waitingTime = 2.0f;
        img = GetComponent<Image>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > waitingTime)
        {
            ChangeImage();
            timer = 0;
        }
    }
    void ChangeImage()
    {
        // 인덱스 가지고 코드 짜기
        if(Sprites.Length > 0)
        {
        currentImageIndex = (currentImageIndex + 1) % Sprites.Length;
        img.sprite = Sprites[currentImageIndex];
        }
    }
}
