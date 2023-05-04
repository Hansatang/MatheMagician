using System.Collections;
using UI;
using UnityEngine;
using UnityEngine.Events;

namespace Managers
{
    /// <summary>
    ///    Class responsible for counting enemies defeated, game time and Victory and Defeat States
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public int gameTime;
        public int enemyCounter;
        
        public ResultCanvas resultCanvas;
        public WaveManager waveManager;
        
        public UnityEvent resultEvent;
        public UnityEvent<int> timeUpdateEvent;
        public UnityEvent<int> enemyCounterUpdateEvent;

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
            waveManager.SetTime(gameTime);
            timeUpdateEvent?.Invoke(gameTime);
        }

        public void UpdateEnemyCounter()
        {
            enemyCounter += 1;
            enemyCounterUpdateEvent?.Invoke(enemyCounter);
        }

        public void GameIsOver()
        {
            resultEvent?.Invoke();
            resultCanvas.Defeat(gameTime, enemyCounter);
        }

        public void Victory()
        {
            resultEvent?.Invoke();
            resultCanvas.Victory(gameTime, enemyCounter);
        }
    }
}