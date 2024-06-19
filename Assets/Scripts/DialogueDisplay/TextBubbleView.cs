using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBubbleView : MonoBehaviour
{

    private AnswerListView answerListView;
    private TMP_Text mainText;

    private void Awake(){

        answerListView = GetComponentInChildren<AnswerListView>();
        mainText = GetComponentInChildren<TMP_Text>();

    }

    public void SetDialogueItem(DialogueItem dialogueItem){

        answerListView.SetAnswer(dialogueItem.answers);
        mainText.text = dialogueItem.dialogueText;

    }

}
