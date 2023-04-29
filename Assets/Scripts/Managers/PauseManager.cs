using UnityEngine;

namespace Managers
{
    public class PauseManager : MonoBehaviour
    {
        public static bool GamePaused;
        public static bool LevelUpPaused;
        public GameObject menuPanel;
        public GameObject levelUpPanel;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) ManualPause();

            if (!GamePaused && !LevelUpPaused)
                Resume();
            else if (LevelUpPaused)
                LevelUpPause();
            else if (GamePaused) Time.timeScale = 0f;
        }

        public void ManualPause()
        {
            GamePaused = !GamePaused;
            menuPanel.SetActive(GamePaused);
        }

        private void LevelUpPause()
        {
            levelUpPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        private void Resume()
        {
            menuPanel.SetActive(false);
            levelUpPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}