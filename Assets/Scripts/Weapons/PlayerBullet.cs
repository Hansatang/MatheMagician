using Misc;
using UnityEngine;

namespace Weapons
{
    public class PlayerBullet : MonoBehaviour
    {
        //Weapon general Stats
        protected float speed;
        protected float area;
        protected int power;

        protected virtual void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemies"))
                other.gameObject.GetComponent<EntityHealth>().TakeDamage(power);
        }
        
        public void SetStats(float baseSpeed, int basePower, float baseArea)
        {
            area = baseArea;
            speed = baseSpeed;
            power = basePower;
        }
    }
}