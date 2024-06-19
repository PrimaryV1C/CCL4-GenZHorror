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

        int childCount = this.transform.childCount;

        for(int i = 0; i < childCount; i++){

            Destroy(this.transform.GetChild(i).gameObject);
            
        }

        foreach(Answer answer in answers){
            
            GameObject answerGO = Instantiate(answerDisplayPrefab, this.transform);
            DisplayTextView displayTextView = answerGO.GetComponent<DisplayTextView>();
            displayTextView.clicked.AddListener( () => {answerSelected.Invoke(answer);} );
            displayTextView.SetAnswer(answer);
        }
    }
}
