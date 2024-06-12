using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
using System.Data.Common;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private DialogueItem firstItem;
    [SerializeField]
    private TextMeshProUGUI text;

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
    private GameObject npc;

    public int karma = 10;

    void Start()
    {
        currentItem = firstItem;
        //text.text = firstItem.dialogueText;
    }

    public void UncleJoeTalk(int answerIndex){
        currentItem = currentItem.answers[answerIndex].nextItem;
        npc.GetComponentInChildren<TextMeshProUGUI>().text = currentItem.dialogueText;
    }

    public void FirstDialog(){
        currentItem = firstItem;
        npc.GetComponentInChildren<TextMeshProUGUI>().text = currentItem.dialogueText;
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
        npc.GetComponentInChildren<TextMeshProUGUI>().text = currentEnding.endingText; //hat mir CopIlot vorgschlagen, weiß nicht ob das stimmt
    }

    public void ChooseEndingScene2(){
        //TODO: Updating correct narrativeProgression & karma
        if (karma >= 0 && narrativeProgression == 3){
            currentEnding = UncleEndingGood;
        } else if (karma < 0 && narrativeProgression == 3){
            currentEnding = UncleEndingBad;
        }

        npc.GetComponentInChildren<TextMeshProUGUI>().text = currentEnding.endingText; 
        
    }

}
    

