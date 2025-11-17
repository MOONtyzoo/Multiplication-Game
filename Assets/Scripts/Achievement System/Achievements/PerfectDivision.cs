using UnityEngine;

[CreateAssetMenu(menuName = "Achievements/" + nameof(PerfectDivision), fileName = nameof(PerfectDivision))]
public class PerfectDivision : Achievement
{
    public override void Subscribe()
    {
        AchievementEvents.OnRoundEnded += OnRoundEnded;
    }
    public override void Unsubscribe()
    {
        AchievementEvents.OnRoundEnded -= OnRoundEnded;
    }

    private void OnRoundEnded(AchievementEvents.OnRoundEndedArgs obj)
    {
        if ((obj.NumCorrectQuestions == obj.NumQuestionsAnswered) && (obj.QuizType == QuizManager.QuizTypes.Division))
        {
            GetAchievement();
        }
    }
}