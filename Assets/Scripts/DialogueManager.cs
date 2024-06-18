using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Data.Common;

public class DoctorDialogueChangeEvent : UnityEvent<DialogueItem> { }

public class DialogueManager : MonoBehaviour
{
  private bool doctorDone = false;
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

  public NPCScript npcScript;

  void Start()
  {
    dialogueProgress = 0;
    currentEnding = DoctorEndingBad;

    if (npcScript != null)
    {
      npcScript.answerClicked.AddListener(OnAnswerClicked);
    }
  }

  public void OnAnswerClicked(int answerIndex)
  {
    if (!doctorDone)
    {
      DoctorNpcTalk(answerIndex);
    }
    else
    {
      UncleNpcTalk(answerIndex);
    }
  }

  public void DoctorNpcTalk(int answerIndex)
  {

    if (closeDialogue) EndDialogue.Invoke();

    dialogueProgress++;
    if (dialogueProgress == 6)
    {
      CalculateKarma(answerIndex);
      doctorDialogueEnd.Invoke(ChooseEndingScene1());
      doctorDone = true;
      closeDialogue = true;
    }
    else
    {
      currentItem = currentItem.answers[answerIndex].nextItem;
      dialogueChanged.Invoke(currentItem);
      ChooseRightDoctorSound();
    }
  }

  public void UncleNpcTalk(int answerIndex)
  {

    if (closeDialogue) EndDialogue.Invoke();

    dialogueProgress++;
    if (dialogueProgress == 3)
    {
      currentItem = currentItem.answers[answerIndex].nextItem;
      EndDialogue.Invoke();
      //uncleDialogueEnd.Invoke(ChooseEndingScene2());
      //closeDialogue = true;
    }
    if (dialogueProgress == 7)
    {
      CalculateKarma(answerIndex);
      uncleDialogueEnd.Invoke(ChooseEndingScene2());
      closeDialogue = true;
    }
    else
    {
      currentItem = currentItem.answers[answerIndex].nextItem;
      dialogueChangedUncle.Invoke(currentItem);
    }
  }

  public void StartDialog()
  {
    StartCoroutine(FirstDialog());

  }


  private IEnumerator FirstDialog()
  {
    if (dialogueProgress == 0)
    {
      dialogueChanged.Invoke(currentItem);
      yield return new WaitForSeconds(1);
      if (!doctorDone)
      {
        ChooseRightDoctorSound();
      }
      else
      {
        ChooseRightUncleSound(0);
      }


    }
    else if (dialogueProgress == 3)
    {
      if (itemDelivered)
      {
        closeDialogue = false;
        dialogueChangedUncle.Invoke(currentItem);
        ChooseRightDoctorSound();
      }
    }
    else
    {
      closeDialogue = false;
      dialogueProgress = 0;
      currentItem = uncleFirstDialogue;
      dialogueChangedUncle.Invoke(uncleFirstDialogue);
      ChooseRightDoctorSound();
    }
  }

  public void CalculateKarma(int answerIndex)
  {
    karma += currentItem.answers[answerIndex].karma;
  }


  public EndingItem ChooseEndingScene1()
  {
    if (karma >= 0)
    {
      AkSoundEngine.PostEvent("Stop_q6", gameObject);
      AkSoundEngine.PostEvent("Play_s2_ending_good", gameObject);
      return DoctorEndingGood;
    }
    AkSoundEngine.PostEvent("Stop_q6", gameObject);
    AkSoundEngine.PostEvent("Play_s2_ending_bad", gameObject);
    return DoctorEndingBad;
  }

  public EndingItem ChooseEndingScene2()
  {
    if (karma >= 0)
    {

      return UncleEndingGood;
    }
    return UncleEndingBad;
  }

  public void ChooseRightDoctorSound()
  {

    if (dialogueProgress == 0 && !doctorDone)
    {

      AkSoundEngine.PostEvent("Play_q1", gameObject);
    }
    else if (dialogueProgress == 1)
    {
      AkSoundEngine.PostEvent("Stop_q1", gameObject);
      AkSoundEngine.PostEvent("Play_q2", gameObject);
    }
    else if (dialogueProgress == 2)
    {
      AkSoundEngine.PostEvent("Stop_q2", gameObject);
      AkSoundEngine.PostEvent("Play_q3", gameObject);
    }
    else if (dialogueProgress == 3)
    {
      AkSoundEngine.PostEvent("Stop_q3", gameObject);
      AkSoundEngine.PostEvent("Play_q4", gameObject);
    }
    else if (dialogueProgress == 4)
    {
      AkSoundEngine.PostEvent("Stop_q4", gameObject);
      AkSoundEngine.PostEvent("Play_q5", gameObject);
    }
    else if (dialogueProgress == 5)
    {
      AkSoundEngine.PostEvent("Stop_q5", gameObject);
      AkSoundEngine.PostEvent("Play_q6", gameObject);
    }
  }

  public void ChooseRightUncleSound(int answerIndex)
  {

    if (dialogueProgress == 0 && doctorDone == true)
    {

      AkSoundEngine.PostEvent("Play_s2_q1", gameObject);

    }
    else if (dialogueProgress == 1 && answerIndex == 0)
    {
      AkSoundEngine.PostEvent("Stop_s2_q1", gameObject);
      AkSoundEngine.PostEvent("Play_s2_q1_1", gameObject);
    }
    else if (dialogueProgress == 1 && answerIndex == 1)
    {
      AkSoundEngine.PostEvent("Stop_s2_q1_1", gameObject);
      AkSoundEngine.PostEvent("Play_s2_q1_2", gameObject);
    }
    else if (dialogueProgress == 1 && answerIndex == 2)
    {
      AkSoundEngine.PostEvent("Stop_s2_q1_2", gameObject);
      AkSoundEngine.PostEvent("Play_s2_q1_3", gameObject);
    }
    else if (dialogueProgress == 2)
    {
      AkSoundEngine.PostEvent("Stop_s2_q1_3", gameObject);
      AkSoundEngine.PostEvent("Play_s2_q2", gameObject);
    }
    else if (dialogueProgress == 2 && answerIndex == 0)
    {
      AkSoundEngine.PostEvent("Stop_s2_q2", gameObject);
      AkSoundEngine.PostEvent("Play_s2_q2_1", gameObject);
    }
    else if (dialogueProgress == 2 && answerIndex == 1)
    {
      AkSoundEngine.PostEvent("Stop_s2_q2_1", gameObject);
      AkSoundEngine.PostEvent("Play_s2_q2_2", gameObject);
    }
    else if (dialogueProgress == 2 && answerIndex == 2)
    {
      AkSoundEngine.PostEvent("Stop_s2_q2_2", gameObject);
      AkSoundEngine.PostEvent("Play_s2_q2_3", gameObject);
    }
    else if (dialogueProgress == 3)
    {
      AkSoundEngine.PostEvent("Stop_s2_q2_3", gameObject);
      AkSoundEngine.PostEvent("Play_s2_q3", gameObject);
    }
    else if (dialogueProgress == 3 && answerIndex == 0)
    {
      AkSoundEngine.PostEvent("Stop_s2_q3", gameObject);
      AkSoundEngine.PostEvent("Play_s2_q3_1", gameObject);
    }
    else if (dialogueProgress == 3 && answerIndex == 1)
    {
      AkSoundEngine.PostEvent("Stop_s2_q3_1", gameObject);
      AkSoundEngine.PostEvent("Play_s2_3_2", gameObject);
    }
    else if (dialogueProgress == 3 && answerIndex == 2)
    {
      AkSoundEngine.PostEvent("Stop_s2_q3_2", gameObject);
      AkSoundEngine.PostEvent("Play_s2_q3_3", gameObject);
    }


  }


}


