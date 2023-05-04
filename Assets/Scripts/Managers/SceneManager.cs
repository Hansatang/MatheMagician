using Misc;
using Player;
using SO_Definitions;
using UnityEngine;

namespace Managers
{
    /// <summary>
    ///    Class responsible for managing the scenes and closing the game
    /// </summary>
    public class SceneManager : MonoBehaviour
    {
        public void StartGame(CharacterData characterData)
        {
            SelectedCharacter.selectedCharacter = characterData;
            UnityEngine.SceneManagement.SceneManager.LoadScene((int) Scenes.GameScene);
        }

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