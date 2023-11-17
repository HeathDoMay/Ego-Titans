using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finishLineText;
    [SerializeField] private GameObject restartButton;

    public PlayerLaps[] playerLaps;

    private void Start()
    {
        finishLineText.text = "";
       // restartButton.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        for(int i = 0; i < playerLaps.Length; i++)
        {
            if (playerLaps[i].laps != 4) 
            {
                return;
            }
            else
            {
                if (other.TryGetComponent<ShipController>(out ShipController shipcontroller))
                {
                    finishLineText.text = $"{shipcontroller.gameObject.name} Wins!";
                    restartButton.SetActive(true);
                }
            }
        }
    }
}
