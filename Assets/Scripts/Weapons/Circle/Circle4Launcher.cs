using System;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons.Circle
{
    public class Circle4Launcher : WeaponSystem
    {
        [SerializeField] public CircleBullet circleBullet;
        private List<CircleBullet> _activeBullets = new(3);
        private const float StartingAngle = 90f;

        public override void Arm()
        {
            for (var i = -StartingAngle; i <= StartingAngle; i += StartingAngle)
            {
                var instantiatedBullet = Instantiate(circleBullet, transform.parent.position, Quaternion.identity,
                    gameObject.transform);
                instantiatedBullet.SetStartingAngle(i);
                _activeBullets.Add(instantiatedBullet);
            }
        }

        public override void Stop()
        {
            foreach (var bullet in _activeBullets)
            {
                bullet.Stop();
            }
        }

        public override void UpgradeAll(float speedEnhancements, float powerEnhancements, float areaEnhancements)
        {
            foreach (var bullet in _activeBullets)
            {
                bullet.SetStats(initialSpeed * speedEnhancements,
                    (int) Math.Ceiling(initialPower * powerEnhancements), initialArea * areaEnhancements);
            }
        }
    }
}