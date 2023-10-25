using UnityEngine;
using TMPro;
using System.Collections;

public class StartGame : MonoBehaviour
{
    [SerializeField] private PlayerMovement[] playerMovement;
    [SerializeField] private TextMeshProUGUI countDownText;

    [SerializeField] private TimerBehaviour timerBehaviour;
    
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(8);
        countDownText.enabled = false;
        // Destroy(this);
    }

    private void Start()
    {
        StartCoroutine(waiter());
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
        for (int i = 0; i < playerMovement.Length; i++)
        {
            playerMovement[i].enabled = true;
        }
    }
}
