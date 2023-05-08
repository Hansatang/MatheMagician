using System;
using UnityEngine;

namespace Weapons.EdgeBouncer
{
    public class EdgeBouncerLauncher : WeaponSystem
    {
        [SerializeField] public EdgeBouncerBullet edgeBouncerBullet;

        public override void Arm()
        {
            var instantiatedBullet = Instantiate(edgeBouncerBullet, transform.parent.position, Quaternion.identity,
                gameObject.transform);
            edgeBouncerBullet = instantiatedBullet;
        }

        public override void UpgradeAll(float speedEnhancements, float powerEnhancements, float areaEnhancements)
        {
            edgeBouncerBullet.SetStats(initialSpeed * speedEnhancements,
                (int) Math.Ceiling(initialPower * powerEnhancements), initialArea * areaEnhancements);
        }
    }
}