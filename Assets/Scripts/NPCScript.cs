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

    void Awake()
    {

        karmaKeeper = FindAnyObjectByType<KarmaKeeper>();

    }

    void Start()
    {
        //if (initialItem != null) {}
    }
    public void OnDialogueButtonClicked()
    {

        currentItem = initialItem;
        dialogueChanged.Invoke(currentItem);
        AkSoundEngine.PostEvent(currentItem.dialogueSound.Name, gameObject);

    }
    public void OnAnswerSelected(Answer answer)
    {
        string stopSound = currentItem.dialogueSound.Name.Replace("Play", "Stop");

        if (closeDialogue)
        {
            AkSoundEngine.PostEvent(stopSound, gameObject);
            closeDialogueBubble.Invoke();
            return;
        }

        if (answer.nextItem.name == "DrEndingBad" || answer.nextItem.name == "JoeEndingBad")
        {
            //EndDialogue();
            closeDialogue = true;
        }

        currentItem = answer.nextItem;
        dialogueChanged.Invoke(currentItem);
        AkSoundEngine.PostEvent(stopSound, gameObject);
        AkSoundEngine.PostEvent(currentItem.dialogueSound.Name, gameObject);

    }

    void EndDialogue()
    {
        if (karmaKeeper.Karma >= 0)
        {
            currentItem = EndingGood;
            dialogueChanged.Invoke(currentItem);
        }
        else{
            currentItem = EndingBad;
            dialogueChanged.Invoke(currentItem);
        }
    }

}
