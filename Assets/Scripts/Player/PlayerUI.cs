using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    private GameObject pauseMenu; 
    bool isActive = false;

    private void Awake()
    {
        pauseMenu = GameObject.Find("PauseMenu");
    }

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void OnPause()
    {
        if (isActive)
        {
            Time.timeScale = 1.0f;
            pauseMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }

        isActive = !isActive;
    }
}
