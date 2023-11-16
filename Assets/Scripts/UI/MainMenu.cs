using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Ariah-Prototype");
    }

    public void Options()
    {
        Debug.Log("Options button clicked");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Application quit");
    }

}
