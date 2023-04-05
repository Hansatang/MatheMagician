using Scipts.MainMenu;
using UnityEngine;
using UnityEngine.SceneManagement;

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