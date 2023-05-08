using Misc;
using UnityEngine;

namespace Weapons.Sinus
{
    /// <summary>
    ///    Class responsible for moving the projectile in sinusoidal manner
    /// </summary>
    public class SinusBullet : PlayerBullet
    {
        private Vector3 _axis;

        private float _clock;

        //Weapon specific Stats
        private readonly float _frequency = 10f; // Speed of sine movement

        private Vector3 _pos;

        private void Start()
        {
            _pos = transform.position;
            _axis = transform.right;
            Destroy(gameObject, 5.0f);
        }

        private void Update()
        {
            _clock += Time.deltaTime;
            _pos += transform.up * (Time.deltaTime * speed);
            transform.position = _pos + _axis * (Mathf.Sin(_clock * _frequency) * area);
        }

        public void Reverse()
        {
            area *= -1;
        }
        
        protected override void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemies"))
            {
                other.gameObject.GetComponent<EntityHealth>().TakeDamage(power);
                Destroy(gameObject);
            }
        }
    }
}