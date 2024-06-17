using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Calendar : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> todoItems;

    [SerializeField]
    private List<string> tasks;
    private int i = 0;

    void Start()
    {
        foreach (GameObject item in todoItems)
        {
            TextMeshProUGUI[] textComponents = item.GetComponentsInChildren<TextMeshProUGUI>();

            foreach (TextMeshProUGUI textComponent in textComponents)
            {
                if (textComponent.name == "Task")
                {
                    textComponent.text = tasks[i];
                }
            }

            i++;
        }
        i = 0;
    }

    public void OnTaskCompletion()
    {
        TextMeshProUGUI[] textComponents = todoItems[i].GetComponentsInChildren<TextMeshProUGUI>();
        if (textComponents[1].name == "Done")
            {
                textComponents[1].text = "---------------------------------------";
            }
            i++;
    }
}
