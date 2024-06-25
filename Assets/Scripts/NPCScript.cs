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
        currentItem = null;
    }
    public void OnDialogueButtonClicked()
    {
        closeDialogue = false;

        //when the dialogue started, takes the first dialogue item and calls the event to display the dialogue
        if(currentItem == null) currentItem = initialItem;
        dialogueChanged.Invoke(currentItem);
        AkSoundEngine.PostEvent(currentItem.dialogueSound.Name, gameObject);

    }
    public void OnAnswerSelected(Answer answer)
    {   
        //creates the string to stop the previous dialogue from playing
        string stopSound = currentItem.dialogueSound.Name.Replace("Play", "Stop");


        if (closeDialogue)
        {
            //becomes true when the uncle dialogue is interrupted for the beer task, so the next dialogue is saved
            if(currentItem.name == "UncleQ2") currentItem = answer.nextItem;

            //stops the dialogue sound and closes the dialogue bubble
            AkSoundEngine.PostEvent(stopSound, gameObject);
            closeDialogueBubble.Invoke();
            return;
        }

        if (answer.nextItem.name == "Ending")
        {
            EndDialogue();
            closeDialogue = true;
            return;
        }

        //links the dialogues together
        currentItem = answer.nextItem;

        //checks when the uncle dialogue should be interrupted for the beer task
        if(currentItem.name == "UncleQ2"){closeDialogue = true;}
            dialogueChanged.Invoke(currentItem);
            AkSoundEngine.PostEvent(stopSound, gameObject);
            AkSoundEngine.PostEvent(currentItem.dialogueSound.Name, gameObject);
    }

    //calulates the ending based on the karma and renders the ending dialogue
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
