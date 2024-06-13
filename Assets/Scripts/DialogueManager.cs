using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

public class DoctorDialogueChangeEvent : UnityEvent<DialogueItem> { }

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private DialogueItem currentItem;
    [SerializeField]
    public UnityEvent<DialogueItem> dialogueChanged;
    private int dialogueProgress;
    

    void Start()
    {
        dialogueProgress = 0;
        FirstDialog();
    }

    public void OnNpcTalk(int answerIndex){
        currentItem = currentItem.answers[answerIndex].nextItem;
        dialogueChanged.Invoke(currentItem);

        dialogueProgress++;
    }
    public void FirstDialog(){
        Debug.Log(currentItem.dialogueText);
        dialogueChanged.Invoke(currentItem);
    }

}
