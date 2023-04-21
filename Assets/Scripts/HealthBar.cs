using UnityEngine;

public abstract class HealthBar : MonoBehaviour

{
    public abstract void SetHealth(int currentHealth);
    public abstract void SetMaxHealth(int maxHealth);
}