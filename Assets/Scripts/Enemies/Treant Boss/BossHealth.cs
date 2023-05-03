using Managers;
using Misc;
using UI;
using Quaternion = UnityEngine.Quaternion;

namespace Enemies.Treant_Boss
{
    public class BossHealth : EntityHealth
    {
        public Portal portal;
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
            Instantiate(portal, transform.position, Quaternion.identity);
            _gameManager.UpdateEnemyCounter();
            base.Die();
        }
    }
}