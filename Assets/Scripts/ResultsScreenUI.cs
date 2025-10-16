using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultsScreenUI : MonoBehaviour
{
    [SerializeField] private GameObject achievementResultsPanel;
    [SerializeField] private AchievemtnsUIResults achievementResults;
    [SerializeField] private TextMeshProUGUI roundResultsText;
    [SerializeField] private TextMeshProUGUI perfectRoundText;

    private void Awake()
    {
        AchievementEvents.OnRoundStarted += OnRoundStarted;
        AchievementEvents.OnAchievementGet += OnAchievementGet;
        AchievementEvents.OnRoundEnded += OnRoundEnded;
    }

    private void OnRoundStarted()
    {
        SetAchievementsPanelDisplayed(false);
    }
    
    private void OnAchievementGet(AchievementEvents.OnAchievementGetArgs args)
    {
        SetAchievementsPanelDisplayed(true);
    }

    private void OnRoundEnded(AchievementEvents.OnRoundEndedArgs args)
    {
        roundResultsText.text = $"You got {args.NumCorrectQuestions} / {args.NumQuestionsAnswered} questions correct!";

        bool isPerfectRound = args.NumCorrectQuestions == args.NumQuestionsAnswered;
        perfectRoundText.gameObject.SetActive(isPerfectRound);
    }

    private void SetAchievementsPanelDisplayed(bool isDisplayed)
    {
        CanvasGroup canvasGroup = achievementResultsPanel.GetComponent<CanvasGroup>();
        canvasGroup.alpha = isDisplayed ? 1.0f : 0.0f;
        canvasGroup.interactable = isDisplayed;
        canvasGroup.blocksRaycasts = isDisplayed;

        LayoutElement layoutElement = achievementResultsPanel.GetComponent<LayoutElement>();
        layoutElement.ignoreLayout = !isDisplayed;
    }
}
