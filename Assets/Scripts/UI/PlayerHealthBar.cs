using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    ///    Class responsible for health for player
    /// </summary>
    public class PlayerHealthBar : HealthBar
    {
        public Gradient gradient;
        public Image healthBar;
        public TextMeshProUGUI healthText;
        private float _currentHealthValue;
        private float _fillValue = 10, _maxFillValue = 10;
        private float _lerpSpeed;

        private void Update()
        {
            _lerpSpeed = 2f * Time.deltaTime;
            if (_fillValue > _maxFillValue) _fillValue = _maxFillValue;

            _currentHealthValue = _fillValue / _maxFillValue;
            FillHealthBar();
            ColorChanger();
        }

        /// <summary>
        ///    Uses Lerp to animate the lose of health, instead of dropping it contentiously
        /// </summary>
        private void FillHealthBar()
        {
            healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, _currentHealthValue, _lerpSpeed);
        }

        private void ColorChanger()
        {
            healthBar.color = gradient.Evaluate(_currentHealthValue);
        }

        public override void SetHealth(int health)
        {
            _fillValue = health;
            healthText.text = _fillValue.ToString();
        }

        public override void SetMaxHealth(int maxHealth)
        {
            _maxFillValue = maxHealth;
            healthText.text = _maxFillValue.ToString();
        }

        public float GetHealth()
        {
            return _currentHealthValue;
        }
    }
}