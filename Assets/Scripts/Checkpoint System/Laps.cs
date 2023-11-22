using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Laps : MonoBehaviour
{
    public int laps = 1;

    [Header("UI to Display Laps")]
    [SerializeField] private TextMeshProUGUI lapsText;

    private void Update()
    {
        if (laps <= 3)
        {
            lapsText.text = $"{laps}/3";
        }
        else
        {
            lapsText.text = "3/3";
        }
    }
}
