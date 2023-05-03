using UnityEngine;

namespace Misc
{
    public class PropsHealth : EntityHealth
    {
        public HealthPickUp healthPickUp;
        
        /// <summary>
        ///    Shows die instantly to spawn a health pick Up
        /// </summary>
        public override void TakeDamage(int damageTaken)
        {
            Die();
        }

        /// <summary>
        ///    Creates Health Pick
        /// </summary>
        protected override void Die()
        {
            Instantiate(healthPickUp, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}