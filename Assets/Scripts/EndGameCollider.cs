using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameCollider : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (FindFirstObjectByType<KarmaKeeper>().Karma > 0)
            {
                SceneManager.LoadSceneAsync(4);
            }
            else
            {
                SceneManager.LoadSceneAsync(3);
            }
        }
    }
}
