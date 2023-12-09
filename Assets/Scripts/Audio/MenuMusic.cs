using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour
{
    public AudioClip musicTrack;
    private AudioSource audioSource;
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();

        if (musicTrack != null)
        {
            audioSource.clip = musicTrack;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("No music track assigned to Menu");
        }

        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    void OnSceneUnloaded(Scene scene)
    {
        audioSource.Stop();
        Debug.LogError("Main Menu music stops");
    }

    void OnDestroy()
    {
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
       
    }

}
