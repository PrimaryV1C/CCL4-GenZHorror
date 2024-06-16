using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaskTable : MonoBehaviour
{

[SerializeField]
private Transform snapPosition;

public UnityEvent itemDelivered;

void OnTriggerEnter(Collider other) {
    if (other.gameObject.CompareTag("TaskItem")){

        other.gameObject.transform.position = snapPosition.position;

        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }

        itemDelivered.Invoke();
        } 
    }
}
