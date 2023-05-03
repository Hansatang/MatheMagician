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
            circleBullet.SetStatistics(speedEnhanced, powerEnhanced, areaEnhanced);
        }

        public override void Stop()
        {
            circleBullet.Stop();
        }

        public override void UpgradeAll(float speedEnhancements, float powerEnhancements, float areaEnhancements)
        {
            base.UpgradeAll(speedEnhancements, powerEnhancements, areaEnhancements);
            circleBullet.SetStatistics(speedEnhanced, powerEnhanced, areaEnhanced);
        }
    }
}