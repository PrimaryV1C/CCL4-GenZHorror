using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class TaskTable : MonoBehaviour
{

[SerializeField]
private Transform snapPosition;

public UnityEvent itemDelivered;

void OnTriggerEnter(Collider other) {
    if (other.gameObject.CompareTag("TaskItem")){


        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }
        
        other.gameObject.transform.position = snapPosition.position;
        other.gameObject.transform.rotation = Quaternion.identity;
        other.gameObject.GetComponent<XRGrabInteractable>().enabled = false;

        itemDelivered.Invoke();
        } 
    }
}
