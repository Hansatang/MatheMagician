using UnityEngine;

namespace UI
{
    /// <summary>
    ///    Class responsible for health for entities
    /// </summary>
    public class HealthBarBase : HealthBar
    {
        [SerializeField] private Transform bar;
        public GameObject healthSprite;
        private int _maximumHealth;

        public override void SetHealth(int currentHealth)
        {
            healthSprite.SetActive(true);
            var proportion = (float) currentHealth / _maximumHealth;
            bar.transform.localScale = new Vector3(proportion, 1, 1);
        }

        public override void SetMaxHealth(int maxHealth)
        {
            _maximumHealth = maxHealth;
        }
    }
}