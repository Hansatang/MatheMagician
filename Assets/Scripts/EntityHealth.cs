﻿using UnityEngine;

public abstract class EntityHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public bool isInvincible;
    public ParticleSystem deathExplosion;

    public virtual void SetHealth(int health)
    {
        maxHealth = health;
        currentHealth = health;
    }

    /// <summary>
    ///     Method with logic for lowering health variable on collision, also passes info to show the damage pop ups
    /// </summary>
    public virtual void TakeDamage(int damageTaken)
    {
        currentHealth -= damageTaken;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    /// <summary>
    ///     Destroys the object
    /// </summary>
    protected virtual void Die()
    {
        Instantiate(deathExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}