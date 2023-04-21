using System.Collections;
using Player;
using UnityEngine;

public class PlayerHealth : EntityHealth
{
    public HealthBar playerHealthBar;
    private bool _isInvincible;
    [SerializeField] private float invincibilityDurationSeconds;
    [SerializeField] private float invincibilityDeltaTime;
    private AnimatePlayer _model;

    public override void SetHealth(int health)
    {
        _model = GetComponentInChildren<AnimatePlayer>();
        base.SetHealth(health);
        playerHealthBar.SetMaxHealth(maxHealth);
    }

    /// <summary>
    /// Method with logic for lowering health variable on collision, also passes info to show the damage pop ups
    /// </summary>
    public override void TakeDamage(int damageTaken)
    {
        if (_isInvincible) return;
        base.TakeDamage(damageTaken);
        playerHealthBar.SetHealth(currentHealth);
        StartCoroutine(BecomeTemporarilyInvincible());
    }

    /// <summary>
    /// Destroys the object
    /// </summary>
    public override void Die()
    {
        Debug.Log("Dead");
    }

    private IEnumerator BecomeTemporarilyInvincible()
    {
        _isInvincible = true;

        for (float i = 0; i < invincibilityDurationSeconds; i += invincibilityDeltaTime)
        {
            if (_model.transform.localScale == Vector3.one)
            {
                ScaleModelTo(Vector3.zero);
            }
            else
            {
                ScaleModelTo(Vector3.one);
            }

            yield return new WaitForSeconds(invincibilityDeltaTime);
        }

        ScaleModelTo(Vector3.one);
        _isInvincible = false;
    }

    private void ScaleModelTo(Vector3 scale)
    {
        _model.transform.localScale = scale;
    }
}