using UnityEngine;

namespace UI
{
    /// <summary>
    ///    Class responsible for for saving Volume
    /// </summary>
    public class OptionsMenu : MonoBehaviour
    {
        public AudioSource audioSource;
    
        public void SetVolume()
        {
            PlayerPrefs.SetFloat("volume", audioSource.volume);
            PlayerPrefs.Save();
        }
    }
}
