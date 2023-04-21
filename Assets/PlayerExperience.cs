using System;
using Managers;
using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    private int _currentExp;
    private int _nextLevelExp = 50;
    [SerializeField] public PlayerExpBar playerExpBar;
    [SerializeField] public LevelUpManager levelUpManager;

    private void Awake()
    {
        playerExpBar.SetNextLevelExperience(_nextLevelExp);
    }

    public void AwardExperience(int worth)
    {
        _currentExp += worth*5;
        playerExpBar.SetCurrentExperience(_currentExp);
        if (_currentExp >= _nextLevelExp)
        {
            _currentExp -= _nextLevelExp;
            _nextLevelExp *= 2;
            levelUpManager.LevelUp();
            playerExpBar.SetNextLevelExperience(_nextLevelExp);
        }
    }
}