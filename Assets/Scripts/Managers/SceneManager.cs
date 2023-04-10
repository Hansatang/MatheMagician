using UnityEngine;

namespace Managers
{
    public class SceneManager : MonoBehaviour
    {
        public void Menu()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene((int) Scenes.MainMenuScene);
        }

        public void Restart()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene((int) Scenes.GameScene);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
