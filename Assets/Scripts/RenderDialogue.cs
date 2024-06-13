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
        //dialogueManager.dialogueChanged.AddListener(OnDialogueChange);
    }

    public void OnDialogueChangeDoctor(DialogueItem item){
        mainText.text = item.dialogueText;
        answer1.text = item.answers[0].answerText;
        answer2.text = item.answers[1].answerText;
    }

    public void OnEnding(EndingItem item){
        mainText.text = item.endingText;
        answer1.text = "Finially, Cya!";
        answer2.text = "Great, thank you.";
    }

    public void OnDialogueChangeUncle(DialogueItem item){
        mainText.text = item.dialogueText;
        answer1.text = item.answers[0].answerText;
        answer2.text = item.answers[1].answerText;
        answer3.text = item.answers[2].answerText;
    }




}
