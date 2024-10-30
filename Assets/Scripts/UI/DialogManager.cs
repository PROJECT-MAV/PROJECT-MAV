using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Dialog
{
    public int sceneIndex;
    public bool isPlayerDialog;
    public string text;

    public Dialog(int sceneIndex, bool isPlayerDialog, string text)
    {
        this.sceneIndex = sceneIndex;
        this.isPlayerDialog = isPlayerDialog;
        this.text = text;
    }
}

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;
    [SerializeField] private List<Dialog> allDialogList = new List<Dialog>
    {
        new Dialog(1, true, "안녕!!"),
        new Dialog(1, true, "We are in 0-th scene."),
        new Dialog(1, true, "And player speaking.")
    };

    private Queue<Dialog> dialogQueue = new Queue<Dialog>(); // Dialog들이 담길 수 있는 큐

    [SerializeField] private TextMeshProUGUI dialogText;


    private void Awake()
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

    }

    public void EnqueueDialog()
    {
        foreach(var dialog in allDialogList)
        {
            dialogQueue.Enqueue(dialog); 
        }
        Debug.Log("Enqueue!");
    }

    public void ShowNextDialong()
    {
        if(dialogQueue.Count > 0)
        {
            Dialog dialog = dialogQueue.Dequeue();
            PrintDialog(dialog);
        }
        else Debug.Log("남은 대화가 없습니다!");
    }

    public void PrintDialog(Dialog dialog)
    {
        if(dialog.isPlayerDialog)
        {
            dialogText.text = "Player: " + "(" + dialog.sceneIndex + "-th scene)" + dialog.text;
        }
        else
        {
            dialogText.text = "NPC: " + "(" + dialog.sceneIndex + "-th scene)" + dialog.text;
        }
    }
  
}

