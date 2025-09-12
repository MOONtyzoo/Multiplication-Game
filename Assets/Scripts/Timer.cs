using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Simple timer that counts down from a specified duration to 0.
/// </summary>
public class Timer
{
    public event Action OnTimerStarted;
    public event Action<int> OnTimerTicked;
    public event Action OnTimerCompleted;

    private int timer = 0;
    private MonoBehaviour source;
    private Coroutine runningCoroutine;

    public Timer(MonoBehaviour source)
    {
        this.source = source;
    }

    public void StartTimer(int duration)
    {
        if (runningCoroutine != null) source.StopCoroutine(runningCoroutine);
        runningCoroutine = source.StartCoroutine(TimerCoroutine(duration));
    }

    private IEnumerator TimerCoroutine(int duration)
    {
        OnTimerStarted?.Invoke();

        timer = duration;
        while (timer > 0)
        {
            OnTimerTicked?.Invoke(timer);
            yield return new WaitForSeconds(1);
            timer--;
        }

        OnTimerCompleted?.Invoke();
    }

    public int GetTimerValue() => timer;
    public bool IsTimerRunning() => runningCoroutine != null;
}
