using System.Collections;
using UI;
using UnityEngine;
using UnityEngine.Events;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public GameUI gameUI;
        public DefeatCanvas defeatCanvas;
        public WaveSpawner waveSpawner;

        public int gameTime;
        public int enemyCounter;
        public UnityEvent gameOverEvent;

        public void Start()
        {
            StartCoroutine(Time());
        }

        private IEnumerator Time()
        {
            while (true)
            {
                TimeCount();

                yield return new WaitForSeconds(1);
            }
        }

        private void TimeCount()
        {
            gameTime += 1;
            waveSpawner.SetTime(gameTime);
            gameUI.UpdateClock(gameTime);
        }

        public void UpdateEnemyCounter()
        {
            enemyCounter += 1;
            gameUI.UpdateCounter(enemyCounter);
        }

        public void GameIsOver()
        {
            gameOverEvent?.Invoke();
            defeatCanvas.SetStatistics(gameTime, enemyCounter);
        }
    }
}