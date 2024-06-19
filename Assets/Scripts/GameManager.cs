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
    private LocomotionSystem moveSystem;
    public UnityEvent<EndingItem> doctorDialogueEnd;
    public UnityEvent taskCompleted;

    [SerializeField]
    private DialogueManager dialogueManager;
    [SerializeField]
    private PlayerDetection playerDetectionScene2;
        [SerializeField]
    private PlayerDetection playerDetectionScene1;

    void Start()
    {
        narrativeProgression = 0;
    }

    public void OnDialogueStarted(){
        if(narrativeProgression == 0) playerDetectionScene1.disablePrompt = true;
        if(narrativeProgression == 2 )playerDetectionScene2.disablePrompt = true;
        //moveSystem.SetActive(false);
    }

    public void OnDialogueEnded(){
        narrativeProgression++;
        //moveSystem.SetActive(true);
        if(narrativeProgression == 3) EndGame();
    }

    public void OnDoctorDialogueEnd(EndingItem item){
        bedroomDoor.transform.Rotate(new Vector3(0,-120,0));
        //doctorDialogueEnd.Invoke(item);
    }

    public void EndGame(){
        if(FindFirstObjectByType<KarmaKeeper>().Karma > 0){
            SceneManager.LoadSceneAsync(4);
        }
        else{
            SceneManager.LoadSceneAsync(3);
        }
    }

    public void OnItemDelivered(){

        playerDetectionScene2.disablePrompt = false;

    }

}
