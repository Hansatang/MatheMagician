using UnityEngine;

namespace Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] public EnemyData enemyData;
        private const float Magnitude = 2500;

        protected Rigidbody2D enemyBody;
        private EntityHealth _enemyHealth;
        private int _health;
        protected float speed;
        private int _damage;

        private void Awake()
        {
            speed = enemyData.speed;
            _health = enemyData.health;
            _damage = enemyData.damage;
            enemyBody = GetComponent<Rigidbody2D>();
            _enemyHealth = GetComponent<EntityHealth>();
            _enemyHealth.SetHealth(_health);
        }


        public virtual void OnCollisionEnter2D(Collision2D other)
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