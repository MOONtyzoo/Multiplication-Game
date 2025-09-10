using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCountdown : MonoBehaviour
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
            countdownText.text = "Go!";
            OnCountdownCompleted.Invoke();
        };
    }

    public void StartCountdown()
    {
        timer.StartTimer(5);
    }

    private void UpdateText(int value)
    {
        value = timer.GetTimerValue();
        countdownText.text = value.ToString();
    }
}
