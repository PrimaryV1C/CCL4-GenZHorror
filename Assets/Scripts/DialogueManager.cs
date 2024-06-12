using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private DialogueItem firstItem;
    [SerializeField]
    private TextMeshProUGUI text;

    void Start()
    {
        Debug.Log(firstItem.dialogueText);
        text.text = firstItem.dialogueText;
        //JsonData jsonData = JsonData.CreateFromJSON();
        //text.text = jsonData.dialogue.text;
    }



}
