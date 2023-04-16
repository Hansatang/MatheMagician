using Enemies;
using UnityEngine;

namespace Weapons.Circle
{
    public class CircleBullet : MonoBehaviour
    {
        //Weapon general Stats
        private float _speed;
        private float _area;
        private int _power;
        private float _angle;

        private void Update()
        {
            _angle += _speed * Time.deltaTime;

            var offset = new Vector3(Mathf.Sin(_angle), Mathf.Cos(_angle), 0) * _area;
            transform.position = transform.parent.position + offset;
        }

        public void Stop()
        {
            Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemies"))
            {
                other.gameObject.GetComponent<EntityHealth>().TakeDamage(_power);
            }
        }

        public void SetStatistics(float speed, int power, float area)
        {
            _area = area;
            _speed = speed;
            _power = power;
        }
    }
}