using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    private int narrativeProgression;

    [SerializeField]
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
        //checks call your doctor task
        if (narrativeProgression == 0) calendar.OnTodo(1);
        //checks talk to  your uncle task
        if (narrativeProgression == 1) calendar.OnTodo(2);
    }

    public void OnDialogueEnded()
    {
        //checks continue talking to your uncle task
        narrativeProgression++;
        if (narrativeProgression == 3)
        {
            //turns the endgame colliders on infront of the doors
            endGameColliders.gameObject.SetActive(true);
            calendar.OnTodo(4);
        }
    }

    //checks the bring your uncle a beer task
    public void OnItemDelivered()
    {
        calendar.OnTodo(3);
    }

    //checks the find your phone task and shows the start call button
    public void OnPhoneGrabbed()
    {

        playerDetectionScene1.disablePrompt = false;
        playerDetectionScene1.playerDetectedChange.Invoke(true);
        calendar.OnTodo(0);
    }

}
