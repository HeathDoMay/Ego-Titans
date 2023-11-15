using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("GravityGauntlet");


        //SceneManager.LoadScene("Gravity Gauntlet");

    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player has quit the game.");
    }

    /*
     *  public bool isStart;
        public bool isQuit;
        public bool isInstructions;
     * 
     * void OnMouseUp()
    if (isStart)
    {
        SceneManager.LoadScene("GravityGauntlet");  //start game by loading game scene

        //Debug.Log("starting");
    }

    if (isInstructions)
    {
        SceneManager.LoadScene("GravityGauntlet");
        //Debug.Log("instructions");
    }

    if (isQuit)
    {
        //Application.Quit();
        Debug.Log("quitting");
    }
    */



}

