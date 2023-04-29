using UnityEngine;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");
        }
    }
}