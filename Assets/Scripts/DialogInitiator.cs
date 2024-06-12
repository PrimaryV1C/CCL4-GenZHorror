using System.Data.Common;
using UnityEngine;
using UnityEngine.Events;

public class DialogInitiator : MonoBehaviour
{

    private DialogueManager dialogueManager;

    public UnityEvent dialogueInitiated;

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    
    }

    public void AttemptDialog() {
        // if player is in zone
        dialogueInitiated.Invoke();
    }



}