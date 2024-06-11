using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
        public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

        public void Instructions()
    {
        SceneManager.LoadSceneAsync(1);
    }
  
    public void StartFirstScene()
    {
        SceneManager.LoadSceneAsync(2);
    }




}
