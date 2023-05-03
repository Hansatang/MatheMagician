using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ResultCanvas : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI summaryText;
        [SerializeField] private TextMeshProUGUI resultText;

        public void Defeat(int gameTime, int enemyCounter)
        {
            resultText.text = "You have lost...  But you can try again";
            SetStatistics(gameTime, enemyCounter);
        }

        public void Victory(int gameTime, int enemyCounter)
        {
            resultText.text = "You have won, thanks for playing this little game";
            SetStatistics(gameTime, enemyCounter);
        }


        private void SetStatistics(int gameTime, int enemyCounter)
        {
            var t = TimeSpan.FromSeconds(gameTime);
            summaryText.text = "Your survived " + $"{t.Minutes:D2}:{t.Seconds:D2} " + ", destroying " + enemyCounter +
                               " enemies.";
        }
    }
}