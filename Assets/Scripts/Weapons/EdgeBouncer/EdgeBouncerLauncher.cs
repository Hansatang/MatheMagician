using UnityEngine;
using Weapons;

public class EdgeBouncerLauncher : WeaponSystem
{
    [SerializeField] public EdgeBouncerBullet edgeBouncerBullet;

    public override void Arm()
    {
        var instantiatedBullet = Instantiate(edgeBouncerBullet, transform.parent.position, Quaternion.identity,
            gameObject.transform);
        edgeBouncerBullet = instantiatedBullet;
        edgeBouncerBullet.SetStatistics(speedEnhanced, powerEnhanced, areaEnhanced);
    }

    public override void UpgradeAll(float speedEnhancements, float powerEnhancements, float areaEnhancements)
    {
        base.UpgradeAll(speedEnhancements, powerEnhancements, areaEnhancements);
        edgeBouncerBullet.SetStatistics(speedEnhanced, powerEnhanced, areaEnhanced);
    }
}