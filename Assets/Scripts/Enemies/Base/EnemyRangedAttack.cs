using UnityEngine;

namespace Enemies.Base
{
    public class EnemyRangedAttack : MonoBehaviour
    {
        public EnemyBullet enemyBullet;
        

        public void ShootTowards(Vector2 target)
        {
            var bullet = Instantiate(enemyBullet, transform.position, Quaternion.identity);
            bullet.SetTarget(target);
        }
    }
}