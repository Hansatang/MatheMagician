using UnityEngine;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {
        void Start()
        {
            GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");
        }
    }
}