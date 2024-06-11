using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject npc;
    
    void Start()
    {
        GMEvent.EventHandler.buttonClicked += handleButton;
    }

    void Update()
    {
        
    }

    private void handleButton(){
        npc.transform.position += new Vector3(0, 1, 0);
    }

    public void OnTalkedTo(NPCScript npc){
        Debug.Log("Talked To " + npc.name);
    }

}
