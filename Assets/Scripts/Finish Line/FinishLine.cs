using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finishLineText;
    [SerializeField] private GameObject restartButton;

    private void Start()
    {
        finishLineText.text = "";
        restartButton.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "PlayerOne")
        {
            Debug.Log("Player One Wins!");
            Destroy(gameObject);

            finishLineText.text = "Player One Wins!";
            restartButton.SetActive(true);
        }

        if(other.gameObject.name == "PlayerTwo")
        {
            Debug.Log("Player Two Wins!");
            Destroy(gameObject);

            finishLineText.text = "Player Two Wins!";
            restartButton.SetActive(true);

        }
    }
}