using Managers;
using UI;
using UnityEngine;

namespace Enemies
{
    public class EnemyHealth : EntityHealth
    {
        public ExpOrb experienceOrb;
        private HealthBar _healthBarBase;
        private PopUpManager _popUpManager;

        private void Awake()
        {
            _popUpManager = FindObjectOfType<PopUpManager>();
            _healthBarBase = GetComponentInChildren<HealthBarBase>();
            _healthBarBase.SetMaxHealth(maxHealth);
        }

        public override void TakeDamage(int damageTaken)
        {
            _popUpManager.ShowDamagePopUp(damageTaken.ToString(), transform.position);
            base.TakeDamage(damageTaken);
            _healthBarBase.SetHealth(currentHealth);
        }

        public override void Die()
        {
            var instantiatedObject = Instantiate(experienceOrb, transform.position, Quaternion.identity);
            instantiatedObject.SetWorth(maxHealth * 2);
            Destroy(gameObject);
        }
    }
}