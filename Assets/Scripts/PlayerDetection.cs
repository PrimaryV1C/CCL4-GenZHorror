using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDetection : MonoBehaviour
{

    public UnityEvent<bool>playerDetectedChange;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MainCamera")
        {
            playerDetectedChange.Invoke(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "MainCamera")
        {
            playerDetectedChange.Invoke(false);
        }
    }


}
