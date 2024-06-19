using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public AK.Wwise.Bank Start_Soundbank;

        public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

        public void Instructions()
    {
        SceneManager.LoadSceneAsync(2);
    }
  
    public void StartFirstScene()

    {

        if (Start_Soundbank != null)
        {
            AkSoundEngine.PostEvent("Stop_background_Oliver", gameObject);
            Start_Soundbank.Unload();
            SceneManager.LoadSceneAsync(1);
        }
        
        
    }




}
