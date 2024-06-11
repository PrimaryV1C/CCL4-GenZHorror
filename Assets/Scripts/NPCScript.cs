using UnityEngine;

public class NPCScript : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonClicked(){

        GMEvent.EventHandler.buttonClicked.Invoke();

    }
}
