using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class PlayerExpBar : MonoBehaviour
    {
        public Slider slider;
        [FormerlySerializedAs("healthText")] public TextMeshProUGUI expText;

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