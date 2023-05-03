using UnityEngine;

namespace Enemies.Treant_Boss
{
    /// <summary>
    ///     Class responsible for creating the explosion indicators
    /// </summary>
    public class BossMeleeAttack : MonoBehaviour
    {
        public BossExplosionAttackIndicator bossExplosionAttackIndicator;

        public void MeleeAttack()
        {
            var transform1 = transform;
            Instantiate(bossExplosionAttackIndicator, transform1.position, Quaternion.identity, transform1.parent);
        }
    }
}