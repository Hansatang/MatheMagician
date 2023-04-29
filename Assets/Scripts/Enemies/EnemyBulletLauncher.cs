using UnityEngine;

namespace Enemies
{
    public class EnemyBulletLauncher : MonoBehaviour
    {
        public EnemyBullet enemyBullet;

        public void ShootTowards(Vector2 target)
        {
            var bullet = Instantiate(enemyBullet, transform.position, Quaternion.identity);
            bullet.SetTarget(target);
        }
    }
}