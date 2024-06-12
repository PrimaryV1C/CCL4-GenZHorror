using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private DialogueManager dialogueManager;
    private int narrativeProgression;
    
    void Start()
    {
        dialogueManager.FirstDialog();
        narrativeProgression = 0;
    }

    void Update()
    {
        
    }

    public void OnCakeDialogue(int answerIndex){
        narrativeProgression++;
        dialogueManager.UncleJoeTalk(answerIndex);
    }

}
