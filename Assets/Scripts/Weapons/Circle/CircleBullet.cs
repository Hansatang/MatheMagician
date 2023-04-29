using UnityEngine;

namespace Weapons.Circle
{
    public class CircleBullet : MonoBehaviour
    {
        private float _angle;
        private float _area;

        private int _power;

        //Weapon general Stats
        private float _speed;

        private void Update()
        {
            _angle += _speed * Time.deltaTime;

            var offset = new Vector3(Mathf.Sin(_angle), Mathf.Cos(_angle), 0) * _area;
            transform.position = transform.parent.position + offset;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemies"))
                other.gameObject.GetComponent<EntityHealth>().TakeDamage(_power);
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