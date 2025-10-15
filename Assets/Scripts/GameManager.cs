using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] ScreenSwitcher screenSwitcher;
    [SerializeField] GameCountdown gameCountdown;
    [SerializeField] QuestionTimer questionTimer;
    [SerializeField] QuestionHandler questionHandler;
    [SerializeField] Button startButton;
    [SerializeField] Button quitButton;
    [SerializeField] Button restartButton;
    [SerializeField] Button achievementsButton;
    [SerializeField] Button achievementsBackButton;
    [SerializeField] Button achievementsButton1;

    private void Awake()
    {
        startButton.onClick.AddListener(EnterCountdown);
        gameCountdown.OnCountdownCompleted += EnterGameplay;
        quitButton.onClick.AddListener(QuitGame);
        restartButton.onClick.AddListener(EnterCountdown);
        achievementsButton.onClick.AddListener(EnterAchievements);
        achievementsButton1.onClick.AddListener(EnterAchievements);
        achievementsBackButton.onClick.AddListener(EnterMenu);
    }

    private void Start()
    {
        EnterMenu();
    }

    private void EnterMenu()
    {
        screenSwitcher.SwitchScreen(ScreenTypes.Menu);
    }

    private void QuitGame()
    {
        EnterMenu();
        Application.Quit();
    }

    private void EnterCountdown()
    {
        screenSwitcher.SwitchScreen(ScreenTypes.Countdown);
        gameCountdown.StartCountdown();
        questionHandler.StopQuiz();
    }

    private void EnterGameplay()
    {

        screenSwitcher.SwitchScreen(ScreenTypes.Gameplay);
        questionHandler.StartQuiz();
    }


    private void EnterAchievements()
    {
        screenSwitcher.SwitchScreen(ScreenTypes.Achievements);
    }
}
