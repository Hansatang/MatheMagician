using UnityEngine;

namespace Enemies.Treant_Boss
{
    /// <summary>
    ///     Class responsible for creating Boss ranged attacks in a cone
    /// </summary>
    public class BossRangedAttack : MonoBehaviour
    {
        public BossBullet enemyBullet;
        private const int SpreadDegree = 45;

        /// <summary>
        ///     In for loop it modifies the target by rotating its vector by -SpreadDegree and SpreadDegree
        /// </summary>
        public void ShootTowards(Vector2 target)
        {
            Vector3 currentPosition = transform.position;
            Vector2 targetVector = target - new Vector2(currentPosition.x, currentPosition.y);

            for (var i = -SpreadDegree; i <= SpreadDegree; i += SpreadDegree)
            {
                Instantiate(enemyBullet, currentPosition, Quaternion.identity)
                    .SetTarget(Quaternion.AngleAxis(i, Vector3.forward) * targetVector);
            }
        }
    }
}