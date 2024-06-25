using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System;

public class Calendar : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> todoItems;

    [SerializeField]
    private List<string> tasks;
    private int i = 0;

    //Array to safe which tasks have been completed
    private bool[] taskArray = new bool[6];

    void Start()
    {   
        //Sets the todo text for each task in todoItems
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

    //Checks whether the task completed needs to be checked of the list
    public void OnTodo(int index){
        if(!taskArray[index]){
            OnTaskCompletion();
            taskArray[index] = true;
        }
    }

    public void OnTaskCompletion()
    {
        TextMeshProUGUI[] textComponents = todoItems[i].GetComponentsInChildren<TextMeshProUGUI>();
        if (textComponents[1].name == "Done")
            {
                textComponents[1].text = "_______________________________";
            }
            i++;
    }
}
