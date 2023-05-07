using System.Collections;
using UnityEngine;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {
        public AudioSource ambientAudioSources;
        public AudioSource playerHitAudioSources;

        private void Start()
        {
            ambientAudioSources.volume = PlayerPrefs.GetFloat("volume");
            playerHitAudioSources.volume = PlayerPrefs.GetFloat("volume");
        }

        public void NewAmbientClip(AudioClip clip)
        {
            StartCoroutine(MusicSwap(clip));
        }

        private IEnumerator MusicSwap(AudioClip clip)
        {
            float fadingTimeDown = 1f;
            float elapsedTimeDown = 0;

            while (elapsedTimeDown < fadingTimeDown)
            {
                ambientAudioSources.volume =
                    Mathf.Lerp(ambientAudioSources.volume, 0, elapsedTimeDown / fadingTimeDown);
                elapsedTimeDown += Time.deltaTime;
                yield return null;
            }

            ambientAudioSources.clip = clip;
            ambientAudioSources.Play();

            float fadingTimeUp = 1f;
            float elapsedTimeUp = 0;
            while (elapsedTimeUp < 2 * fadingTimeUp)
            {
                ambientAudioSources.volume =
                    Mathf.Lerp(0, PlayerPrefs.GetFloat("volume"), elapsedTimeUp / fadingTimeUp);
                elapsedTimeUp += Time.deltaTime;
                yield return null;
            }
        }
    }
}