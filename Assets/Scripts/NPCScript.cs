using UnityEngine;
using UnityEngine.Events;

class DialoguePayload{

    NPCScript npc;
    DialogueItem nextItem;

}

public class NPCScript : MonoBehaviour
{

    public UnityEvent<int> cakeDialogue;
    public DialogueItem currentDialogue;

    void Start()
    {
        //talkedTo.Invoke(currentDialogue);
    }

    void Update()
    {
        
    }

    public void Answer1(){

        cakeDialogue.Invoke(0);

    }

    public void Answer2(){

        cakeDialogue.Invoke(1);

    }
}
