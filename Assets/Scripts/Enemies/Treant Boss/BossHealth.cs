using Managers;
using Misc;
using UI;
using UnityEngine.Events;

namespace Enemies.Treant_Boss
{
    /// <summary>
    ///     Class responsible for Boss health and death behaviour - spawning the Victory Portal
    /// </summary>
    public class BossHealth : EntityHealth
    {
        private HealthBar _healthBarBase;
        private PopUpManager _popUpManager;
        private GameManager _gameManager;
        public UnityEvent spawnPortalEvent;

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
            spawnPortalEvent?.Invoke();
            _gameManager.UpdateEnemyCounter();
            base.Die();
        }
    }
}