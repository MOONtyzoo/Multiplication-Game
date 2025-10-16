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

    [SerializeField] Button gameplayQuitButton;
    [SerializeField] Button resultsQuitButton;

    [SerializeField] Button gameplayRestartButton;
    [SerializeField] Button resultsRestartButton;

    [SerializeField] Button achievementsButton;
    [SerializeField] Button achievementsBackButton;

    private void Awake()
    {
        startButton.onClick.AddListener(EnterCountdown);
        gameCountdown.OnCountdownCompleted += EnterGameplay;

        // Called at the end of gameplay
        AchievementEvents.OnRoundEnded += (AchievementEvents.OnRoundEndedArgs args) => EnterResults();

        gameplayQuitButton.onClick.AddListener(QuitGame);
        resultsQuitButton.onClick.AddListener(QuitGame);

        gameplayRestartButton.onClick.AddListener(EnterCountdown);
        resultsRestartButton.onClick.AddListener(EnterCountdown);

        achievementsButton.onClick.AddListener(EnterAchievements);
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
        AchievementEvents.OnRoundStarted?.Invoke();
    }

    private void EnterResults()
    {
        screenSwitcher.SwitchScreen(ScreenTypes.Results);
    }

    private void EnterAchievements()
    {
        screenSwitcher.SwitchScreen(ScreenTypes.Achievements);
    }
}
