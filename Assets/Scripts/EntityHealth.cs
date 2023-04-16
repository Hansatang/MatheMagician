using UI;
using UnityEngine;

public abstract class EntityHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    private HealthBarBase _healthBarBase;

    public void SetHealth(int health)
    {
        _healthBarBase = GetComponentInChildren<HealthBarBase>();
        maxHealth = health;
        currentHealth = health;
    }

    /// <summary>
    /// Method with logic for lowering health variable on collision, also passes info to show the damage pop ups
    /// </summary>
    public virtual void TakeDamage(int damageTaken)
    {
        Debug.Log("Taking " + damageTaken + " damage");
        currentHealth -= damageTaken;
        _healthBarBase.SetHealth(currentHealth, maxHealth);
        Debug.Log("Remaining health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Destroys the object
    /// </summary>
    public virtual void Die()
    {
        Destroy(gameObject);
    }
}