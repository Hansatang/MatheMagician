using System;
using TMPro;
using UnityEngine;

public class DefeatCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI summaryText;

    public void SetStatistics(int gameTime, int enemyCounter)
    {
        var t = TimeSpan.FromSeconds(gameTime);
        summaryText.text = "Your survived " + $"{t.Minutes:D2}:{t.Seconds:D2} " + ", destroying " + enemyCounter +
                           " enemies.";
    }
}