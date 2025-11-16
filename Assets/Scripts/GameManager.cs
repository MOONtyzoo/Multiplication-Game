using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ScreenSwitcher screenSwitcher;
    [SerializeField] private GameCountdown gameCountdown;
    [SerializeField] private QuestionTimer questionTimer;
    [SerializeField] private QuizManager quizManager;
    
    [SerializeField] private Button menuStartButton;
    [SerializeField] private Button settingsStartButton;

    [SerializeField] private Button gameplayQuitButton;
    [SerializeField] private Button resultsQuitButton;

    [SerializeField] private Button gameplayRestartButton;
    [SerializeField] private Button resultsRestartButton;

    [SerializeField] private Button achievementsButton;
    [SerializeField] private Button achievementsBackButton;

    private void Awake()
    {
        menuStartButton.onClick.AddListener(EnterSettings);
        settingsStartButton.onClick.AddListener(EnterCountdown);
        gameCountdown.OnCountdownCompleted += EnterGameplay;

        // Called at the end of gameplay
        AchievementEvents.OnRoundEnded += _ => EnterResults();

        gameplayQuitButton.onClick.AddListener(QuitGame);
        resultsQuitButton.onClick.AddListener(QuitGame);

        gameplayRestartButton.onClick.AddListener(EnterSettings);
        resultsRestartButton.onClick.AddListener(EnterSettings);

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

    private void EnterSettings()
    {
        screenSwitcher.SwitchScreen(ScreenTypes.Settings);
    }

    private void EnterCountdown()
    {
        screenSwitcher.SwitchScreen(ScreenTypes.Countdown);
        gameCountdown.StartCountdown();
        quizManager.StopQuiz();
    }

    private void EnterGameplay()
    {

        screenSwitcher.SwitchScreen(ScreenTypes.Gameplay);
        quizManager.StartQuiz();
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
