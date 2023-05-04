using Enemies.Base;
using Misc;
using UnityEngine;

namespace Enemies
{
    /// <summary>
    ///     Baseline for enemy stats, movement and body collision
    /// </summary>
    public class Enemy : MonoBehaviour
    {
        [SerializeField] public EnemyData enemyData;
        private const float Magnitude = 2500;
        private EntityHealth _enemyHealth;
        private int _damage;

        private void Awake()
        {
            _damage = enemyData.damage;
            GetComponent<EnemyMovement>().SetSpeed(enemyData.speed);
            _enemyHealth = GetComponent<EntityHealth>();
            _enemyHealth.SetHealth(enemyData.health);
        }

        /// <summary>
        ///     Responsible for damaging player and itself if player is not in isInvincible State, and applying knock-back
        /// </summary>
        public void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (!other.gameObject.GetComponent<EntityHealth>().isInvincible)
                {
                    other.gameObject.GetComponent<EntityHealth>().TakeDamage(_damage);
                    _enemyHealth.TakeDamage(1);
                }

                var force = other.collider.transform.position - transform.position;
                force.Normalize();
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(force * Magnitude);
            }
        }
    }
}