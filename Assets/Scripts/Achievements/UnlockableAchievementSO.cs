using System;
using UnityEngine;

[CreateAssetMenu(fileName="Unlockable", menuName="GameData/Achievements/Unlockable")]
public class UnlockableAchievementSO : AchievementSO
{
    private bool unlocked = false;

    public override void LoadData()
    {
        unlocked = PlayerPrefs.GetInt($"{name} - unlocked") == 1;
    }

    public override void SaveData()
    {
        PlayerPrefs.SetInt($"{name} - unlocked", unlocked ? 1 : 0);
    }
}
