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
    public UnityEvent<EndingItem> doctorDialogueEnd;
    
    void Start()
    {
        narrativeProgression = 0;
    }

    void Update()
    {
        
    }

    public void OnDoctorDialogueEnd(EndingItem item){
        bedroomDoor.transform.Rotate(new Vector3(0,-120,0));
        doctorDialogueEnd.Invoke(item);
    }

}
