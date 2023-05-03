using System.Collections;
using Misc;
using UI;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    /// <summary>
    ///    Class responsible for player health, invisibility frames 
    /// </summary>
    public class PlayerHealth : EntityHealth
    {
        public HealthBar playerHealthBar;
        [SerializeField] private float invincibilityDurationSeconds;
        [SerializeField] private float invincibilityDeltaTime;
        private AnimatePlayer _model;
        public UnityEvent deathEvent;

        public override void SetHealth(int health)
        {
            _model = GetComponentInChildren<AnimatePlayer>();
            base.SetHealth(health);
            playerHealthBar.SetMaxHealth(maxHealth);
        }

        /// <summary>
        ///     Method with logic for lowering health variable on collision, also passes info to show the damage pop ups
        /// </summary>
        public override void TakeDamage(int damageTaken)
        {
            if (isInvincible) return;
            base.TakeDamage(damageTaken);
            playerHealthBar.SetHealth(currentHealth);
            StartCoroutine(BecomeTemporarilyInvincible());
        }

        /// <summary>
        ///     Destroys the object
        /// </summary>
        protected override void Die()
        {
            isInvincible = true;
            deathEvent?.Invoke();
        }

        private IEnumerator BecomeTemporarilyInvincible()
        {
            isInvincible = true;
            for (float i = 0; i < invincibilityDurationSeconds; i += invincibilityDeltaTime)
            {
                ScaleModelTo(_model.transform.localScale == Vector3.one ? Vector3.zero : Vector3.one);

                yield return new WaitForSeconds(invincibilityDeltaTime);
            }

            ScaleModelTo(Vector3.one);
            isInvincible = false;
        }

        private void ScaleModelTo(Vector3 scale)
        {
            _model.transform.localScale = scale;
        }
    }
}