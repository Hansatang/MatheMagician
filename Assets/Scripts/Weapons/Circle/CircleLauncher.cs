using System;
using UnityEngine;

namespace Weapons.Circle
{
    /// <summary>
    ///    Class responsible for creating and managing the rotating around it projectile
    /// </summary>
    public class CircleLauncher : WeaponSystem
    {
        [SerializeField] public CircleBullet circleBullet;

        public override void Arm()
        {
            var instantiatedBullet = Instantiate(circleBullet, transform.parent.position, Quaternion.identity,
                gameObject.transform);
            circleBullet = instantiatedBullet;
        }

        public override void UpgradeAll(float speedEnhancements, float powerEnhancements, float areaEnhancements)
        {
            circleBullet.SetStats(initialSpeed * speedEnhancements,
                (int) Math.Ceiling(initialPower * powerEnhancements), initialArea * areaEnhancements);
        }
    }
}