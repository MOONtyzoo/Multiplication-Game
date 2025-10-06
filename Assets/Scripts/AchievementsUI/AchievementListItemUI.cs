using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementListItemUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Image icon;
    private CanvasGroup canvasGroup;

    Achievement trackedAchievement;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void TrackAchievement(Achievement achievement)
    {
        trackedAchievement = achievement;
        AchievementEvents.OnAchievementGet += _ => UpdateUI();
        UpdateUI();
    }

    public void UpdateUI()
    {
        titleText.text = trackedAchievement.AchievementTitle;
        descriptionText.text = trackedAchievement.Description;
        icon.sprite = trackedAchievement.Thumbnail;
    }

    public void SetOpacity(float newOpacity)
    {
        canvasGroup.alpha = Mathf.Clamp(newOpacity, 0.0f, 1.0f);
    }
}
