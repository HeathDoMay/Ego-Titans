using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMusic : MonoBehaviour
{
    public AudioClip musicTrack;
    private AudioSource audioSource;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();

        if (musicTrack != null)
        {
            audioSource = GetComponent<AudioSource>();

            if (musicTrack != null)
            {
                audioSource.clip = musicTrack;

                audioSource.Play();
                Debug.Log("Game music plays.");
            }
            else
            {
                Debug.LogError("No music track assigned.");
            }

            SceneManager.sceneUnloaded += OnSceneUnloaded;
        }
    }

    void OnSceneUnloaded (Scene scene)
    {
        audioSource.Stop();
        Debug.Log("Game music stopped.");
    }

    private void OnDestroy()
    {
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    
}
