using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndGameCollider : MonoBehaviour
{

    public bool enableEndCollider = false;
    public UnityEvent endGame;


    private void OnTriggerEnter(Collider other) {
        if(enableEndCollider && other.CompareTag("Player")){
            endGame.Invoke();
        }
    }
}
