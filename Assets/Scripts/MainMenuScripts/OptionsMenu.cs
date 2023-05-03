using UnityEngine;

namespace MainMenuScripts
{
    /// <summary>
    ///    Class responsible for options
    /// </summary>
    public class OptionsMenu : MonoBehaviour
    {
        public AudioSource audioSource;

        public void Back()
        {
            PlayerPrefs.SetFloat("volume", audioSource.volume);
        }
    }
}