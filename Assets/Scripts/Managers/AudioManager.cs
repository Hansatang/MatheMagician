using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {
        public List<AudioSource> activeAudioSources = new();
        private void Start()
        {
            foreach (var audioSource in activeAudioSources)
            {
                audioSource.volume= PlayerPrefs.GetFloat("volume");
            }
        }
    }
}