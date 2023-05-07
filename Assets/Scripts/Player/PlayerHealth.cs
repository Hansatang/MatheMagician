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

        public UnityEvent deathEvent;
        public UnityEvent<Vector3> invincibilityEvent;
        public AudioSource painSound;

        public override void SetHealth(int health)
        {
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
            painSound.Play();
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
                invincibilityEvent?.Invoke(Vector3.zero);
                yield return new WaitForSeconds(invincibilityDeltaTime);
            }

            invincibilityEvent?.Invoke(Vector3.one);
            isInvincible = false;
        }
    }
}