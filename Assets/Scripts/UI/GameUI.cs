using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI clockText;
        [SerializeField] private TextMeshProUGUI counterText;
        

        public void UpdateClock(int gameTime)
        {
            var t = TimeSpan.FromSeconds(gameTime);
            clockText.text = $"{t.Minutes:D2}:{t.Seconds:D2}";
        }

        public void UpdateCounter(int enemyCounter)
        {
            counterText.text = enemyCounter.ToString();
        }
    }
}