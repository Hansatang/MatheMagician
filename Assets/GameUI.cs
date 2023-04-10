using System;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI clockText;
    
    public void UpdateClock(int gameTime)
    {
        TimeSpan t = TimeSpan.FromSeconds(gameTime);
        clockText.text = $"{t.Minutes:D2}:{t.Seconds:D2}";
    }
}