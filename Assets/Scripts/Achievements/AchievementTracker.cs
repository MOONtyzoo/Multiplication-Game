using System.Collections.Generic;
using UnityEngine;

namespace Achievements
{
    public class AchievementTracker : MonoBehaviour
    {
        [SerializeField] private List<AchievementSO> achievements;

        public List<AchievementSO> GetAchievements() => achievements;
    }
}
