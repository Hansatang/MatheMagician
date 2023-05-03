using System;
using UnityEngine;

namespace Managers
{
    /// <summary>
    ///    Class responsible for all type of game pauses
    /// </summary>
    public class PauseManager : MonoBehaviour
    {
        public static bool GamePaused;
        public static bool LevelUpPaused;
        public static bool GameOver;
        public GameObject menuPanel;
        public GameObject levelUpPanel;
        public GameObject defeatPanel;

        private void Start()
        {
            GamePaused = false;
            LevelUpPaused = false;
            GameOver = false;
        }

        private void Update()
        {
            if (!GameOver)
            {
                if (Input.GetKeyDown(KeyCode.Escape)) ManualPause();
                if (!GamePaused && !LevelUpPaused)
                    Time.timeScale = 1f;
            }
        }

        public void ManualPause()
        {
            GamePaused = !GamePaused;
            menuPanel.SetActive(GamePaused);
            Time.timeScale = 0f;
        }

        public void LevelUpPause()
        {
            LevelUpPaused = true;
            levelUpPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        public void LevelUpUnPause()
        {
            LevelUpPaused = false;
            levelUpPanel.SetActive(false);
        }


        public void GameIsOver()
        {
            Time.timeScale = 0f;
            GameOver = true;
            defeatPanel.SetActive(true);
        }
    }
}