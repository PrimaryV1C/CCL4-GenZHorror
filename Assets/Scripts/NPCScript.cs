using UnityEngine;
using UnityEngine.Events;

public class NPCScript : MonoBehaviour
{

    public UnityEvent<NPCScript> talkedTo;

    void Start()
    {
        talkedTo.Invoke(this);
    }

    void Update()
    {
        
    }

    public void buttonClicked(){

        GMEvent.EventHandler.buttonClicked.Invoke();

    }
}
