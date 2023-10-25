using System.Collections;
using System.Collections.Generic;
using System;

public class Timer
{
    // remainging seconds
    public float RemainingSeconds { get; set; }

    // C# event
    public event Action OnTimerEnd;

    // constructor to set time
    public Timer(float durationSeconds)
    {
        RemainingSeconds = durationSeconds;
    }

    // function to tick time down
    public void Tick(float deltaTime)
    {
        // if == to 0 then return
        if (RemainingSeconds == 0f)
            return;

        // subtract the remaining seconds by the delta time
        RemainingSeconds -= deltaTime;

        ChckForTimerEnd();
    }

    private void ChckForTimerEnd()
    {
        // if timer is greater than 0 return
        if (RemainingSeconds > 0f)
            return;

        // resetting time back to 0
        RemainingSeconds = 0f;

        // calling the C# event
        OnTimerEnd?.Invoke();
    }
}
