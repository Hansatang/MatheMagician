using UnityEngine;


namespace Enemies.EnemyProjectiles
{
    public class BossBullet : MonoBehaviour
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

        public void SetTarget(Vector2 target)
        {
            _bulletBody = GetComponent<Rigidbody2D>();
            _bulletBody.velocity =
                new Vector2(target.x, target.y).normalized * force;
        }
    }
}