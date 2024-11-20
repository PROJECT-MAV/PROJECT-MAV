using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Dialog
{
    public int sceneIndex;
    public bool isPlayerDialog;
    public string text;
    public string name;
    public Dialog(int sceneIndex, bool isPlayerDialog, string text, string name)
    {
        this.sceneIndex = sceneIndex;
        this.isPlayerDialog = isPlayerDialog;
        this.text = text;
        this.name = name;
    }
}

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;
    [SerializeField] private List<Dialog> allDialogList = new List<Dialog>
    {
        new Dialog(1, true, "안녕하세요!!", "장득출"),
        new Dialog(1, false, "In 1-th scene.", "장득출"),
        new Dialog(1, true, "And player speaking.", "장득출"),
        new Dialog(2, true, "In 2-th scene.", "장득출"),
        new Dialog(2, false, "And NPC speaking.", "장득출"),
        new Dialog(3, true, "In 3-th scene.", "장득출"),
    };

    private Queue<Dialog> dialogQueue = new Queue<Dialog>(); // Dialog들이 담길 수 있는 큐

    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private TextMeshProUGUI nameTagText;
  
    public GameObject playerPortrait;
    public GameObject npcPortrait;
    public GameObject nameTag;    
    public GameObject dialogSet;
    public bool isTalking;

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
        isTalking = false;
        dialogSet.SetActive(isTalking);
    }

    public void EnqueueDialog()
    {
        dialogQueue.Clear();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        foreach(var dialog in allDialogList)
        {
            if(dialog.sceneIndex == currentSceneIndex)
                dialogQueue.Enqueue(dialog); 

            else if(dialog.sceneIndex > currentSceneIndex) break;
        }
        Debug.Log("Enqueue!");
    }

    public void ShowNextDialong()
    {
        isTalking = true;

        if(dialogQueue.Count > 0)
        {
            dialogSet.SetActive(isTalking);
            Dialog dialog = dialogQueue.Dequeue();
            PrintDialog(dialog);
            if(dialog.isPlayerDialog)
            {
                playerPortrait.SetActive(true);
                npcPortrait.SetActive(false);
            }
            else
            {
                npcPortrait.SetActive(true);
                playerPortrait.SetActive(false);
            }
        }
        else
        {
            Debug.Log("남은 대화가 없습니다!");
            isTalking = false;
            dialogSet.SetActive(isTalking);

        }
    }

    public void PrintDialog(Dialog dialog)
    {
    
        dialogText.text = dialog.text;
    
        nameTagText.text = dialog.name;
       
    }
  
}

