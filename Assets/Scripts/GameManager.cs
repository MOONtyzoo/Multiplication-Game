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
    private GameStates gameState;

    private void Awake()
    {
        menuStartButton.onClick.AddListener(() => SwitchState(GameStates.Options));
        settingsStartButton.onClick.AddListener(() => SwitchState(GameStates.Countdown));
        gameCountdown.OnCountdownCompleted += () => SwitchState(GameStates.Game);

        // Called at the end of gameplay
        AchievementEvents.OnRoundEnded += _ => SwitchState(GameStates.Results);

        gameplayQuitButton.onClick.AddListener(QuitGame);
        resultsQuitButton.onClick.AddListener(QuitGame);

        gameplayRestartButton.onClick.AddListener(() => SwitchState(GameStates.Options));
        resultsRestartButton.onClick.AddListener(() => SwitchState(GameStates.Options));

        achievementsButton.onClick.AddListener(() => SwitchState(GameStates.Achievements));
        achievementsBackButton.onClick.AddListener(() => SwitchState(GameStates.MainMenu));
    }

    private void Start()
    {
        SwitchState(GameStates.MainMenu);
    }

    private void SwitchState(GameStates newState)
    {
        switch (newState)
        {
            case GameStates.MainMenu:
                EnterMenu();
                break;
            case GameStates.Options:
                EnterSettings();
                break;
            case GameStates.Game:
                EnterGameplay();
                break;
            case GameStates.Results:
                EnterResults();
                break;
            case GameStates.Achievements:
                EnterAchievements();
                break;
            case GameStates.Countdown:
                EnterCountdown();
                break;
        }
        gameState = newState;
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
