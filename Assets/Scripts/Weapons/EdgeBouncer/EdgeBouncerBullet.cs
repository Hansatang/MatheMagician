using Misc;
using UnityEngine;

namespace Weapons.EdgeBouncer
{
    public class EdgeBouncerBullet : PlayerBullet
    {
        private Rigidbody2D _body;
        private Camera _camera;
        private Vector2 _screenPosition;

        private void Start()
        {
            _camera = FindObjectOfType<Camera>();
            _body = GetComponent<Rigidbody2D>();
            _body.velocity = new Vector2(1f, 1f) * speed;
        }

        private void Update()
        {
            _screenPosition = _camera.WorldToScreenPoint(transform.position);
           
            if (_screenPosition.y > Screen.height)
            {
                SetWorldPosition();
                Move(Vector3.down);
            }

            else if (_screenPosition.y < 0f)
            {
                SetWorldPosition();
                Move(Vector3.up);
            }

            else if (_screenPosition.x > Screen.width)
            {
                SetWorldPosition();
                Move(Vector3.right);
            }

            else if (_screenPosition.x < 0f)
            {
                SetWorldPosition();
                Move(Vector3.left);
            }
        }

        private void SetWorldPosition()
        {
            _screenPosition.x = Mathf.Clamp(_screenPosition.x, 0f, Screen.width);
            _screenPosition.y = Mathf.Clamp(_screenPosition.y, 0f, Screen.height);
            Vector3 newWorldPosition = _camera.ScreenToWorldPoint(_screenPosition);
            transform.position = new Vector2(newWorldPosition.x, newWorldPosition.y);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemies"))
            {
                other.gameObject.GetComponent<EntityHealth>().TakeDamage(power);
            }
        }

        private void Move(Vector3 inNormal)
        {
            _body.velocity = Vector3.Reflect(_body.velocity.normalized, inNormal) * speed;
        }
    }
}