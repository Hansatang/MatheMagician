using UnityEngine;

namespace UI
{
    public class HealthBarBase : MonoBehaviour
    {
        [SerializeField] Transform bar;
        public GameObject healthSprite;

        public void SetHealth(int currentHealth, int maxHealth)
        {
            healthSprite.SetActive(true);
            float proportion = (float) currentHealth / maxHealth;
            bar.transform.localScale = new Vector3(proportion, 1, 1);
        }
    }
}