using System;
using UnityEngine;


public abstract class AchievementSO : ScriptableObject
{
    [SerializeField] public string title;
    [SerializeField, TextArea(5, 1)] public string description;
    [SerializeField] public Sprite icon;

    public event Action OnValueChanged;

    public abstract void SaveData();
    public abstract void LoadData();
}
