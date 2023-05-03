using System.Collections;
using UnityEngine;

namespace Enemies.Base
{
    public class EnemyMovement : Enemy
    {
        [SerializeField] private float startDashTime = 2f;
        [SerializeField] private float dashSpeed = 3f;
        private float _currentDashTime;


        public void Move(Vector2 moveDirection)
        {
            enemyBody.velocity = moveDirection * speed;
        }

        public void Dash(Vector2 dashDirection)
        {
            StartCoroutine(Dashing(dashDirection));
        }

        private IEnumerator Dashing(Vector2 dashDirection)
        {
            _currentDashTime = startDashTime; // Reset the dash timer.
            while (_currentDashTime > 0f)
            {
                _currentDashTime -= Time.deltaTime; // Lower the dash timer each frame.
                enemyBody.velocity = dashDirection * dashSpeed; // Dash in the direction that was held down.

                yield return null; // Returns out of the coroutine this frame so we don't hit an infinite loop.
            }

            enemyBody.velocity = new Vector2(0f, 0f); // Stop dashing.
        }
    }
}