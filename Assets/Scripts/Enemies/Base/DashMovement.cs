using System.Collections;
using Enemies.Base;
using UnityEngine;

namespace Enemies.Treant_Boss
{
    public class DashMovement : EnemyMovement
    {
        [SerializeField] private float startDashTime = 2f;
        [SerializeField] private float dashSpeed = 3f;
        private float _currentDashTime;


        public void Dash(Vector2 dashDirection)
        {
            StartCoroutine(Dashing(dashDirection));
        }

        /// <summary>
        ///    Contains logic for dashing over time, then resetting the velocity of the body
        /// </summary>
        private IEnumerator Dashing(Vector2 dashDirection)
        {
            _currentDashTime = startDashTime;
            while (_currentDashTime > 0f)
            {
                _currentDashTime -= Time.deltaTime;
                enemyBody.velocity = dashDirection * dashSpeed;

                yield return null;
            }

            enemyBody.velocity = new Vector2(0f, 0f);
        }
    }
}