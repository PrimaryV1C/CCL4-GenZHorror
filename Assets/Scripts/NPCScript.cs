using UnityEngine;
using UnityEngine.Events;

public class NPCScript : MonoBehaviour
{
    public DialogueItem initialItem;
    public UnityEvent<DialogueItem> dialogueChanged;
    public UnityEvent<DialogueItem> talkedTo;
    private DialogueItem currentItem;

    public void OnDialogueButtonClicked()
    {

        currentItem = initialItem;
        dialogueChanged.Invoke(currentItem);
        AkSoundEngine.PostEvent(currentItem.dialogueSound.Name, gameObject);

    }
    public void OnAnswerSelected(Answer answer)
    {

        if (answer.nextItem == null) Debug.Log("End of Dialogue");
        currentItem = answer.nextItem;
        dialogueChanged.Invoke(currentItem);
        AkSoundEngine.PostEvent(currentItem.dialogueSound.Name, gameObject);

    }

}
