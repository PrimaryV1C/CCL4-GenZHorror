using UnityEngine;
using UnityEngine.Events;

public class DialogInitiator : MonoBehaviour
{

    public UnityEvent isTalking;

    public void AttemptDialog() {
        // if player is in zone
        isTalking.Invoke();
    }

}