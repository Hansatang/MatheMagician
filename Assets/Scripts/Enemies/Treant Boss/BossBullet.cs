using UnityEngine;

namespace Enemies.Treant_Boss
{
    public class BossBullet : MonoBehaviour
    {
        private const float Force = 3;
        private Rigidbody2D _bulletBody;
        private const float RotationSpeed = 150f;

        private void Start()
        {
            Destroy(gameObject, 15.0f);
        }

        private void Update()
        {
            transform.Rotate(Vector3.forward * (RotationSpeed * Time.deltaTime));
        }

        public void SetTarget(Vector2 target)
        {
            _bulletBody = GetComponent<Rigidbody2D>();
            _bulletBody.velocity =
                new Vector2(target.x, target.y).normalized * Force;
        }
    }
}