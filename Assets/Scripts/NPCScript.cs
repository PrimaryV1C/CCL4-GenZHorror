using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class NPCScript : MonoBehaviour
{
    public UnityEvent<int> answerClicked;

    public void Answer1(){

        answerClicked.Invoke(0);

    }

    public void Answer2(){

        answerClicked.Invoke(1);

    }

    public void Answer3(){

        answerClicked.Invoke(2);

    }
}
