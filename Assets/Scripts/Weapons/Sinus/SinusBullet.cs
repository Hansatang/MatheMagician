using Misc;
using UnityEngine;

namespace Weapons.Sinus
{
    /// <summary>
    ///    Class responsible for moving the projectile in sinusoidal manner
    /// </summary>
    public class SinusBullet : MonoBehaviour
    {
        private Vector3 _axis;

        private float _clock;

        //Weapon specific Stats
        private readonly float _frequency = 10f; // Speed of sine movement
        private float _magnitude; // Size of sine movement
        private float _moveSpeed;

        private Vector3 _pos;
        private int _power;

        private void Start()
        {
            _pos = transform.position;
            _axis = transform.right;
            Destroy(gameObject, 5.0f);
        }

        private void Update()
        {
            _clock += Time.deltaTime;
            _pos += transform.up * (Time.deltaTime * _moveSpeed);
            transform.position = _pos + _axis * (Mathf.Sin(_clock * _frequency) * _magnitude);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemies"))
            {
                other.gameObject.GetComponent<EntityHealth>().TakeDamage(_power);
                Destroy(gameObject);
            }
        }

        public void Reverse()
        {
            _magnitude *= -1;
        }

        public void SetStatistics(float speed, int power, float area)
        {
            _magnitude = area;
            _moveSpeed = speed;
            _power = power;
        }
    }
}