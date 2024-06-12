using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private DialogueItem firstItem;
    [SerializeField]
    private TextMeshProUGUI text;

    private DialogueItem currentItem;

    [SerializeField]
    private GameObject npc;

    void Start()
    {
        currentItem = firstItem;
        //text.text = firstItem.dialogueText;
    }

    public void UncleJoeTalk(int answerIndex){
        currentItem = currentItem.answers[answerIndex].nextItem;
        npc.GetComponentInChildren<TextMeshProUGUI>().text = currentItem.dialogueText;
    }

    public void FirstDialog(){
        currentItem = firstItem;
        npc.GetComponentInChildren<TextMeshProUGUI>().text = currentItem.dialogueText;
    }
}
