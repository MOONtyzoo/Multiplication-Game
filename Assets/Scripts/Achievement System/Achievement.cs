using UnityEngine;

public abstract class Achievement : ScriptableObject
{
    public virtual string AchievementTitle => _title;
    public virtual string AchievementDescription => _description;
    public virtual Sprite AchievementThumbnail => _thumbnail;
    public bool HasAchievement => _achievementGotten;
    public virtual bool IsMaxed => _achievementGotten;
    private bool _achievementGotten = false;

    [SerializeField] private string _title;
    [SerializeField, TextArea(5, 1)] private string _description;
    [SerializeField] private Sprite _thumbnail;

    protected string AchievementSaveKey => GetType().Name;
    
    public abstract void Subscribe();
    public abstract void Unsubscribe();
    
    protected void GetAchievement()
    {
        if (IsMaxed) return;
        
        _achievementGotten = true;
        AchievementEvents.OnAchievementGet?.Invoke(new AchievementEvents.OnAchievementGetArgs
        {
            AchievementObtained = this
        });
    }

    public virtual void Save()
    {
        PlayerPrefs.SetInt(AchievementSaveKey + "_gotten", _achievementGotten ? 1 : 0);
    }

    public virtual void Load()
    {
        _achievementGotten = PlayerPrefs.GetInt(AchievementSaveKey + "_gotten") == 1 ? true : false;
    }
}
