using UnityEngine;
using UnityEngine.Events;

public class NPCScript : MonoBehaviour
{
    public DialogueItem initialItem;
    public UnityEvent<DialogueItem> dialogueChanged;
    public UnityEvent<DialogueItem> talkedTo;

    public UnityEvent closeDialogueBubble;

    [SerializeField]
    private DialogueItem EndingGood;
    [SerializeField]
    private DialogueItem EndingBad;
    private DialogueItem currentItem;

    private KarmaKeeper karmaKeeper;

    private bool closeDialogue = false;

    void Awake(){
        
        karmaKeeper = FindAnyObjectByType<KarmaKeeper>();

    }
    public void OnDialogueButtonClicked()
    {

        currentItem = initialItem;
        dialogueChanged.Invoke(currentItem);
        AkSoundEngine.PostEvent(currentItem.dialogueSound.Name, gameObject);

    }
    public void OnAnswerSelected(Answer answer)
    {

        if(closeDialogue){
            closeDialogueBubble.Invoke();
            return;
        }

        if (answer.nextItem == null)
        {
            currentItem = EndDialogue();
            closeDialogue = true;
        }
        else{
            currentItem = answer.nextItem;
        }
        dialogueChanged.Invoke(currentItem);
        AkSoundEngine.PostEvent(currentItem.dialogueSound.Name, gameObject);

    }

  DialogueItem EndDialogue()
  {
    if (karmaKeeper.Karma >= 0)
    {
        return EndingGood;
    }
        return EndingBad;
  }

}
