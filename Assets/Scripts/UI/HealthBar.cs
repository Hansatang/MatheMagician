using UnityEngine;

namespace UI
{
    /// <summary>
    ///    Baseline for entities health bar
    /// </summary>
    public abstract class HealthBar : MonoBehaviour
    {
        public abstract void SetHealth(int currentHealth);
        public abstract void SetMaxHealth(int maxHealth);
    }
}