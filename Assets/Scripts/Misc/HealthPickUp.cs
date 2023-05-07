using UnityEngine;

namespace Misc
{
    public class HealthPickUp : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Player")) return;

            other.gameObject.GetComponent<EntityHealth>().TakeDamage(-1);
            Destroy(gameObject);
        }
    }
}