using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayerHealthBar : HealthBar
    {
        public Slider slider;
        public Gradient gradient;

        public Image fill;
        public TextMeshProUGUI healthText;
    
        public override void SetHealth(int health)
        {
            slider.value = health;
            healthText.text = slider.value + "/" + slider.maxValue;
            fill.color = gradient.Evaluate(slider.value / slider.maxValue);
        }

        public override void SetMaxHealth(int maxHealth)
        {
            slider.maxValue = maxHealth;
            healthText.text = slider.maxValue + "/" + slider.maxValue;
            fill.color = gradient.Evaluate(1f);
        }
    }
}