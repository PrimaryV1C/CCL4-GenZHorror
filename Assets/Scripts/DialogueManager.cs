using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public DialogueItem[] dialogues;
    [SerializeField]
    private TextMeshProUGUI text;

    void Start()
    {
        LoadAllDialogues();
        Debug.Log(dialogues[0].dialogueText);
        text.text = dialogues[0].dialogueText;
        //JsonData jsonData = JsonData.CreateFromJSON();
        //text.text = jsonData.dialogue.text;
    }

    void LoadAllDialogues()
    {
#if UNITY_EDITOR
        string[] guids = AssetDatabase.FindAssets("t:DialogueItem", new[] { "Assets/Dialogue" });
        List<DialogueItem> dialogueList = new List<DialogueItem>();

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            DialogueItem dialogue = AssetDatabase.LoadAssetAtPath<DialogueItem>(path);
            if (dialogue != null)
            {
                dialogueList.Add(dialogue);
            }
        }

        dialogues = dialogueList.ToArray();
#endif
    }
}
