using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI; 

public class AnswerListView : MonoBehaviour
{

    [SerializeField]
    private GameObject answerDisplayPrefab;
    public UnityEvent<Answer> answerSelected;

    public void SetAnswers(Answer[] answers){

        //TODO: Clear Old Answers

        foreach(Answer answer in answers){
            
            GameObject answerGO = Instantiate(answerDisplayPrefab, this.transform);
            DisplayTextView displayTextView = answerGO.GetComponent<DisplayTextView>();
            displayTextView.clicked.AddListener( () => {answerSelected.Invoke(answer);} );
            displayTextView.SetAnswer(answer);
        }
    }
}
