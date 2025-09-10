using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCountdown : MonoBehaviour
{
    private Timer timer;
    [SerializeField] ScreenSwitcher screenSwitcher;
    [SerializeField] TextMeshProUGUI countdownText;


    public void InitiateCountdownScreen()
    {
        screenSwitcher.SwitchScreen(ScreenTypes.Countdown);
        timer.StartTimer(5);
    }
    private void Awake()
    {
        timer = new Timer(this);
    }

    private void Start()
    {
        
        timer.OnTimerTicked += StartCountdown;
        timer.OnTimerCompleted += () => countdownText.text = "Go!";
        
    }

    private void StartCountdown(int value)
    {
        value = timer.GetTimerValue();
        countdownText.text = value.ToString();
    }
}
