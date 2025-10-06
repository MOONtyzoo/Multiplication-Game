using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionTimer : MonoBehaviour
{
    public event Action OnCountdownCompleted;

    private Timer timer;
    [SerializeField] TextMeshProUGUI countdownText;

    private void Awake()
    {
        timer = new Timer(this);
    }

    private void Start()
    {
        timer.OnTimerTicked += UpdateText;
        timer.OnTimerCompleted += () =>
        {
            countdownText.text = "Times up!";
            OnCountdownCompleted?.Invoke();
        };
    }

    public void StartCountdown() => timer.StartTimer(10);

    public int GetTimeRemaining() => timer.GetTimerValue();

    private void UpdateText(int value)
    {
        value = timer.GetTimerValue();
        countdownText.text = "Timer: " + value.ToString();
    }
    
}
