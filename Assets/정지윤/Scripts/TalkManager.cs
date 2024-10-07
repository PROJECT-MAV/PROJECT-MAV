using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    int sceneIndex;
    public UIManager uiManager;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(0, new string[]{"Hello!", "We are in the first scene."});
        talkData.Add(1, new string[]{"Hi!", "We are in the second scene;"});
        // 앞의 정수는 scene number
    }

    public string GetTalkData(int sceneIndex, int talkIndex)
    {
        if(talkIndex == talkData[sceneIndex].Length)
            return null;
        else
            return talkData[sceneIndex][talkIndex];

        
    }
}
