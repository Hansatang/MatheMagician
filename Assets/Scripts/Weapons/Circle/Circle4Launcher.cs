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
                instantiatedBullet.SetStatistics(speedEnhanced, powerEnhanced, areaEnhanced);
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
            base.UpgradeAll(speedEnhancements, powerEnhancements, areaEnhancements);
            foreach (var bullet in _activeBullets)
            {
                bullet.SetStatistics(speedEnhanced, powerEnhanced, areaEnhanced);
            }
        }
    }
}