using UnityEngine;

namespace Enemies
{
    public class EnemyMeleeAttack : MonoBehaviour
    {
        public EnemyExplosionAttackIndicator enemyExplosionAttackIndicator;

        public void MeleeAttack()
        {
            Instantiate(enemyExplosionAttackIndicator, transform.position, Quaternion.identity, transform.parent);
        }
    }
}