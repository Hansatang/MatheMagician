using Misc;
using UnityEngine;

namespace Enemies.Treant_Boss
{
    /// <summary>
    ///     Class responsible for explosion attack
    /// </summary>
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