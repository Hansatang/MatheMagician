using UnityEngine;

namespace Enemies.Base
{
    /// <summary>
    ///     Class responsible for movement based enemy actions
    /// </summary>
    public class EnemyMovement : MonoBehaviour
    {
        protected Rigidbody2D enemyBody;
        private float _speed;

        private void Start()
        {
            enemyBody = GetComponent<Rigidbody2D>();
        }

        public void Move(Vector2 moveDirection)
        {
            enemyBody.velocity = moveDirection * _speed;
        }

        public void SetSpeed(float enemyDataSpeed)
        {
            _speed = enemyDataSpeed;
        }
    }
}