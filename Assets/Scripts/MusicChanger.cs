using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicChanger : MonoBehaviour
{
    public AkEvent audioEvent;
    private static MusicChanger instance = null; 

    private bool audioShouldPersist = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
            Debug.Log("MusicChanger created");
            PlayOliverBackground();  
      }

        else
        { 
            Debug.Log("MusicChanger already exists, destroying new instance");
            Destroy(gameObject);
        }
    }

    void PlayOliverBackground()
    {
        AkSoundEngine.PostEvent("Play_background_Oliver", gameObject); 
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("MusicChanger: Scene loaded - " + scene.name);
        if (scene.buildIndex == 0 || scene.buildIndex == 2)
        {
            Debug.Log("MusicChanger: Music should persist");
            audioShouldPersist = true;
        }
        else
        {
            Debug.Log("MusicChanger: Stopping music and destroying instance");
            audioShouldPersist = false;
            AkSoundEngine.PostEvent("Stop_background_Oliver", gameObject); 
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Destroy(gameObject);
        }

    }

}

    



