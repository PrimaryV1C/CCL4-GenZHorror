using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDetection : MonoBehaviour
{

    public UnityEvent<bool>playerDetectedChange;
    public bool disablePrompt = false;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision!");
        if(other.tag == "Player" && !disablePrompt)
        {   
            playerDetectedChange.Invoke(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player" && !disablePrompt)
        {
            playerDetectedChange.Invoke(false);
        }
    }


}
