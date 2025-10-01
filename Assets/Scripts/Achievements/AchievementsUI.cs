using Achievements;
using UnityEngine;

public class AchievementsUI : MonoBehaviour
{
    [SerializeField] private AchievementTracker achievementTracker;
    [SerializeField] private AchievementListItemUI achievementListItemUIPrefab;
    [SerializeField] private Transform achievementsList;

    private void Awake()
    {
        ClearAchievementObjects(); // Clear achievements manually placed in editor
        PopulateAchievementsList();
    }

    private void PopulateAchievementsList()
    {
        foreach (AchievementSO achievement in achievementTracker.GetAchievements())
        {
            AchievementListItemUI achievementUI = Instantiate(achievementListItemUIPrefab, achievementsList);
            achievementUI.TrackAchievement(achievement);
        }
    }

    private void ClearAchievementObjects()
    {
        foreach (Transform child in achievementsList.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
