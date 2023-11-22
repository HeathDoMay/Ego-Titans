using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishLine : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI finishLineText;
    [SerializeField] private GameObject restartButton;

    [Header("Player Laps Reference")]
    [SerializeField] private Laps playerOneLaps;
    [SerializeField] private Laps playerTwoLaps;

    [Header("Checkpoint System Reference")]
    [SerializeField] private TrackCheckpoints trackCheckpoints;

    private void Start()
    {
        finishLineText.text = "";
       // restartButton.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "PlayerOne")
        {
            if(playerOneLaps.laps == trackCheckpoints.lapsToComplete) 
            {
                finishLineText.text = $"{other.gameObject.name} Wins!";
                restartButton.SetActive(true);
            }
            else
            {
                Debug.Log("Complete more laps!");
            }
        }

        if(other.gameObject.name == "PlayerTwo")
        {
            if (playerTwoLaps.laps == trackCheckpoints.lapsToComplete)
            {
                finishLineText.text = $"{other.gameObject.name} Wins!";
                restartButton.SetActive(true);
            }
            else
            {
                Debug.Log("Complete more laps!");
            }
        }
    }
}
