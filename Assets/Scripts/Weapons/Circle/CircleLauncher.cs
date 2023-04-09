using UnityEngine;

public class CircleLauncher : IWeaponSystem
{
    [SerializeField] public CircleBullet circleBullet;

    public override void Arm(float speedEnhancements, float powerEnhancements, float areaEnhancements)
    {
        CircleBullet instantiatedBullet = Instantiate(circleBullet, transform.parent.position, Quaternion.identity,
            gameObject.transform);
        circleBullet = instantiatedBullet;
        circleBullet.UpgradeAll(speedEnhancements, powerEnhancements, areaEnhancements);
    }

    public void Stop()
    {
        circleBullet.Stop();
    }

    public override void UpgradeAll(float speedEnhancements, float powerEnhancements, float areaEnhancements)
    {
        circleBullet.UpgradeAll(speedEnhancements, powerEnhancements, areaEnhancements);
    }
}