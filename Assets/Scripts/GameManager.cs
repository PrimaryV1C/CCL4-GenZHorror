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

    [SerializeField]
    private Calendar calendar;

    [SerializeField]
    private GameObject endGameColliders;

    void Start()
    {
        narrativeProgression = 0;
    }

    public void OnDialogueStarted()
    {
        if (narrativeProgression == 0) calendar.OnTodo(1);
        if (narrativeProgression == 1) calendar.OnTodo(2);
        moveSystem.SetActive(false);
    }

    public void OnDialogueEnded()
    {
        narrativeProgression++;
        if (narrativeProgression == 3)
        {
            endGameColliders.gameObject.SetActive(true);
            calendar.OnTodo(4);
        }
    }

    public void OnItemDelivered()
    {
        calendar.OnTodo(3);
    }

    public void OnPhoneGrabbed()
    {

        playerDetectionScene1.disablePrompt = false;
        playerDetectionScene1.playerDetectedChange.Invoke(true);
        calendar.OnTodo(0);
    }

}
