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

    [SerializeField]
    private TextMeshProUGUI answer3;

    void Start()
    {
        dialogueManager.dialogueChanged.AddListener(OnDialogueChangeDoctor);
    }

    public void OnDialogueChangeDoctor(DialogueItem item){
        mainText.text = item.dialogueText;
        answer1.text = item.answers[0].answerText;
        answer2.text = item.answers[1].answerText;
    }

    public void OnDialogueChangeUncle(DialogueItem item){
        mainText.text = item.dialogueText;
        answer1.text = item.answers[0].answerText;
        answer2.text = item.answers[1].answerText;
        answer3.text = item.answers[2].answerText;
    }




}
