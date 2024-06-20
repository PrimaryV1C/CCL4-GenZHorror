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


        itemDelivered.Invoke();

        Transform parentTransform = other.gameObject.GetComponentInParent<Transform>();
        parentTransform.position = snapPosition.position;
        parentTransform.rotation = Quaternion.identity;

        Rigidbody rb = other.gameObject.GetComponentInParent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }

        other.gameObject.GetComponentInParent<XRGrabInteractable>().enabled = false;
        
        } 
    }
}
