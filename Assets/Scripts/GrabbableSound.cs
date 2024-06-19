using UnityEngine;

public class GrabbableSound : MonoBehaviour
{


    public void PlayGrabbableSound() {

        AkSoundEngine.PostEvent("Play_beer", gameObject);
        
        
    }

    public void PlayKitchenSound() {

        AkSoundEngine.PostEvent("Play_kitchen", gameObject);
        
        
    }
    
}
