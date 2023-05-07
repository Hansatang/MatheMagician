using Misc;
using UnityEngine;

namespace Enemies.Treant_Boss
{
    /// <summary>
    ///     Class responsible for Boss ranged projectile
    /// </summary>
    public class BossBullet : MonoBehaviour
    {
        private const float Force = 3;
        private Rigidbody2D _bulletBody;

        private void Start()
        {
            Destroy(gameObject, 15.0f);
        }

        public void SetTarget(Vector2 target)
        {
            _bulletBody = GetComponent<Rigidbody2D>();
            _bulletBody.velocity =
                new Vector2(target.x, target.y).normalized * Force;
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<EntityHealth>().TakeDamage(1);
                Destroy(gameObject);
            }
        }
    }
}