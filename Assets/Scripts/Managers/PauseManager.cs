using UnityEngine;

namespace Managers
{
    /// <summary>
    ///    Class responsible for all type of game pauses
    /// </summary>
    public class PauseManager : MonoBehaviour
    {
        private bool _gamePaused;
        private bool _levelUpPaused;
        private bool _gameOver;
        public GameObject menuPanel;

        private void Start()
        {
            _gamePaused = false;
            _levelUpPaused = false;
            _gameOver = false;
        }

        private void Update()
        {
            if (_gameOver) return;

            if (Input.GetKeyDown(KeyCode.Escape)) ManualPause();
            if (!_gamePaused && !_levelUpPaused)
                Time.timeScale = 1f;
        }

        public void ManualPause()
        {
            _gamePaused = !_gamePaused;
            menuPanel.SetActive(_gamePaused);
            Time.timeScale = 0f;
        }

        public void LevelUpPause()
        {
            _levelUpPaused = true;
            Time.timeScale = 0f;
        }

        public void LevelUpUnPause()
        {
            _levelUpPaused = false;
        }


        public void GameIsOver()
        {
            _gameOver = true;
            Time.timeScale = 0f;
        }
    }
}