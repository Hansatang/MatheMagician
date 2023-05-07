using UnityEngine;
using UnityEngine.UI;

namespace MainMenuScripts
{
    /// <summary>
    ///    Class responsible for Volume Slider
    /// </summary>
    public class VolumeSliderSetter : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Slider>().value = PlayerPrefs.GetFloat("volume");
        }
    }
}