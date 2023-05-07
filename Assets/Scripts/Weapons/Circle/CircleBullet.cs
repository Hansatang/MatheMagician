using Misc;
using UnityEngine;

namespace Weapons.Circle
{
    /// <summary>
    ///    Class responsible for rotating the projectile around its launcher
    /// </summary>
    public class CircleBullet : MonoBehaviour
    {
        private float _angle;
        private Vector3 _offset;

        //Weapon general Stats
        private float _speed;
        private float _area;
        private int _power;

        private void Update()
        {
            _angle += _speed * Time.deltaTime;

            _offset.x = Mathf.Sin(_angle) * _area;
            _offset.y = Mathf.Cos(_angle) * _area;
            transform.position = transform.parent.position + _offset;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemies"))
                other.gameObject.GetComponent<EntityHealth>().TakeDamage(_power);
        }

        public void SetStartingAngle(float angle)
        {
            _angle = angle;
            var offset = new Vector3(Mathf.Sin(_angle), Mathf.Cos(_angle), 0) * _area;
            transform.position = transform.parent.position + offset;
        }

        public void Stop()
        {
            Destroy(gameObject);
        }

        public void SetStatistics(float speed, int power, float area)
        {
            _area = area;
            _speed = speed;
            _power = power;
        }
    }
}