using Managers;
using UnityEngine;

namespace Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] public EnemyData enemyData;
        protected int Health;
        protected float Speed;
        protected int Damage;

        private void Awake()
        {
            Speed = enemyData.speed;
            Health = enemyData.health;
            Damage = enemyData.damage;
            GetComponent<EntityHealth>().SetHealth(Health);
        }


        public virtual void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<EntityHealth>().TakeDamage(Damage);
                Destroy(gameObject);
            }
        }
    }
}