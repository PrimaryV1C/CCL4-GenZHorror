using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerListView : MonoBehaviour
{

    [SerializeField]
    private GameObject answerDisplayPrefab;

    public void SetAnswer(Answer[] answers){

        //TODO: Clear Old Answers

        foreach(Answer answer in answers){
            
            GameObject answerGO = Instantiate(answerDisplayPrefab, this.transform);
            DisplayTextView displayTextView = answerGO.GetComponent<DisplayTextView>();

            displayTextView.SetAnswer(answer);
        }
    }
}
