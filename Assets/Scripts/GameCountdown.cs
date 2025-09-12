using System;
using TMPro;
using UnityEngine;

public class GameCountdown : MonoBehaviour
{
    public event Action OnCountdownCompleted;

    private Timer timer;
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        timer = new Timer(this);
    }

    private void Start()
    {

        timer.OnTimerTicked += (value) =>
        {
            animator.Play("CountdownPulse", 0, 0.0f);
            audioSource.Play();
            UpdateText(value);
        };
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
            countdownText.text = (value - 1).ToString();
        }
        else
        {
            countdownText.text = "Go!";
        }
    }
}
