using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public AudioSource audioSource;
    
    public void SetVolume()
    {
        PlayerPrefs.SetFloat("volume", audioSource.volume);
    }
}
