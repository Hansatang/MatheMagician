using Managers;
using UnityEngine;

namespace MainMenuScripts
{
    public class MainMenu : MonoBehaviour
    {
        public void Play()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene((int) Scenes.GameScene);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}