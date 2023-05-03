using UnityEngine;

namespace Enemies.Treant_Boss
{
    public class BossRangedAttack : MonoBehaviour
    {
        public BossBullet enemyBullet;
        private const int SpreadDegree = 45;

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