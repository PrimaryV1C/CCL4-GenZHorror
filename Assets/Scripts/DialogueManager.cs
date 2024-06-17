using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Data.Common;

public class DoctorDialogueChangeEvent : UnityEvent<DialogueItem> { }

public class DialogueManager : MonoBehaviour
{   
    private bool closeDialogue = false;

    public bool itemDelivered = false;
    public UnityEvent EndDialogue;
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
    private EndingItem UncleBrinBeer;

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
        AkSoundEngine.PostEvent("Stop_background_short", gameObject);
    }

    public void DoctorNpcTalk(int answerIndex){

        if(closeDialogue) EndDialogue.Invoke();

        dialogueProgress++;
        if(dialogueProgress == 6){
            AkSoundEngine.PostEvent("Stop_background_short", gameObject);
            CalculateKarma(answerIndex);
            doctorDialogueEnd.Invoke(ChooseEndingScene1());
            closeDialogue = true;
        }
        else{
            currentItem = currentItem.answers[answerIndex].nextItem;
            dialogueChanged.Invoke(currentItem);
            AkSoundEngine.PostEvent("Stop_background_short", gameObject);
            ChooseRightDoctorSound();
        }
    }

    public void UncleNpcTalk(int answerIndex){

        if(closeDialogue) EndDialogue.Invoke();

        dialogueProgress++;
        if(dialogueProgress == 3){
            currentItem = currentItem.answers[answerIndex].nextItem;
            EndDialogue.Invoke();
            //uncleDialogueEnd.Invoke(ChooseEndingScene2());
            //closeDialogue = true;
        }
        if(dialogueProgress == 7){
            CalculateKarma(answerIndex);
            uncleDialogueEnd.Invoke(ChooseEndingScene2());
            closeDialogue = true;
        }
        else{
            currentItem = currentItem.answers[answerIndex].nextItem;
            dialogueChangedUncle.Invoke(currentItem);
        }
    }

    public void StartDialog() 
    {
      StartCoroutine(FirstDialog());
      AkSoundEngine.PostEvent("Stop_background_short", gameObject);

    }
        
    
    private IEnumerator FirstDialog(){
        if(dialogueProgress == 0){
            AkSoundEngine.PostEvent("Stop_background_short", gameObject);
            dialogueChanged.Invoke(currentItem);
            yield return new WaitForSeconds(1);
            ChooseRightDoctorSound();

            
        }
        else if(dialogueProgress == 3){
            if(itemDelivered)
            {
                closeDialogue = false;
                dialogueChangedUncle.Invoke(currentItem);
                AkSoundEngine.PostEvent("Stop_background_short", gameObject);
                ChooseRightDoctorSound();
            }
        }
        else{
            closeDialogue = false;
            dialogueProgress = 0;
            currentItem = uncleFirstDialogue;
            dialogueChangedUncle.Invoke(uncleFirstDialogue);
            AkSoundEngine.PostEvent("Stop_background_short", gameObject);
            ChooseRightDoctorSound();
        }
    }

    public void CalculateKarma(int answerIndex){
        karma += currentItem.answers[answerIndex].karma;
    }

  
    public EndingItem ChooseEndingScene1(){
        if(karma >= 0){
            AkSoundEngine.PostEvent("Stop_q6", gameObject);
            return DoctorEndingGood;
        }
            AkSoundEngine.PostEvent("Stop_q6", gameObject);
            return DoctorEndingBad;
    }

    public EndingItem ChooseEndingScene2(){
        if (karma >= 0){

            return UncleEndingGood;
        }
            return UncleEndingBad;
    }

  public void ChooseRightDoctorSound() {
    
    if (dialogueProgress == 0) {
      
      AkSoundEngine.PostEvent("Play_q1", gameObject);
    }
    else if (dialogueProgress == 1) {
      AkSoundEngine.PostEvent("Stop_q1", gameObject);
      AkSoundEngine.PostEvent("Play_q2", gameObject);
    }
    else if (dialogueProgress == 2) {
      AkSoundEngine.PostEvent("Stop_q2", gameObject);
      AkSoundEngine.PostEvent("Play_q3", gameObject);
    }
    else if (dialogueProgress == 3) {
        AkSoundEngine.PostEvent("Stop_q3", gameObject);
      AkSoundEngine.PostEvent("Play_q4", gameObject);
    }
    else if (dialogueProgress == 4) {
        AkSoundEngine.PostEvent("Stop_q4", gameObject);
      AkSoundEngine.PostEvent("Play_q5", gameObject);
    }
    else if (dialogueProgress == 5) {
      AkSoundEngine.PostEvent("Stop_q5", gameObject);
      AkSoundEngine.PostEvent("Play_q6", gameObject);
    }
  }


}
    

