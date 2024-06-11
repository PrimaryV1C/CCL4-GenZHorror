using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    void Start()
    {
        JsonData jsonData = JsonData.CreateFromJSON();
        text.text = jsonData.dialogue.text;
    }

    void Update()
    {
        
    }
}
