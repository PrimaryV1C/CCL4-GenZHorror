using System.Data.Common;
using UnityEngine;
using UnityEngine.Events;

public class DialogInitiator : MonoBehaviour
{

    public UnityEvent dialogueInitiated;

    void Start()
    {
    
    }

    public void AttemptDialog() {
        // if player is in zone
        dialogueInitiated.Invoke();
    }



}