using UnityEngine;

namespace UI
{
    public abstract class HealthBar : MonoBehaviour

    {
        public abstract void SetHealth(int currentHealth);
        public abstract void SetMaxHealth(int maxHealth);
    }
}