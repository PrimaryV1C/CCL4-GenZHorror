using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableSound : MonoBehaviour
{


    public void PlayGrabbableSound() {

        AkSoundEngine.PostEvent("Play_beer", gameObject);
        
        
    }
    
}
