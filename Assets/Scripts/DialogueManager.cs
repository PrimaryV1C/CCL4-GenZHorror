using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Data.Common;

public class DoctorDialogueChangeEvent : UnityEvent<DialogueItem> { }

public class DialogueManager : MonoBehaviour
{
    public Transform playerTransform;
    [SerializeField]
    private DialogueItem currentItem;

    [SerializeField]
    private DialogueItem uncleFirstDialogue;

    private EndingItem currentEnding;

    [SerializeField]

    private EndingItem UncleEndingGood;

    [SerializeField]
    private EndingItem UncleEndingBad;

    [SerializeField]
    private EndingItem DoctorEndingGood;

    [SerializeField]
    private EndingItem DoctorEndingBad;

    [SerializeField]
    public UnityEvent<DialogueItem> dialogueChanged;
    public UnityEvent<DialogueItem> dialogueChangedUncle;
    public UnityEvent<EndingItem> doctorDialogueEnd;
    public UnityEvent<EndingItem> uncleDialogueEnd;
    private int dialogueProgress;
    
    public int karma = 10;

    void Start()
    {
        dialogueProgress = 0;
        currentEnding = DoctorEndingBad;
        FirstDialog();
    }

    public void DoctorNpcTalk(int answerIndex){
        dialogueProgress++;
        if(dialogueProgress == 6){
            CalculateKarma(answerIndex);
            doctorDialogueEnd.Invoke(ChooseEndingScene1());
        }
        else{
            currentItem = currentItem.answers[answerIndex].nextItem;
            dialogueChanged.Invoke(currentItem);
        }
    }

    public void UncleNpcTalk(int answerIndex){
        dialogueProgress++;
        if(dialogueProgress == 7){
            CalculateKarma(answerIndex);
            uncleDialogueEnd.Invoke(ChooseEndingScene2());
        }
        else{
            currentItem = currentItem.answers[answerIndex].nextItem;
            dialogueChangedUncle.Invoke(currentItem);
        }
    }



    public void FirstDialog(){
        if(dialogueProgress == 0){
            dialogueChanged.Invoke(currentItem);
        }
        else{
            dialogueProgress = 0;
            currentItem = uncleFirstDialogue;
            dialogueChangedUncle.Invoke(uncleFirstDialogue);
        }
    }

    public void CalculateKarma(int answerIndex){
        karma += currentItem.answers[answerIndex].karma;
    }

  
    public EndingItem ChooseEndingScene1(){
        if(karma >= 0){
            Debug.Log(karma);
            return DoctorEndingGood;
        }
            return DoctorEndingBad;
    }

    public EndingItem ChooseEndingScene2(){
        if (karma >= 0){
            return UncleEndingGood;
        }
            return UncleEndingBad;
    }
}
    

