using UnityEngine;

namespace Enemies.Treant_Boss
{
    public class ParticleCollision : MonoBehaviour
    {
        void OnParticleCollision(GameObject other)
        {
            if (other.CompareTag("Player"))
            {
                other.gameObject.GetComponent<EntityHealth>().TakeDamage(2);
                Destroy(gameObject);
            }
        }
    }
}