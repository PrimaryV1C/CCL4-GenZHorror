using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableSound : MonoBehaviour
{
    [SerializeField]
    public AK.Wwise.Event soundEvent;


    public void PlayGrabbableSound()
    {
        if (soundEvent != null)
        {
            soundEvent.Post(gameObject);
        }
    }
}
