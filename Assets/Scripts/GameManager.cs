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

    private enum GameStates
    {
        Menu,
        Countdown,
        Gameplay
    }

    private GameStates currentState;

    private void Awake()
    {
        startButton.onClick.AddListener(EnterCountdown);
        gameCountdown.OnCountdownCompleted += EnterGameplay;
        quitButton.onClick.AddListener(QuitGame);
        restartButton.onClick.AddListener(EnterCountdown);
    }

    private void Start()
    {
        EnterMenu();
    }

    private void EnterMenu()
    {
        currentState = GameStates.Menu;
        screenSwitcher.SwitchScreen(ScreenTypes.Menu);
    }

    private void QuitGame()
    {
        EnterMenu();
        Application.Quit();
    }

    private void EnterCountdown()
    {
        currentState = GameStates.Countdown;
        screenSwitcher.SwitchScreen(ScreenTypes.Countdown);
        gameCountdown.StartCountdown();
    }

    private void EnterGameplay()
    {
        
        currentState = GameStates.Gameplay;
        screenSwitcher.SwitchScreen(ScreenTypes.Gameplay);
        questionHandler.GenerateQuestion();
    }
    
}
