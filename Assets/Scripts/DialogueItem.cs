using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;

[System.Serializable]
public class Answer {
    public string answerText;
    public DialogueItem nextItem;
    public int karma;
}

[CreateAssetMenu(fileName = "new DialogueItem", menuName = "CLL4/DialogueItem", order = 1)]
public class DialogueItem : ScriptableObject
{
 
public string dialogueText;

public AK.Wwise.Event dialogueSound;

public Answer[] answers;

}
