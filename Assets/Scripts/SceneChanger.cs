using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
  
    public void ChangeScene()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
