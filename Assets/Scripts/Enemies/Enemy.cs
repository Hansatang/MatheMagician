using UnityEngine;

namespace Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        private const float Magnitude = 2500;
        [SerializeField] public EnemyData enemyData;
        protected int Damage;
        protected Rigidbody2D EnemyBody;
        protected EntityHealth EnemyHealth;
        protected int Health;
        protected float Speed;

        private void Awake()
        {
            Speed = enemyData.speed;
            Health = enemyData.health;
            Damage = enemyData.damage;
            EnemyBody = GetComponent<Rigidbody2D>();
            EnemyHealth = GetComponent<EntityHealth>();
            EnemyHealth.SetHealth(Health);
        }


        public virtual void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (!other.gameObject.GetComponent<EntityHealth>().isInvincible)
                {
                    other.gameObject.GetComponent<EntityHealth>().TakeDamage(Damage);
                    EnemyHealth.TakeDamage(1);
                }

                var force = other.collider.transform.position - transform.position;
                Debug.Log("Pain" + force);
                force.Normalize();
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(force * Magnitude);
            }
        }
    }
}