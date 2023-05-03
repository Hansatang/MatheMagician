using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    ///    Class responsible for presenting the player his experience
    /// </summary>
    public class PlayerExpBar : MonoBehaviour
    {
        public Slider slider;
        public TextMeshProUGUI expText;

        public void SetCurrentExperience(int experience)
        {
            slider.value = experience;
            expText.text = slider.value * 100 / slider.maxValue + "%";
        }

        public void SetNextLevelExperience(int maxExperience)
        {
            slider.maxValue = maxExperience;
            expText.text = slider.value / slider.maxValue + "%";
        }
    }
}