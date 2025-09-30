using System;
using UnityEngine;


public abstract class AchievementSO : ScriptableObject
{
    [SerializeField] protected string title;
    [SerializeField, TextArea(5, 1)] protected string description;
    [SerializeField] protected Sprite icon;

    public abstract void SaveData();
    public abstract void LoadData();
}
