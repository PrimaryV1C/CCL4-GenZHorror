using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AudioManager : MonoBehaviour
{
   
   public bool isWalking;
   public GameObject playerPosition;

   private Vector3 previousPosition;
  private Vector3 currentPosition;

  public void Start() {

      previousPosition = playerPosition.gameObject.transform.position;

  }


   public void Update() {

       currentPosition = playerPosition.gameObject.transform.position;

       if (currentPosition != previousPosition) {
           isWalking = true;
       } else {
           isWalking = false;
       }

       previousPosition = currentPosition;

   }

}

