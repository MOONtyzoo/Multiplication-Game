using UnityEngine;

public abstract class Achievement : ScriptableObject
{
    public virtual string AchievementTitle => GetType().ToString();
    public virtual string AchievementDescription => Description;
    public virtual Sprite AchievementThumbnail => Thumbnail;
    private bool _achievementGotten = false;
    
    [TextArea]
    [SerializeField] private string Description;
    [SerializeField] private Sprite Thumbnail;

    protected string AchievementSaveKey => GetType().Name;
    
    public abstract void Subscribe();
    public abstract void Unsubscribe();
    
    protected void GetAchievement()
    {
        _achievementGotten = true;
        AchievementEvents.OnAchievementGet?.Invoke(new AchievementEvents.OnAchievementGetArgs
        {
            AchievementObtained = this
        });
    }
    public bool HasAchievement() => _achievementGotten;

    public virtual void Save()
    {
        PlayerPrefs.SetInt(AchievementSaveKey + "_gotten", _achievementGotten ? 1 : 0);
    }

    public virtual void Load()
    {
        _achievementGotten = PlayerPrefs.GetInt(AchievementSaveKey + "_gotten") == 1 ? true : false;
    }
}
