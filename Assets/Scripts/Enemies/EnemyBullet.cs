using UnityEngine;

namespace Enemies
{
    public class EnemyBullet : MonoBehaviour
    {
        public float force = 2;
        private Rigidbody2D _bulletBody;
        private readonly float _rotationSpeed = 150f;

        private void Start()
        {
            Destroy(gameObject, 15.0f);
        }

        private void Update()
        {
            transform.Rotate(Vector3.forward * (_rotationSpeed * Time.deltaTime));
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<EntityHealth>().TakeDamage(2);
                Destroy(gameObject);
            }
        }


        public void SetTarget(Vector2 target)
        {
            _bulletBody = GetComponent<Rigidbody2D>();
            _bulletBody.velocity =
                new Vector2(target.x - transform.position.x, target.y - transform.position.y).normalized * force;
        }
    }
}