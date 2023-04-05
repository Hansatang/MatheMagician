using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenuScripts
{
    public class MainMenu : MonoBehaviour
    {
        public void Play()
        {
            SceneManager.LoadScene((int) Scenes.GameScene);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}