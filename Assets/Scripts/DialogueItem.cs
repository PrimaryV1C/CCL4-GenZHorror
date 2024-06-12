using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Answer {
    public string answerText;
}

[CreateAssetMenu(fileName = "new DialogueItem", menuName = "CLL4/DialogueItem", order = 1)]
public class DialogueItem : ScriptableObject
{
 
public string dialogueText;

public int nextDialogueID;

public Answer[] answers;

}
