using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RenderDialogue : MonoBehaviour
{
    [SerializeField]
    private DialogueManager dialogueManager;
    [SerializeField]
    private TextMeshProUGUI mainText;
    [SerializeField]
    private TextMeshProUGUI answer1;
    [SerializeField]
    private TextMeshProUGUI answer2;

    void Start()
    {
        dialogueManager.dialogueChanged.AddListener(OnDialogueChange);
    }

    public void OnDialogueChange(DialogueItem item){
        mainText.text = item.dialogueText;
        answer1.text = item.answers[0].answerText;
        answer2.text = item.answers[1].answerText;
    }
}
