using System.Collections.Generic;
using UnityEngine;

public enum ScreenTypes
{
    Menu,
    Countdown,
    Game,
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
        }

        SwitchScreen(ScreenTypes.Menu);
    }

    public void SwitchScreen(ScreenTypes newScreenType)
    {
        CanvasGroup oldScreen = currentScreen;
        if (oldScreen != null)
        {
            oldScreen.alpha = 0;
            oldScreen.interactable = false;
            oldScreen.blocksRaycasts = false;
        }

        currentScreen = screensDict[newScreenType];
        if (currentScreen != null)
        {
            currentScreen.alpha = 1;
            currentScreen.interactable = true;
            currentScreen.blocksRaycasts = true;
        }
    }
}
