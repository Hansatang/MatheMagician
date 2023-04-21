using UnityEngine;

public abstract class EntityHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;


    public virtual void SetHealth(int health)
    {
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
        Debug.Log("Remaining health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Debug.Log(currentHealth+"LOL");
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