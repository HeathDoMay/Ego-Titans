using UnityEngine;
using TMPro;
using System.Collections;

public class StartGame : MonoBehaviour
{
    [Header("Player Controls Array")]
    [SerializeField] private ShipController[] shipController;

    [Header("AI Controller")]
    [SerializeField] private AIShip aiPlayer;

    [Header("Timer Reference")]
    [SerializeField] private TimerBehaviour timerBehaviour;

    [Header("Timer Text")]
    [SerializeField] private TextMeshProUGUI countDownText;

    public ArdunioController ardunioController;

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(8);
        countDownText.enabled = false;
    }

    private void Start()
    {
        StartCoroutine(waiter());

        for (int i = 0; i < shipController.Length; i++)
        {
            shipController[i].enabled = false;
        }

        aiPlayer.enabled = false;
        ardunioController.enabled = false;
    }

    private void Update()
    {
        timerBehaviour.durationSeconds -= Time.deltaTime;
        float roundedTime = Mathf.RoundToInt(timerBehaviour.durationSeconds);
        
        countDownText.text = roundedTime.ToString();

        if(roundedTime <= 0)
        {
            countDownText.text = "GO!";
        }
    }

    public void StartRace()
    {
        for (int i = 0; i < shipController.Length; i++)
        {
            shipController[i].enabled = true;
        }

        aiPlayer.enabled = true;
        ardunioController.enabled = true;
    }
}
