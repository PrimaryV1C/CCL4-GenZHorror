using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class TextBubbleView : MonoBehaviour
{

    private AnswerListView answerListView;
    private TMP_Text mainText;
    public UnityEvent<Answer> answerSelected;

    private void Awake()
    {

        answerListView = GetComponentInChildren<AnswerListView>();
        mainText = GetComponentInChildren<TMP_Text>();

        answerListView.answerSelected.AddListener((answer) => { answerSelected.Invoke(answer); });

    }

    public void SetDialogueItem(DialogueItem dialogueItem)
    {

        answerListView.SetAnswers(dialogueItem.answers);
        mainText.text = dialogueItem.dialogueText;

    }

}
