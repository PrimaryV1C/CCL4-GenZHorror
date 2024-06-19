using UnityEngine;
using UnityEngine.Events;

public class PlayerDetection : MonoBehaviour
{

    public UnityEvent<bool>playerDetectedChange;
    public bool disablePrompt = false;

    public void OnTriggerEnter(Collider other)
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
            AkSoundEngine.PostEvent("Stop_kitchen", gameObject);
        }
    }


}
