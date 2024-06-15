using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AudioManager : MonoBehaviour
{
   
   public bool isWalking;
   public GameObject playerPosition;

   private Vector3 previousPosition;
  private Vector3 currentPosition;

  private bool footstepsPlaying = false;
  private float lastFootstepTime = 0.0f;
  private float footstepInterval = 0.5f;

  private float movementSpeed = 0.8f;

  public void Start() {

    lastFootstepTime = Time.time;

    if (playerPosition != null) {

      previousPosition = playerPosition.gameObject.transform.position;

  }

  }


    public void Update()
    {
        if (playerPosition != null)
        {
            currentPosition = playerPosition.transform.position;
<<<<<<< Updated upstream
=======
            Debuz.Log(currentPosition);
>>>>>>> Stashed changes

            if (currentPosition != previousPosition)

            {

              isWalking = true;
                if (Time.time - lastFootstepTime > footstepInterval)
                {
                    AkSoundEngine.PostEvent("Play_stepping_container", gameObject);
                    lastFootstepTime = Time.time;
            
                }
            }
            else
            {
              isWalking = false; 
<<<<<<< Updated upstream
              
=======

>>>>>>> Stashed changes
                if (footstepsPlaying)
                {
                    AkSoundEngine.PostEvent("Stop_stepping_container", gameObject); // Ensure there's a stop event in Wwise
                    footstepsPlaying = false;
                }

                
            }

            previousPosition = currentPosition;
        }
    }
}