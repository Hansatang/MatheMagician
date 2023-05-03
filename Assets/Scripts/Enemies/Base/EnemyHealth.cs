using Managers;
using Misc;
using UI;
using UnityEngine;

namespace Enemies.Base
{
    public class EnemyHealth : EntityHealth
    {
        public ExpOrb experienceOrb;
        private HealthBar _healthBarBase;
        private PopUpManager _popUpManager;
        private GameManager _gameManager;
        private void Awake()
        {
            _popUpManager = FindObjectOfType<PopUpManager>();
            _gameManager = FindObjectOfType<GameManager>();
            _healthBarBase = GetComponentInChildren<HealthBarBase>();
            _healthBarBase.SetMaxHealth(maxHealth);
        }

        public override void TakeDamage(int damageTaken)
        {
            _popUpManager.ShowDamagePopUp(damageTaken.ToString(), transform.position);
            base.TakeDamage(damageTaken);
            _healthBarBase.SetHealth(currentHealth);
        }

        protected override void Die()
        {
            var instantiatedObject = Instantiate(experienceOrb, transform.position, Quaternion.identity);
            instantiatedObject.SetWorth(maxHealth * 2);
            _gameManager.UpdateEnemyCounter();
            base.Die();
        }
    }
}