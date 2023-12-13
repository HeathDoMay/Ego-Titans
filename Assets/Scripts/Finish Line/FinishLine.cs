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

        finishLineText.color = Color.white;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "PlayerOne")
        {
            if(playerOneLaps.laps == trackCheckpoints.lapsToComplete) 
            {
                finishLineText.text = "Player One Wins!";
                finishLineText.color = new Color32(233, 154, 34, 255);
                restartButton.SetActive(true);

                Destroy(gameObject);
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
                finishLineText.text = "Player Two Wins!";
                finishLineText.color = new Color32(215, 75, 255, 255);
                restartButton.SetActive(true);

                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Complete more laps!");
            }
        }
    }
}
