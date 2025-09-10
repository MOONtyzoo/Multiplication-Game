using System;
using TMPro;
using UnityEngine;

public class GameCountdown : MonoBehaviour
{
    public event Action OnCountdownCompleted;

    private Timer timer;
    [SerializeField] private TextMeshProUGUI countdownText;

    private void Awake()
    {
        timer = new Timer(this);
    }

    private void Start()
    {

        timer.OnTimerTicked += UpdateText;
        timer.OnTimerCompleted += () =>
        {
            OnCountdownCompleted.Invoke();
        };
    }

    public void StartCountdown()
    {
        timer.StartTimer(6);
    }

    private void UpdateText(int value)
    {
        if (timer.GetTimerValue() > 1)
        {
            countdownText.text = (value-1).ToString();   
        }
        else
        {
            countdownText.text = "Go!";
        }
    }
}
