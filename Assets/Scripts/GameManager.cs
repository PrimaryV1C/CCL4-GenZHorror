using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    private int narrativeProgression;
    [SerializeField]
    private GameObject bedroomDoor;

    [SerializeField]
    private GameObject moveSystem;
    public UnityEvent<EndingItem> doctorDialogueEnd;
    public UnityEvent taskCompleted;
    [SerializeField]
    private PlayerDetection playerDetectionScene2;
        [SerializeField]
    private PlayerDetection playerDetectionScene1;

    private Calendar calendar;

    [SerializeField]
    private GameObject endGameColliders;

    void Start()
    {   
        Debug.Log(moveSystem);
        calendar = FindAnyObjectByType<Calendar>();
        narrativeProgression = 0;
    }

    public void OnDialogueStarted(){
        if(narrativeProgression == 0) playerDetectionScene1.disablePrompt = true;
        if(narrativeProgression == 2 )//playerDetectionScene2.disablePrompt = true;
        moveSystem.SetActive(false);
    }

    public void OnDialogueEnded(){
        narrativeProgression++;
        if(narrativeProgression == 3) endGameColliders.gameObject.SetActive(true);
    }

    public void OnItemDelivered(){

        playerDetectionScene2.disablePrompt = false;

    }

    public void OnPhoneGrabbed(){
        
        playerDetectionScene1.disablePrompt = false;
        playerDetectionScene1.playerDetectedChange.Invoke(true);
        calendar.OnTaskCompletion();
    }

}
