using Misc;
using UnityEngine;

namespace Weapons.Circle
{
    /// <summary>
    ///    Class responsible for rotating the projectile around its launcher
    /// </summary>
    public class CircleBullet : PlayerBullet
    {
        private float _angle;
        private Vector3 _offset;
        

        private void Update()
        {
            _angle += speed * Time.deltaTime;

            _offset.x = Mathf.Sin(_angle) * area;
            _offset.y = Mathf.Cos(_angle) * area;
            transform.position = transform.parent.position + _offset;
        }

        public void SetStartingAngle(float angle)
        {
            _angle = angle;
            var offset = new Vector3(Mathf.Sin(_angle), Mathf.Cos(_angle), 0) * area;
            transform.position = transform.parent.position + offset;
        }

        public void Stop()
        {
            Destroy(gameObject);
        }
        
    }
}