using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementListItemUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Image icon;

    AchievementSO trackedAchievement;

    public void TrackAchievement(AchievementSO achievement)
    {
        trackedAchievement = achievement;
        trackedAchievement.OnValueChanged += UpdateUI;
        UpdateUI();
    }

    public void UpdateUI()
    {
        titleText.text = trackedAchievement.title;
        descriptionText.text = trackedAchievement.description;
        icon.sprite = trackedAchievement.icon;

        if (trackedAchievement is UnlockableAchievementSO)
        {

        }

        if (trackedAchievement is ProgressAchievementSO)
        {
            
        }
    }
}
