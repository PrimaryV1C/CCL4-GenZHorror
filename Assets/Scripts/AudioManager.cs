using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AudioManager : MonoBehaviour
{
   
   public bool isWalking;
   public ContinuousMoveProviderBase continuousMoveProvider;

   private Vector3 previousPosition;
  private Vector3 currentPosition;

  public void Start() {
    if (continuousMoveProvider == null) {
        continuousMoveProvider = GetComponent<ContinuousMoveProviderBase>();
    }
      previousPosition = continuousMoveProvider.gameObject.transform.position;

  }


   public void Update() {
        if (currentPosition != previousPosition) {
            Debug.Log("Walking");
            isWalking = true;
            AkSoundEngine.PostEvent("stepping_container", gameObject);
            
        }
        previousPosition = currentPosition;
    }

   }

