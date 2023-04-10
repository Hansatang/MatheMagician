using System;
using Managers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        public PopUpManager popUpManager;
        protected float Health;
        protected float Speed;

        private void Awake()
        {
            popUpManager = FindObjectOfType<PopUpManager>();
        }

        /// <summary>
        /// Method with logic for lowering health variable on collision, also passes info to show the damage pop ups
        /// </summary>
        public void TakeDamage(float damage)
        {
            popUpManager.ShowDamagePopUp(damage.ToString(), transform.position);
            Debug.Log("Taking " + damage + " damage");
            Health -= damage;
            Debug.Log("Remaining health: " + Health);
            if (Health <= 0)
            {
                Die();
            }
        }

        /// <summary>
        /// Destroys the object
        /// </summary>
        public void Die()
        {
            Destroy(gameObject);
        }
    }
}