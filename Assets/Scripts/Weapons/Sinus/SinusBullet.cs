using UnityEngine;

namespace Weapons.Sinus
{
    public class SinusBullet : MonoBehaviour
    {
        private float _power = 1.0f;
        public float moveSpeed = 5.0f;

        public float frequency = 5f; // Speed of sine movement
        public float magnitude = 0.5f; // Size of sine movement
        private Vector3 _axis;

        private Vector3 _pos;
        private float _clock;

        void Start()
        {
            _pos = transform.position;
            Destroy(gameObject, 2.0f);
            _axis = transform.right;
        }

        void Update()
        {
            _clock += Time.deltaTime;
            _pos += transform.up * (Time.deltaTime * moveSpeed);
            transform.position = _pos + _axis * (Mathf.Sin(_clock * frequency) * magnitude);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemies"))
            {
                // other.gameObject.GetComponent<Enemy>().TakeDamage(_power);
                Destroy(gameObject);
            }
        }

        public void UpgradeAll(float speedEnhancements, float powerEnhancements, float areaEnhancements)
        {
            magnitude *= areaEnhancements;
            moveSpeed *= speedEnhancements;
            _power *= powerEnhancements;
        }

        public void Stop()
        {
            Destroy(gameObject);
        }

        public void Reverse()
        {
            magnitude *= -1;
        }
    }
}