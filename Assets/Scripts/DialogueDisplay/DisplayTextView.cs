using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 
using UnityEngine.Events;

public class DisplayTextView : MonoBehaviour
{
    
    private TMP_Text answerText;
    private Button button;

    public UnityEvent clicked;

    void Awake()
    {
        answerText = GetComponentInChildren<TMP_Text>();
        button = GetComponent<Button>();
        button.onClick.AddListener(() => {clicked.Invoke(); });
    }


    public void SetAnswer(Answer answer){

        answerText.text = answer.answerText;

    }

}
