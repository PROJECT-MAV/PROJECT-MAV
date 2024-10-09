using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Button myButton;
    public AudioManager audioManager;

    void Start()
    {
        myButton.onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        audioManager.PlaySfx(0);
    }
}
