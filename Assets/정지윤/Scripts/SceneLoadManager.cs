using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadNextScene()
    {
        int nextSceneIndex = currentSceneIndex + 1;

        int totalSceneNumber = SceneManager.sceneCountInBuildSettings;

        if(nextSceneIndex < totalSceneNumber)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    public void LoadPreviousScene()
    {
        int prevSceneIndex = currentSceneIndex - 1;

        if(prevSceneIndex >= 0)
        {
            SceneManager.LoadScene(prevSceneIndex);
        }
    }
    

}
