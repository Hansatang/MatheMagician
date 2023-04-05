using UnityEngine;

namespace MainMenuScripts
{
    public class OptionsMenu : MonoBehaviour
    {
        public AudioSource audioSource;

        public void Back()
        {
            PlayerPrefs.SetFloat("volume", audioSource.volume);
        }
    }
}