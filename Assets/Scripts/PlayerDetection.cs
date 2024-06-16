using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDetection : MonoBehaviour
{

    public UnityEvent<bool>playerDetectedChange;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision!");
        if(other.tag == "Player")
        {   
            playerDetectedChange.Invoke(true);
            AkSoundEngine.PostEvent("Play_phone_finish", gameObject);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerDetectedChange.Invoke(false);
            AkSoundEngine.PostEvent("Stop_phone_finish", gameObject);
        }
    }


}
