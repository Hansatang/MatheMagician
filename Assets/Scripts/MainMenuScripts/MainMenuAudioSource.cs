using UnityEngine;

namespace MainMenuScripts
{
    /// <summary>
    ///    Class responsible for setting volume for main menu music
    /// </summary>
    public class MainMenuAudioSource : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");
        }
    }
}