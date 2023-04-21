using Enemies;
using UnityEngine;

namespace Weapons.Sinus
{
    public class SinusBullet : MonoBehaviour
    {
        //Weapon specific Stats
        private float _frequency = 10f; // Speed of sine movement
        private float _magnitude; // Size of sine movement

        //Weapon general Stats
        private int _power;
        private float _moveSpeed;


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
            _pos += transform.up * (Time.deltaTime * _moveSpeed);
            transform.position = _pos + _axis * (Mathf.Sin(_clock * _frequency) * _magnitude);
        }

        public void Stop()
        {
            Destroy(gameObject);
        }

        public void Reverse()
        {
            _magnitude *= -1;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemies"))
            {
                other.gameObject.GetComponent<EntityHealth>().TakeDamage(_power);
                Destroy(gameObject);
            }
        }

        public void SetStatistics(float speed, int power, float area)
        {
            _magnitude = area;
            _moveSpeed = speed;
            _power = power;
        }
    }
}