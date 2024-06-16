using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.SceneManagement;

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
    private DialogueManager dialogueManager;

    void Start()
    {
        narrativeProgression = 0;
        taskCompleted.Invoke();
    }

    public void OnDialogueStarted(){
        moveSystem.SetActive(false);
    }

    public void OnDialogueEnded(){
        narrativeProgression++;
        moveSystem.SetActive(true);
        if(narrativeProgression == 2) EndGame();
    }

    public void OnDoctorDialogueEnd(EndingItem item){
        bedroomDoor.transform.Rotate(new Vector3(0,-120,0));
        doctorDialogueEnd.Invoke(item);
    }

    void EndGame(){
        if(dialogueManager.karma > 0){
            SceneManager.LoadSceneAsync(4);
        }
        else{
            SceneManager.LoadSceneAsync(3);
        }
    }

    public void OnItemDelivered(){

    }

}
