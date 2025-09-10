using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] ScreenSwitcher screenSwitcher;
    [SerializeField] GameCountdown gameCountdown;
    [SerializeField] QuestionTimer questionTimer;
    [SerializeField] Button startButton;
    [SerializeField] Button quitButton;

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
        quitButton.onClick.AddListener(EnterMenu);
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
        questionTimer.StartCountdown();
    }
}
