using UnityEngine;
using UnityEngine.Events;

public class PlayerDetection : MonoBehaviour
{

    public UnityEvent<bool>playerDetectedChange;
    public bool disablePrompt = false;

    //checks whether the player is entering the area to show the button
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
