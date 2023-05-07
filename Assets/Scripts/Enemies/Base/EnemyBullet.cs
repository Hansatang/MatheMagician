using Misc;
using UnityEngine;

namespace Enemies.Base
{
    /// <summary>
    ///     Class responsible controlling the enemy projectile
    /// </summary>
    public class EnemyBullet : MonoBehaviour
    {
        public float force = 5;
        private Rigidbody2D _bulletBody;
        private const float RotationSpeed = 150f;

        private void Start()
        {
            Destroy(gameObject, 5.0f);
        }

        private void Update()
        {
            transform.Rotate(Vector3.forward * (RotationSpeed * Time.deltaTime));
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<EntityHealth>().TakeDamage(1);
                Destroy(gameObject);
            }
        }

        /// <summary>
        ///     Set the velocity for the body of projectile, so it can move towards target
        /// </summary>
        public void SetTarget(Vector2 target)
        {
            _bulletBody = GetComponent<Rigidbody2D>();
            var position = transform.position;
            _bulletBody.velocity =
                new Vector2(target.x - position.x, target.y - position.y).normalized * force;
        }
    }
}