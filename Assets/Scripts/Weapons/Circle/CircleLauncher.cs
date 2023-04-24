using UnityEngine;

namespace Weapons.Circle
{
    public class CircleLauncher : WeaponSystem
    {
        [SerializeField] public CircleBullet circleBullet;

        public override void Arm()
        {
            CircleBullet instantiatedBullet = Instantiate(circleBullet, transform.parent.position, Quaternion.identity,
                gameObject.transform);
            circleBullet = instantiatedBullet;
            circleBullet.SetStatistics(speed, power, area);
        }

        public override void Stop()
        {
            circleBullet.Stop();
        }

        public override void UpgradeAll(float speedEnhancements, float powerEnhancements, float areaEnhancements)
        {
            base.UpgradeAll(speedEnhancements, powerEnhancements, areaEnhancements);
            circleBullet.SetStatistics(speed, power, area);
        }
    }
}