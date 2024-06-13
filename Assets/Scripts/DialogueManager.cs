using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Data.Common;

public class DoctorDialogueChangeEvent : UnityEvent<DialogueItem> { }

public class DialogueManager : MonoBehaviour
{
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
    private int dialogueProgress;
    
    public int karma = 10;

    void Start()
    {
        dialogueProgress = 0;
        FirstDialog();
        currentEnding = DoctorEndingBad;
    }

    public void DoctorNpcTalk(int answerIndex){
        dialogueProgress++;
        if(dialogueProgress == 6){
            ChooseEndingScene1();
            doctorDialogueEnd.Invoke(currentEnding);
        }
        else{
            currentItem = currentItem.answers[answerIndex].nextItem;
            dialogueChanged.Invoke(currentItem);
        }
    }

    public void UncleNpcTalk(int answerIndex){
        currentItem = currentItem.answers[answerIndex].nextItem;
        dialogueChangedUncle.Invoke(currentItem);
        dialogueProgress++;
        CalculateKarma(answerIndex);
    }



    public void FirstDialog(){
        if(dialogueProgress == 0){
            dialogueChanged.Invoke(currentItem);
        }
        else{
            dialogueChangedUncle.Invoke(uncleFirstDialogue);
        }
    }

    public void CalculateKarma(int answerIndex){
        karma += currentItem.answers[answerIndex].karma;
    }

  
    public void ChooseEndingScene1(){
        if(karma >= 0){
            currentEnding = DoctorEndingGood;
        } else if(karma < 0){
            currentEnding = DoctorEndingBad;
        } 
        
    }

    public void ChooseEndingScene2(){
        if (karma >= 0){
            currentEnding = UncleEndingGood;
        } else if (karma < 0){
            currentEnding = UncleEndingBad;
        }
    }
}
    

