using UnityEngine;
using UnityEngine.Events;

public class NPCScript : MonoBehaviour
{
    public DialogueItem initialItem;
    public UnityEvent<DialogueItem> talkedTo;

    public void OnDialogueButtonClicked(){

        talkedTo.Invoke(initialItem);

    }

}
