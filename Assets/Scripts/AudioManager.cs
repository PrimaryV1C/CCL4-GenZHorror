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

  private float movementSpeed = 0.5f;

  public void Start() {

    lastFootstepTime = Time.time;

    if (playerPosition != null) {

      previousPosition = playerPosition.gameObject.transform.position;

  }

  }


   public void Update() {

    if (playerPosition != null) {

      currentPosition = playerPosition.gameObject.transform.position;

      if (currentPosition != previousPosition) {
        Debug.Log("Player is walking.");
        
        
        if ( !footstepsPlaying)
        
{
    AkSoundEngine.PostEvent("Play_stepping_container", gameObject);
    lastFootstepTime = Time.time;
    footstepsPlaying = true;
}
else if (Time.time - lastFootstepTime > 125 / movementSpeed * Time.deltaTime)
{
    footstepsPlaying = false;

}

        isWalking = true;


      } else {

        isWalking = false;


      previousPosition = currentPosition;

    }

   }

}
}

