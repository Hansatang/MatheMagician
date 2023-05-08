using System;
using System.Collections;
using Player;
using UnityEngine;

namespace Weapons.Sinus
{
    /// <summary>
    ///    Class responsible for creating and managing the stats of projectiles 
    /// </summary>
    public class SinusLauncher : WeaponSystem
    {
        [SerializeField] public SinusBullet sinBullet;
        protected const float AttackDelay = 1f;
        protected PlayerInput playerInput;

        protected float enhancedSpeed;
        protected int enhancedPower;
        protected float enhancedArea;

        public override void Arm()
        {
            playerInput = GameObject.Find("Player").GetComponent<PlayerInput>();
            StartCoroutine(SpawnSinBullet());
        }

        protected IEnumerator SpawnSinBullet()
        {
            while (true)
            {
                Instantiate(sinBullet, transform.position, playerInput.rotation, gameObject.transform)
                    .SetStats(enhancedSpeed, enhancedPower, enhancedArea);
                yield return new WaitForSeconds(AttackDelay);
            }
        }

        public override void UpgradeAll(float speedEnhancements, float powerEnhancements, float areaEnhancements)
        {
            enhancedSpeed = initialSpeed * speedEnhancements;
            enhancedPower = (int) Math.Ceiling(initialPower * powerEnhancements);
            enhancedArea = initialArea * areaEnhancements;
        }

        public override void SetBaseStats(float speed, float area, float power)
        {
            initialSpeed = speed;
            initialPower = (int) Math.Ceiling(power);
            initialArea = area;
            enhancedSpeed = initialSpeed;
            enhancedPower = initialPower;
            enhancedArea = initialArea;
        }

        public override void Stop()
        {
            Destroy(gameObject);
        }
    }
}