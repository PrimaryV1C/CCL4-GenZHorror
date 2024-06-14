using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int narrativeProgression;
    [SerializeField]
    private GameObject bedroomDoor;
    [SerializeField]
    private GameObject moveSystem;
    public UnityEvent<EndingItem> doctorDialogueEnd;

    void Start()
    {
        narrativeProgression = 0;
    }

    public void OnDialogueStarted(){
        moveSystem.SetActive(false);
    }

    public void OnDialogueEnded(){
        moveSystem.SetActive(true);
    }

    public void OnDoctorDialogueEnd(EndingItem item){
        bedroomDoor.transform.Rotate(new Vector3(0,-120,0));
        doctorDialogueEnd.Invoke(item);
    }

}
