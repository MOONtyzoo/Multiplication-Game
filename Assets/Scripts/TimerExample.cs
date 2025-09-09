using UnityEngine;

public class TimerExample : MonoBehaviour
{
    Timer timer;

    private void Awake()
    {
        timer = new Timer(this);
    }

    private void Start()
    {
        // Be careful to subscribe timer events before the timer starts
        // or else it will miss the first tick.
        timer.OnTimerTicked += DoATimerThing;
        timer.OnTimerCompleted += () => Debug.Log("Timer completed!");

        timer.StartTimer(5);
    }

    private void DoATimerThing(int value)
    {
        Debug.Log("Timer: " + value.ToString());
    }
}
