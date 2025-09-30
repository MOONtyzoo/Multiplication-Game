using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Progressable", menuName="GameData/Achievements/Progressable")]
public class ProgressAchievementSO : AchievementSO
{
    [SerializeField] private List<int> levelMilestones;
    private int value = 0;

    public int GetCurrentLevel()
    {
        for (int i = levelMilestones.Count - 1; i >= 0; i--)
        {
            int level = i + 1;
            if (value >= levelMilestones[i])
            {
                return level;
            }
        }

        return 0;
    }

    public int GetMaxLevel()
    {
        return levelMilestones.Count;
    }

    public int GetValue()
    {
        return value;
    }

    public override void LoadData()
    {
        value = PlayerPrefs.GetInt($"{name} - progress");
    }

    public override void SaveData()
    {
        PlayerPrefs.SetInt($"{name} - progress", value);
    }
}
