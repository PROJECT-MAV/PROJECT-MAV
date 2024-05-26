using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    public void ChangeSceneBtn()
    {
        switch(this.gameObject.name)
        {
            case "NewGameBtn":
            SceneManager.LoadScene("NewGame");
            break;

            case "LoadBtn":
            SceneManager.LoadScene("Load");
            break;

            case "OptionBtn":
            SceneManager.LoadScene("Option");
            break;

            case "Back":
            SceneManager.LoadScene("MainMenu");
            break;

            case "SkipBtn":
            SceneManager.LoadScene("Title");
            break;

            case "StartBtn":
            SceneManager.LoadScene("MainMenu");
            break;

        }
    }
}
