using UnityEngine;
using UnityEngine.Events;

public class NPCScript : MonoBehaviour
{
    public DialogueItem initialItem;
    public UnityEvent<DialogueItem> dialogueChanged;
    public UnityEvent<DialogueItem> talkedTo;

    [SerializeField]
    private DialogueItem EndingGood;
    [SerializeField]
    private DialogueItem EndingBad;
    private DialogueItem currentItem;

    private KarmaKeeper karmaKeeper;

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

        if (answer.nextItem == null)
        {
            EndDialogue();
            return;
        }
        currentItem = answer.nextItem;
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
