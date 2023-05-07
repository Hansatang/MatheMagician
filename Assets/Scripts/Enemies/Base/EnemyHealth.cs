using Managers;
using Misc;
using UI;
using UnityEngine;
using UnityEngine.Events;

namespace Enemies.Base
{
    /// <summary>
    ///     Class responsible for managing Enemy health, including death logic
    /// </summary>
    public class EnemyHealth : EntityHealth
    {
        private HealthBar _healthBarBase;
        private PopUpManager _popUpManager;
        private GameManager _gameManager;
        public UnityEvent spawnExpEvent;

        private void Awake()
        {
            _popUpManager = FindObjectOfType<PopUpManager>();
            _gameManager = FindObjectOfType<GameManager>();
            _healthBarBase = GetComponentInChildren<HealthBarBase>();
        }

        /// <summary>
        ///    Shows Damage pop up above enemy, reduces currentHealth variable by damage taken, and updates the health bar
        /// </summary>
        public override void TakeDamage(int damageTaken)
        {
            _popUpManager.ShowDamagePopUp(damageTaken.ToString(), transform.position);
            base.TakeDamage(damageTaken);
            _healthBarBase.SetHealth(currentHealth);
        }

        /// <summary>
        ///    Creates Experience orb, updates enemy counter and creates death particles
        /// </summary>
        protected override void Die()
        {
            spawnExpEvent?.Invoke();
            _gameManager.UpdateEnemyCounter();
            base.Die();
        }

        public override void SetHealth(int health)
        {
            maxHealth = health;
            currentHealth = health;
            _healthBarBase.SetMaxHealth(maxHealth);
        }
    }
}