using UnityEngine;


namespace Enemies.EnemyProjectiles
{
    public class BossRangedAttack : MonoBehaviour
    {
        public BossBullet enemyBullet;

        public void ShootTowards(Vector2 target)
        {
            Vector3 currentPosition = transform.position;
            Vector2 targetVector = target - new Vector2(currentPosition.x, currentPosition.y);
            
            var bullet = Instantiate(enemyBullet, currentPosition, Quaternion.identity);
            bullet.SetTarget(targetVector);

            bullet = Instantiate(enemyBullet, currentPosition, Quaternion.identity);
            bullet.SetTarget(Quaternion.AngleAxis(45, Vector3.forward) * targetVector);

            bullet = Instantiate(enemyBullet, currentPosition, Quaternion.identity);
            bullet.SetTarget(Quaternion.AngleAxis(-45, Vector3.forward) * targetVector);
        }
    }
}