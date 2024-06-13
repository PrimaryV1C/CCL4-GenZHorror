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

    private EndingItem currentEnding;

    public int narrativeProgression;

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
    private int dialogueProgress;
    

    public int karma = 10;

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
        dialogueChanged.Invoke(currentItem);
    }

    public void CalculateKarma(int answerIndex){
        karma += currentItem.answers[answerIndex].karma;
    }

  
    public void ChooseEndingScene1(){
        //TODO: Updating correct narrativeProgression & karma
        if(karma >= 0 && narrativeProgression == 3){
            currentEnding = DoctorEndingGood;
        } else if(karma < 0 && narrativeProgression == 3){
            currentEnding = DoctorEndingBad;
        } 
        //RENDER ENING
    }

    public void ChooseEndingScene2(){
        //TODO: Updating correct narrativeProgression & karma
        if (karma >= 0 && narrativeProgression == 3){
            currentEnding = UncleEndingGood;
        } else if (karma < 0 && narrativeProgression == 3){
            currentEnding = UncleEndingBad;
        }
    }
}
    

