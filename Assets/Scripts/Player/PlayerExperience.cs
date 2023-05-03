using Managers;
using UI;
using UnityEngine;

namespace Player
{
    /// <summary>
    ///    Class responsible for managing player experience and invoking the level up in Manager
    /// </summary>
    public class PlayerExperience : MonoBehaviour
    {
        [SerializeField] public PlayerExpBar playerExpBar;
        [SerializeField] public LevelUpManager levelUpManager;
        private int _currentExp;
        private int _nextLevelExp = 50;

        private void Awake()
        {
            playerExpBar.SetNextLevelExperience(_nextLevelExp);
        }

        public void AwardExperience(int worth)
        {
            _currentExp += worth * 5;
            playerExpBar.SetCurrentExperience(_currentExp);
            if (_currentExp >= _nextLevelExp)
            {
                _currentExp -= _nextLevelExp;
                _nextLevelExp *= 2;
                playerExpBar.SetNextLevelExperience(_nextLevelExp);
                levelUpManager.LevelUp();
            }

            playerExpBar.SetCurrentExperience(_currentExp);
        }
    }
}