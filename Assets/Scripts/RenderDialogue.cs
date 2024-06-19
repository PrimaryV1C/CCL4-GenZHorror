using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RenderDialogue : MonoBehaviour
{
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
        AkSoundEngine.PostEvent("Stop_background_short", gameObject);
    }

    public void OnDialogueChangeDoctor(DialogueItem item){
        /*mainText.text = item.dialogueText;
        answer1.text = item.answers[0].answerText;
        answer2.text = item.answers[1].answerText;*/
        GetComponent<TextBubbleView>().SetDialogueItem(item);
    }

    public void OnEnding(EndingItem item){
        mainText.text = item.endingText;
        if(answer3 != null){
            answer1.text = "Lets talk about the weather.";
            answer2.text = "I'll better start washing the dishes.";
            answer3.text = "Fuck off Uncle!";
        }
        else{
            answer1.text = "Finially, Cya!";
            answer2.text = "Great, thank you.";
        }
    }

    public void OnDialogueChangeUncle(DialogueItem item){
        mainText.text = item.dialogueText;
        answer1.text = item.answers[0].answerText;
        answer2.text = item.answers[1].answerText;
        answer3.text = item.answers[2].answerText;
    }




}
