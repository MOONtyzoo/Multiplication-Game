using System.Collections.Generic;
using UnityEngine;

public enum ScreenTypes
{
    Menu,
    Countdown,
    Gameplay,
}

public class ScreenSwitcher : MonoBehaviour
{
    [SerializeField] private List<CanvasGroup> screens = new List<CanvasGroup>(3);
    private Dictionary<ScreenTypes, CanvasGroup> screensDict = new Dictionary<ScreenTypes, CanvasGroup>();

    private CanvasGroup currentScreen;

    private void Awake()
    {
        for (int i = 0; i < screens.Count; i++)
        {
            ScreenTypes screenType = (ScreenTypes)i;
            screensDict.Add(screenType, screens[i]);
            SetScreenEnabled(screens[i], false);
        }

        SwitchScreen(ScreenTypes.Menu);
    }

    public void SwitchScreen(ScreenTypes newScreenType)
    {
        CanvasGroup oldScreen = currentScreen;
        if (oldScreen != null)
        {
            SetScreenEnabled(currentScreen, false);
        }

        currentScreen = screensDict[newScreenType];
        if (currentScreen != null)
        {
            SetScreenEnabled(currentScreen, true);
        }
    }

    private void SetScreenEnabled(CanvasGroup screen, bool enabled)
    {
        screen.alpha = enabled ? 1 : 0;
        screen.blocksRaycasts = enabled;
        screen.interactable = enabled;
    }
}
