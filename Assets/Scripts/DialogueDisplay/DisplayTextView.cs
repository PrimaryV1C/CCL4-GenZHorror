using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayTextView : MonoBehaviour
{
    
    private TMP_Text answerText;

    void Awake()
    {
        answerText = GetComponentInChildren<TMP_Text>();
    }


    public void SetAnswer(Answer answer){

        answerText.text = answer.answerText;

    }

}
