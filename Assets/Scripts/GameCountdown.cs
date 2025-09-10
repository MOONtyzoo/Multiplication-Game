using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCountdown : MonoBehaviour
{
    private Timer timer;
    [SerializeField] CanvasGroup menuScreen;
    [SerializeField] CanvasGroup countdownScreen;
    [SerializeField] TextMeshProUGUI countdownText;


    public void InitiateCountdownScreen()
    {
        ChangeScreen();
        timer.StartTimer(5);
    }
    private void Awake()
    {
        timer = new Timer(this);
    }

    private void Start()
    {
        
        timer.OnTimerTicked += StartCountdown;
        timer.OnTimerCompleted += () => countdownText.text = "Go";
        
    }


    private void StartCountdown(int value)
    {
        value = timer.GetTimerValue();
        countdownText.text = value.ToString();
    }

    private void ChangeScreen()
    {
        Debug.Log("ChangeScreen");
        menuScreen.alpha = 0;
        menuScreen.interactable = false;
        menuScreen.blocksRaycasts = false;
        
        countdownScreen.alpha = 1;
        countdownScreen.interactable = true;
        countdownScreen.blocksRaycasts = true;
    }
}
