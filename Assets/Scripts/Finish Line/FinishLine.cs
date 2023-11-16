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
       // restartButton.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ShipController>(out ShipController shipcontroller))
        {
            finishLineText.text = $"{shipcontroller.gameObject.name} Wins!";
            restartButton.SetActive(true);
        }
    }
}
