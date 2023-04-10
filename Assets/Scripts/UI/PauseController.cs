using UnityEngine;

namespace UI
{
    public class PauseController : MonoBehaviour
    {
        public GameObject pausePanel;

        private void Update()
        {
            if (Managers.GameManager.GamePaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }


        private void Pause()
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
            Managers.GameManager.GamePaused = true;
        }

        public void Resume()
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
            Managers.GameManager.GamePaused = false;
        }
    }
}