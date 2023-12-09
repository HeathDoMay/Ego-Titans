using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class TimerBehaviour : MonoBehaviour
{
    [SerializeField] public float durationSeconds;

    [Header("Unity Event")]
    [SerializeField] private UnityEvent onTimerEnd = null;

    private Timer timer;

    private void Start()
    {
        // create new timer
        timer = new Timer(durationSeconds);

        // subscribing to an event
        timer.OnTimerEnd += HandleTimerEnd;
    }

    // event
    private void HandleTimerEnd()
    {
        onTimerEnd.Invoke();
    }

    // ticking time every frame
    private void Update()
    {
        timer.Tick(Time.deltaTime);

        if(durationSeconds <= 0)
        {
            durationSeconds = 0;
        }
    }
}
