using Managers;

namespace DefaultNamespace
{
    public class EnemyHealth : EntityHealth
    {
        private PopUpManager _popUpManager;

        private void Awake()
        {
            _popUpManager = FindObjectOfType<PopUpManager>();
        }

        public override void TakeDamage(int damageTaken)
        {
            _popUpManager.ShowDamagePopUp(damageTaken.ToString(), transform.position);
            base.TakeDamage(damageTaken);
        }
    }
}